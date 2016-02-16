using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
  class Link
  {
    #region Propriétés
    public Router R1 { get; set; }
    public Router R2 { get; set; }
    public int Cost { get; set; }

    /// <summary>
    /// Permet d'avoir les routeurs sous forme de liste
    /// </summary>
    public List<Router> ListRouter
    {
      get
      {
        return new List<Router>() { R1, R2 };
      }
    }
    #endregion

    #region Constructeur
    /// <summary>
    /// Constructeur par défaut
    /// </summary>
    public Link()
    {

    }

    /// <summary>
    /// Constructeur paramétré
    /// </summary>
    public Link(Router r1, Router r2, int cost)
    {
      R1 = r1;
      R2 = r2;
      Cost = cost;
    }
    #endregion

    #region Méthodes publiques

    #endregion

    #region Méthodes privées

    #endregion
  }
}
