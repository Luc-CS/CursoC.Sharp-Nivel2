using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;

namespace negocio
{
    public class MarcaData
    {
        public List<Marca> listarMarcas()
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            List<Marca> listMarca = new List<Marca>();
            try
            {

                accesoDatos.setearConsulta("select * from Marcas");
                accesoDatos.ejecutarLectura();


                while (accesoDatos.lector.Read() != false)
                {
                    Marca aux = new Marca();
                    aux._Id = (int)accesoDatos.lector["id"];
                    aux._Descripcion = (string)accesoDatos.lector["Descripcion"];
                    listMarca.Add(aux);

                }

                return listMarca;


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
