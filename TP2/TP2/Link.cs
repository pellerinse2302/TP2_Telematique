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
    public int R1Port { get; set; }
    public Router R2 { get; set; }
    public int R2Port { get; set; }
    public int Cost { get; set; }

    /// <summary>
    /// Permet d'avoir les routeurs sous forme de liste
    /// </summary>
    public Dictionary<Router, int> ListRouter
    {
      get
      {
        return new Dictionary<Router, int>()
        {
          {R1, R1Port},
          {R2, R2Port}
        };
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
    public Link(Router r1, int r1Port, Router r2, int r2Port, int cost)
    {
      R1 = r1;
      R1Port = r1Port;
      R2 = r2;
      R2Port = r2Port;
      Cost = cost;
    }
    #endregion

    #region Méthodes publiques

    #endregion

    #region Méthodes privées

    #endregion
  }
}
