using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Categoria
    {
        public int _Id {  get; set; }
        public string _Descripcion { get; set; }
        public override string ToString()
        {
            return _Descripcion;
        }
    }
}
