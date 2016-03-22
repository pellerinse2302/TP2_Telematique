using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
  class RoutingTable
  {
    #region Propriétés
    public bool IsUpdated { get; set; }
    public List<Link> graph { get; set; }
    #endregion

    #region Constructeur
    /// <summary>
    /// Constructeur par défaut
    /// </summary>
    public RoutingTable()
    {
      this.IsUpdated = false;
      this.graph = new List<Link>();
    }
    #endregion

    #region Méthodes publiques

    #endregion

    #region Méthodes privées

    #endregion
  }
}
