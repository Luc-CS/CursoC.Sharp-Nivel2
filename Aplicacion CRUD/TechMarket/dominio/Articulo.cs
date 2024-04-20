using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Articulo
    {
        public int _Id {  get; set; }
        [DisplayName("Codigo")]
        public string Codigo { get; set; }
        public Categoria categoria { get; set; }
        public Marca marca { get; set; }
        public string Nombre { get; set; }
        [DisplayName("Imagen")]
        public string _imagenUrl { get; set; }
        public decimal Precio { get; set; }
        [DisplayName("Descripcion")]
        public string _Descripcion { get; set; }


    }
}
