using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace dominio //nammespace de antes: namespace DiscosPruebaADO
{
    public class Elemento //si o si public, para que pueden reconocerlo y ser visible
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
