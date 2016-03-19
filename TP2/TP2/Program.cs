using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TP2
{
  class Program
  {
    static void Main(string[] args)
    {

      //Choix de l'algo
      int choiceAlgorithm;
      bool parsed;

      do
      {
        Console.WriteLine("Quel algorithme souhaitez-vous utiliser?\n1) LS\n2) DV");
        parsed = Int32.TryParse(Console.ReadLine(), out choiceAlgorithm);
      } while (!parsed || (choiceAlgorithm != 1 && choiceAlgorithm != 2));

      if (choiceAlgorithm == 1)
      {
        Router.RouterMode = ModeEnum.LS;
      }

      else
      {
        Router.RouterMode = ModeEnum.DV;
      }

      Router RouterA = new Router("RouterA", 50001);
      Router RouterB = new Router("RouterB", 50002);
      Router RouterC = new Router("RouterC", 50003);
      Router RouterD = new Router("RouterD", 50004);
      Router RouterE = new Router("RouterE", 50005);
      Router RouterF = new Router("RouterF", 50006);

      Link linkAB = new Link(RouterA, RouterB, 5);
      Link linkAD = new Link(RouterA, RouterD, 45);
      Link linkBC = new Link(RouterB, RouterC, 70);
      Link linkBE = new Link(RouterB, RouterE, 3);
      Link linkDC = new Link(RouterD, RouterC, 50);
      Link linkDE = new Link(RouterD, RouterE, 8);
      Link linkCF = new Link(RouterC, RouterF, 78);
      Link linkEF = new Link(RouterE, RouterF, 7);

      RouterA.NeighboursLink = new List<Link>() { linkAB, linkAD };
      RouterB.NeighboursLink = new List<Link>() { linkAB, linkBE, linkBC };
      RouterC.NeighboursLink = new List<Link>() { linkBC, linkDC, linkCF };
      RouterD.NeighboursLink = new List<Link>() { linkAD, linkDC, linkDE };
      RouterE.NeighboursLink = new List<Link>() { linkDE, linkBE, linkEF };
      RouterF.NeighboursLink = new List<Link>() { linkCF, linkEF };

      Thread routerA = new Thread(RouterA.start);
      Thread routerB = new Thread(RouterB.start);
      Thread routerC = new Thread(RouterC.start);
      Thread routerD = new Thread(RouterD.start);
      Thread routerE = new Thread(RouterE.start);
      Thread routerF = new Thread(RouterF.start);

      routerA.Start();
      routerB.Start();
      routerC.Start();
      routerD.Start();
      routerE.Start();
      routerF.Start();

      RouterA.UpdateNeighborhood();

      Console.ReadLine();
    }
  }
}
