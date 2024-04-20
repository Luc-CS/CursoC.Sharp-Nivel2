using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;

namespace negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> listarCategorias()
        {
            List<Categoria> liscategoria = new List<Categoria>();
            AccesoDatos accesoDatos = new AccesoDatos();


            try
            {
                accesoDatos.setearConsulta("select * from CATEGORIAS");
                accesoDatos.ejecutarLectura();

                while (accesoDatos.lector.Read() == true)
                {
                    Categoria aux = new Categoria();
                    aux._Id = (int)accesoDatos.lector["id"];
                    aux._Descripcion = (string)accesoDatos.lector["descripcion"];

                    liscategoria.Add(aux);

                }

                return liscategoria;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();

            }




        }
    }
}
