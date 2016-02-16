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

      Console.ReadLine();
    }
  }
}
