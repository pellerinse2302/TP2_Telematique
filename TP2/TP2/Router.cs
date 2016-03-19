﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
  class Router
  {
    #region Propriétés
    /// <summary>
    /// Mode du router (LS/DV)
    /// </summary>
    public static ModeEnum RouterMode { get; set; }
    public List<Link> NeighboursLink { get; set; }
    public RoutingTable RoutTable { get; set; }
    public Graph RouterGraph { get; set; }
    public IPAddress Gateway { get; set; }
    public string RouterName { get; set; }
    public int portNumber { get; set; }
    #endregion

    #region Constructeur
    public Router(string name = null, int port = 0)
    {
      this.RouterGraph = new Graph();
      this.Gateway = IPAddress.Parse("127.0.0.1");
      this.RouterName = name;
      this.portNumber = port;
    }
    #endregion

    #region Méthodes publiques
    /// <summary>
    /// Permet de récupérer le # de port du router associé à un lien
    /// </summary>
    /// <param name="link"></param>
    /// <returns></returns>
    /*public int GetPort(Link link)
    {
      return NeighboursLink.First(x => x == link).ListRouter.First(x => x.Key == this).Value;
    }*/
    /// <summary>
    /// Permet d'envoyer son graph aux routeurs voisins
    /// </summary>
    public void UpdateNeighborhood()
    {
      //while (!RouterGraph.IsUpdated)
      //{
      foreach (Link link in NeighboursLink)
      {
        SendGraphTo(link.ListRouter.First(x => x != this), link);
      }
      //}
    }
    #endregion

    #region Méthodes privées
    /// <summary>
    /// Permet d'envoyer le graph à un router specifique
    /// </summary>
    /// <param name="router"></param>
    private void SendGraphTo(Router destRouter, Link link)
    {
      //TODO
      //Dans la réception du graph il faut comparer les graph et si ils sont identiques
      //on met le graph.isupdated a true, sinon à false
      //Lorsque tous les graphs seront updated, ça veut dire que tous les routers ont le mm graph
      string str = "Hello world!";
      try
      {
        //var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //socket.Connect(destRouter.Gateway, destRouter.GetPort(link));
        //socket.Send(Encoding.UTF8.GetBytes(str), 0, str.Length, SocketFlags.None);

        TcpClient client = new TcpClient(destRouter.Gateway.ToString(), destRouter.portNumber);
        // Translate the passed message into ASCII and store it as a Byte array.
        Byte[] data = System.Text.Encoding.ASCII.GetBytes(str);

        // Get a client stream for reading and writing.
        //  Stream stream = client.GetStream();

        NetworkStream stream = client.GetStream();

        // Send the message to the connected TcpServer. 
        stream.Write(data, 0, data.Length);

        Console.WriteLine("Sent: {0}", str);

        // Receive the TcpServer.response.

        // Buffer to store the response bytes.
        data = new Byte[256];

        // String to store the response ASCII representation.
        String responseData = String.Empty;

        // Read the first batch of the TcpServer response bytes.
        Int32 bytes = stream.Read(data, 0, data.Length);
        responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
        Console.WriteLine("Received: {0}", responseData);

        // Close everything.
        stream.Close();
        client.Close();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }

    /// <summary>
    /// Démarre un thread pour listen sur le port du router.
    /// </summary>
    public void StartListening()
    {
      TcpListener server = null;

      try
      {
        server = new TcpListener(this.Gateway, this.portNumber);
        server.Server.ReceiveTimeout = 10000;
        server.Start();

        while (!RouterGraph.IsUpdated)
        {
          TcpClient client = server.AcceptTcpClient();
        }
      }
      catch (SocketException e)
      {
        //Devrait se rendre ici s'il timeout.
        Console.WriteLine("Le {0} est à jour ", this.RouterName);

        while (true)
        {
          server.Server.ReceiveTimeout = 0;
          TcpClient client = server.AcceptTcpClient();
        }
      }
      finally
      {
        // Stop listening for new clients.
        server.Stop();
      }
    }
    #endregion

  }
}
