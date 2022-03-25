using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RegalosWeb.Controllers
{
    public class GestorConexion
    {
        public SqlConnection conexion;
        public void AbrirConexion()
        {
            try
            {
                conexion = new SqlConnection("Data Source=DESKTOP-E8FRIUV\\SQLEXPRESS01;Initial Catalog=Regalos;User ID=sa;Password=giandjoe");
                conexion.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en la conexión: " + e.Message);
            }
        }

        public void CerrarConexion()
        {
            try
            {
                conexion.Close();
                conexion.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al cerrar la conexión:" + e.Message);
            }
        }
    }
}