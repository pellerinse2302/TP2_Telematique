using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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


      Router RouterA = new Router("RouterA");
      Router RouterB = new Router("RouterB");
      Router RouterC = new Router("RouterC");
      Router RouterD = new Router("RouterD");
      Router RouterE = new Router("RouterE");
      Router RouterF = new Router("RouterF");

      Link linkAB = new Link(RouterA, 50001, RouterB, 50002, 5);
      Link linkAD = new Link(RouterA, 51001, RouterD, 51002, 45);
      Link linkBC = new Link(RouterB, 52001, RouterC, 52002, 70);
      Link linkBE = new Link(RouterB, 53001, RouterE, 53002, 3);
      Link linkDC = new Link(RouterD, 54001, RouterC, 54002, 50);
      Link linkDE = new Link(RouterD, 55001, RouterE, 55002, 8);
      Link linkCF = new Link(RouterC, 56001, RouterF, 56002, 78);
      Link linkEF = new Link(RouterE, 57001, RouterF, 57002, 7);

      RouterA.NeighboursLink = new List<Link>() { linkAB, linkAD };
      RouterB.NeighboursLink = new List<Link>() { linkAB, linkBE, linkBC };
      RouterC.NeighboursLink = new List<Link>() { linkBC, linkDC, linkCF };
      RouterD.NeighboursLink = new List<Link>() { linkAD, linkDC, linkDE };
      RouterE.NeighboursLink = new List<Link>() { linkDE, linkBE, linkEF };
      RouterF.NeighboursLink = new List<Link>() { linkCF, linkEF };

      RouterA.UpdateNeighborhood();

      Console.ReadLine();
    }
  }
}
