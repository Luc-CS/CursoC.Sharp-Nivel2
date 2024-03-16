using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio; //si o si incluirlo, ademas de influir en referencias
using System.ComponentModel.Design;
using System.Collections;

namespace negocio
{
    public class PokemonNegocio //es una clase para un acceso a datos
    {
        public List<Pokemon> listar()
    {
        List<Pokemon> lista = new List<Pokemon>();
        SqlConnection conexion = new SqlConnection();
        SqlCommand comando = new SqlCommand();
        SqlDataReader lector; //no tiene constructor

        try //siempre que es para leer datos o etc esto es lo normal porque es algo sensible
        {
            conexion.ConnectionString = "server=LAPTOP-Q752KUE2\\SQLEXPRESS; database=POKEDEX_DB; integrated security=true;";//le paso la direccion de la base de datos - es mejor usar : .\\SQLEXPRESS que lo que pusimos . //1-ubicacino 2-basedatos a conectar 3-como teconectas
            comando.CommandType = System.Data.CommandType.Text;//tipo de comando que vamos a usar, esta tipo tabla, etc.
            comando.CommandText = "Select Numero, Nombre, P.Descripcion, UrlImagen, E.Descripcion Tipo, D.Descripcion Debilidad, P.IdTipo, P.IdDebilidad, P.Id From ELEMENTOS E,POKEMONS P, ELEMENTOS D where E.Id = P.IdTipo and D.Id = P.IdDebilidad";//el comando a ejecutar, prueblo antes en un query
            comando.Connection = conexion;//conectarlo a la conexion

            conexion.Open();
            lector = comando.ExecuteReader();//le doy lo que me devuelve el lector

                while (lector.Read() == true)
                {
                    Pokemon aux = new Pokemon();
                    aux.Id = (int)lector["Id"];
                    aux.Descripcion = (string)lector["Descripcion"];
                    aux.Numero = lector.GetInt32(0);
                    aux.Nombre = (string)lector["Nombre"];

                    if (!(lector.IsDBNull(lector.GetOrdinal("UrlImagen"))))//ACA lo que pregunta, si no es nulo lo leo
                        aux.UrlImagen = (string)lector["UrlImagen"];

                   /// if (!(lector["UrlImagen"] is DBNull)) //esta es otra forma mucho mejor que es lo mismo si no es dbnull lo leo
                   ///     aux.UrlImagen = (String)lector["UrlImagen"];


                    aux.Tipo = new Elemento();
                    aux.Tipo.Id = (int)lector["IdTipo"];
                aux.Tipo.Descripcion = (string)lector["Tipo"];
                    aux.Debilidad = new Elemento();
                    aux.Debilidad.Id = (int)lector["IdDebilidad"];
                    aux.Debilidad.Descripcion = (string)lector["Debilidad"];

                    lista.Add(aux);
            }

            conexion.Close();
            return lista;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

        public void Agregar(Pokemon nuevo) 
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Insert into POKEMONS (Numero, Nombre, Descripcion, Activo, IdTipo, IdDebilidad, UrlImagen)values(" + nuevo.Numero + ",'" + nuevo.Nombre + "','" + nuevo.Descripcion + "',1, @idTipo, @idDebilidad, @urlImagen)");//el @ es un nueva forma de pasar por parametro osea que este ya va a tener un valor se le diria eso
                datos.setearParametro("@idTipo", nuevo.Tipo.Id);
                datos.setearParametro("@idDebilidad", nuevo.Debilidad.Id);//pasamos un string y un object, ahi es donde mandamos el @ puesto, ademas con el valor que tomaria.
                datos.setearParametro("@urlImagen",nuevo.UrlImagen);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void Modificar(Pokemon pokemon) 
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE POKEMONS set Numero = @numero, Nombre= @nombre,Descripcion= @descripcion,UrlImagen= @imagen, IdTipo= @idtipo, IdDebilidad = @iddebilidad Where id = @Id");
                datos.setearParametro("@numero", pokemon.Numero);
                datos.setearParametro("@nombre", pokemon.Nombre);
                datos.setearParametro("@descripcion", pokemon.Descripcion);
                datos.setearParametro("@imagen", pokemon.UrlImagen);
                datos.setearParametro("@idtipo", pokemon.Tipo.Id);
                datos.setearParametro("@iddebilidad", pokemon.Debilidad.Id);
                datos.setearParametro("@Id", pokemon.Id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<Pokemon> filtrar(string campo, string criterio, string filtro)
        {
            List<Pokemon> list = new List<Pokemon>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "Select Numero, Nombre, P.Descripcion, UrlImagen, E.Descripcion Tipo, D.Descripcion Debilidad, P.IdTipo, P.IdDebilidad, P.Id From ELEMENTOS E,POKEMONS P, ELEMENTOS D where E.Id = P.IdTipo and D.Id = P.IdDebilidad And ";//le pongo el and para despues poner la condicion
                if(campo == "Numero")
                {
                    
                    switch (criterio) 
                    {
                        case "Mayor a":
                            consulta += "Numero > " + filtro;
                            break;
                        case "Menor a":
                            consulta += "Numero < " + filtro;
                            break;
                        case "Igual a":
                            consulta += "Numero = " + filtro;
                            break;
                    }
                }
                //%dato -->termina dato$--->comienza %dato%--->contiene &&-->vacio
                else if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Numero like '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += "Numero like '%" + filtro + "'";
                            break;
                        case "Contiene":
                            consulta += "Numero like '%" + filtro + "%' ";
                            break;
                    }
                }
                else
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "P.Descripcion like '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += "P.Descripcion like '%" + filtro + "'";
                            break;
                        case "Contiene":
                            consulta += "P.Descripcion like '%" + filtro + "%' ";
                            break;
                    }
                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Pokemon aux = new Pokemon();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Numero = datos.Lector.GetInt32(0);
                    aux.Nombre = (string)datos.Lector["Nombre"];

                    if (!(datos.Lector.IsDBNull(datos.Lector.GetOrdinal("UrlImagen"))))//ACA lo que pregunta, si no es nulo lo leo
                        aux.UrlImagen = (string)datos.Lector["UrlImagen"];

                    /// if (!(lector["UrlImagen"] is DBNull)) //esta es otra forma mucho mejor que es lo mismo si no es dbnull lo leo
                    ///     aux.UrlImagen = (String)lector["UrlImagen"];


                    aux.Tipo = new Elemento();
                    aux.Tipo.Id = (int)datos.Lector["IdTipo"];
                    aux.Tipo.Descripcion = (string)datos.Lector["Tipo"];
                    aux.Debilidad = new Elemento();
                    aux.Debilidad.Id = (int)datos.Lector["IdDebilidad"];
                    aux.Debilidad.Descripcion = (string)datos.Lector["Debilidad"];

                    list.Add(aux);
                }

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void eliminar(int id)
        {
            
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from POKEMONS where id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        

}
}
