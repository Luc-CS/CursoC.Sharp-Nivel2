using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Policy;
using dominio;

namespace negocio
{
    public class AccesoDatos
    {
        private SqlConnection _conexion;
        private SqlCommand _comando = new SqlCommand();
        private SqlDataReader _lector;

        public SqlDataReader lector
        {
            get { return _lector; }
        }

        public AccesoDatos()
        {
            try
            {
                _conexion = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_DB; integrated security=true");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        public void setearConsulta(string consulta)
        {
            _comando.CommandType = System.Data.CommandType.Text;
            _comando.CommandText = consulta;
        }
        public void ejecutarLectura()
        {
            _comando.Connection = _conexion;

            try
            {
                _conexion.Open();
                _lector = _comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ejecutar()
        {
            _comando.Connection = _conexion;
            try
            {
                _conexion.Open();
                _comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public void setearParametro(string nombre, object valor)
        {
            _comando.Parameters.AddWithValue(nombre, valor);
        }

        public void cerrarConexion()
        {
            if (_lector != null)
            {
                _lector.Close();
                _conexion.Close();
            }
        }
    }
}
