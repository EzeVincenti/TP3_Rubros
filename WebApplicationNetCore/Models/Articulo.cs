using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationNetCore.Models
{
    public class Articulo
    {
        [Key]
        public int ArticuloID { get; set; }
        public string Descripcion { get; set; }
        public DateTime UltAct { get; set; }
        public decimal PrecioCosto { get; set; }
        public decimal PorcentajeGanancia { get; set; }
        public decimal PrecioVenta { get; set; }
        public bool Eliminado { get; set; }
        public int SubrubroID { get; set; }
        public virtual Subrubro Subrubro { get; set; }

    }
    public class ArticuloMostrar
    {
        public int ArticuloID { get; set; }
        public string Descripcion { get; set; }
        public DateTime UltAct { get; set; }
        public string UltActString { get; set; }
        public decimal PrecioCosto { get; set; }
        public decimal PorcentajeGanancia { get; set; }
        public decimal PrecioVenta { get; set; }
        public bool Eliminado { get; set; }
        public int SubrubroID { get; set; }
        public string SubRubroNombre { get; set; }
        public int RubroID { get; set; }
        public string RubroNombre { get; set; }
    }

}
