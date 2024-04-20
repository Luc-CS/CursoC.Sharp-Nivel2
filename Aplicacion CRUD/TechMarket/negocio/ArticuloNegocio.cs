using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;

namespace negocio
{
    public class ArticuloNegocio
    {
        private AccesoDatos accesoDatos = new AccesoDatos();

        public List<Articulo> ListarArticulos()
        {
            List<Articulo> listaArticulos = new List<Articulo>();
            accesoDatos.setearConsulta("select art.id, art.Codigo,art.Nombre ,art.Descripcion,art.Precio,art.ImagenUrl,mrc.Descripcion as marca,cat.Descripcion as categoria,mrc.id as mrcid,cat.id as catid from ARTICULOS art,MARCAS mrc, CATEGORIAS cat where art.IdCategoria=cat.Id and art.IdMarca=mrc.Id ");
            accesoDatos.ejecutarLectura();

            try
            {
                while(accesoDatos.lector.Read() != false)
                {
                    Articulo aux = new Articulo();
                    aux.marca = new Marca();
                    aux.categoria = new Categoria();
                    aux._Id = (int)accesoDatos.lector["Id"];
                    aux.Codigo = (string)accesoDatos.lector["Codigo"];
                    aux._Descripcion = (string)accesoDatos.lector["Descripcion"];
                    aux.Precio = (decimal)accesoDatos.lector["Precio"];
                    string precioFormateado = aux.Precio.ToString("#,####.00##");
                    aux.Precio = decimal.Parse(precioFormateado);
                    aux.marca._Id = (int)accesoDatos.lector["mrcid"];
                    aux.categoria._Id = (int)accesoDatos.lector["catid"];
                    aux.categoria._Descripcion = (string)accesoDatos.lector["categoria"];
                    aux.marca._Descripcion = (string)accesoDatos.lector["marca"];
                    aux.Nombre = (string)accesoDatos.lector["Nombre"];
                    if (!(accesoDatos.lector["ImagenUrl"] is DBNull))
                        aux._imagenUrl = (string)accesoDatos.lector["ImagenUrl"];




                    listaArticulos.Add(aux);



                }

                return listaArticulos;


            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

        public void EliminarArticulo(int id)
        {
            try
            {
                accesoDatos.setearConsulta("delete from Articulos where id=" + id + "");

                accesoDatos.ejecutar();

            }
            catch (Exception ex) { throw ex; }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

        public void agregarArticulo(Articulo art)
        {
            try
            {  //SI LE PASO TODOS ASI POR PARAMENTRO  ME PUEDO LLEGAR A AHORRAR VALIDACION DE SI ESTA VACIO EN ALGUNOS CASOS/ NO ME DEJA MANDARLE NULL SINO TIENE NADA POR PARAMETROS DEL COMANDO
                accesoDatos.setearConsulta("insert into ARTICULOS(Codigo,Nombre,Descripcion,IdMarca,IdCategoria,ImagenUrl,Precio) values (@codigo,@nombre,@descripcion,@idMarca,@idCat,'" + art._imagenUrl + "',@precio)");
                accesoDatos.setearParametro("@nombre", art.Nombre);
                accesoDatos.setearParametro("@codigo", art.Codigo);
                accesoDatos.setearParametro("@descripcion", art._Descripcion);
                accesoDatos.setearParametro("@precio", art.Precio);
                // accesoDatos.setearParametro("@imagen", art._imagenUrl);
                accesoDatos.setearParametro("@idMarca", art.marca._Id);
                accesoDatos.setearParametro("@idCat", art.categoria._Id);
                accesoDatos.ejecutar();


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

        public void modificarArticulo(Articulo art)
        {
            try
            {
                accesoDatos.setearConsulta("update  ARTICULOS set Codigo=@codigo,Nombre=@nombre,Descripcion=@descripcion,IdMarca=@idMarca,IdCategoria=@idCat,ImagenUrl='" + art._imagenUrl + "',Precio=@precio where id=" + art._Id + "");
                accesoDatos.setearParametro("@nombre", art.Nombre);
                accesoDatos.setearParametro("@codigo", art.Codigo);
                accesoDatos.setearParametro("@descripcion", art._Descripcion);
                accesoDatos.setearParametro("@precio", art.Precio);
                accesoDatos.setearParametro("@imagen", art._imagenUrl);
                accesoDatos.setearParametro("@idMarca", art.marca._Id);
                accesoDatos.setearParametro("@idCat", art.categoria._Id);
                accesoDatos.ejecutar();
            }
            catch (Exception ex) { throw ex; }
            finally { accesoDatos.cerrarConexion(); }

        }

        public List<Articulo> BuscadaFiltrada(string campo, string criterio, string filtro)
        {

            List<Articulo> listaAux = new List<Articulo>();

            string query = "select art.id, art.Codigo,art.Nombre ,art.Descripcion,art.Precio,art.ImagenUrl,mrc.Descripcion as marca,cat.Descripcion as categoria,mrc.id as mrcid,cat.id as catid from ARTICULOS art,MARCAS mrc, CATEGORIAS cat where art.IdCategoria=cat.Id and art.IdMarca=mrc.Id";
            try
            {
                switch (campo)
                {

                    case "PRECIO":

                        switch (criterio)
                        {
                            case "MAYOR A":

                                query += " AND art.Precio > " + filtro + "";

                                break;

                            case "MENOR A":
                                query += " AND art.Precio < " + filtro + "";

                                break;

                            case "IGUAL A":
                                query += " AND art.Precio = " + filtro + "";

                                break;

                        }

                        break;

                    case "NOMBRE":


                        switch (criterio)
                        {
                            case "COMIENZA CON":

                                query += " and art.nombre like '" + filtro + "%' ";

                                break;

                            case "TERMINA CON":
                                query += " and art.nombre like '%" + filtro + "' ";

                                break;

                            case "CONTIENE":

                                query += " and art.nombre like '%" + filtro + "%' ";
                                break;

                        }

                        break;

                    case "CODIGO":

                        switch (criterio)
                        {
                            case "COMIENZA CON":

                                query += " and art.codigo like '" + filtro + "%' ";

                                break;

                            case "TERMINA CON":
                                query += " and art.codigo like '%" + filtro + "' ";

                                break;

                            case "CONTIENE":

                                query += " and art.codigo like '%" + filtro + "%' ";
                                break;

                        }
                        break;

                    case "CATEGORIA":


                        query += " and cat.Descripcion = '" + criterio + "'";

                        break;

                    case "MARCA":
                        query += " and mrc.Descripcion = '" + criterio + "'";
                        break;




                }


                //TENGO QUE VALIDAR EL DBNULL
                accesoDatos.setearConsulta(query);
                accesoDatos.ejecutarLectura();

                while (accesoDatos.lector.Read() != false)
                {
                    Articulo aux = new Articulo();
                    aux._Id = (int)accesoDatos.lector["Id"];
                    aux.marca = new Marca();
                    aux.categoria = new Categoria();
                    aux.Codigo = (string)accesoDatos.lector["Codigo"];
                    aux._Descripcion = (string)accesoDatos.lector["Descripcion"];
                    aux.Precio = (decimal)accesoDatos.lector["Precio"];
                    string precioFormateado = aux.Precio.ToString("#,####.00##");
                    aux.Precio = decimal.Parse(precioFormateado);
                    aux.marca._Id = (int)accesoDatos.lector["mrcid"];
                    aux.categoria._Id = (int)accesoDatos.lector["catid"];
                    aux.categoria._Descripcion = (string)accesoDatos.lector["categoria"];
                    aux.marca._Descripcion = (string)accesoDatos.lector["marca"];
                    aux.Nombre = (string)accesoDatos.lector["Nombre"];
                    if (!(accesoDatos.lector["ImagenUrl"] is DBNull))
                        aux._imagenUrl = (string)accesoDatos.lector["ImagenUrl"];




                    listaAux.Add(aux);



                }

                return listaAux;

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
