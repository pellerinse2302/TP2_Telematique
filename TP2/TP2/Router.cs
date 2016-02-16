using System;
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
    public int Port { get; set; }
    #endregion

    #region Constructeur
    public Router()
    {
      this.Gateway = IPAddress.Parse("127.0.0.1");
      var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    }
    #endregion

    #region Méthodes publiques
    /// <summary>
    /// Permet d'envoyer son graph aux routeurs voisins
    /// </summary>
    public void UpdateNeighborhood()
    {
      while (!RouterGraph.IsUpdated)
      {
        foreach (Link link in NeighboursLink)
        {
          SendGraphTo(link.ListRouter.First(x => x != this));
        }
      }
    }
    #endregion

    #region Méthodes privées
    /// <summary>
    /// Permet d'envoyer le graph à un router specifique
    /// </summary>
    /// <param name="router"></param>
    private void SendGraphTo(Router router)
    {
      //TODO
      //Dans la réception du graph il faut comparer les graph et si ils sont identiques
      //on met le graph.isupdated a true, sinon à false
      //Lorsque tous les graphs seront updated, ça veut dire que tous les routers ont le mm graph

    }
    #endregion
  }
}
