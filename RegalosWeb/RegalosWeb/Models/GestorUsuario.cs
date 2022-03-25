using RegalosWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RegalosWeb.Models
{
    public class GestorUsuario
    {
        GestorConexion gc = new GestorConexion();
        private SqlCommand comando;
        private SqlDataReader dr;
        public bool ingresoAdm(string nombreU, string contrasenia)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("SELECT nombreU, contrasenia FROM Usuario WHERE nombreU=@nombreU AND contrasenia=@contrasenia", gc.conexion);

                comando.Parameters.AddWithValue("nombreU", nombreU);
                comando.Parameters.AddWithValue("contrasenia", contrasenia);

                dr = comando.ExecuteReader();

                if (dr.Read())
                {

                    return true;
                }
                else
                {
                    Console.WriteLine("NO");
                }
                dr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocurrió un error al intentar ingresar: " + e.Message);
            }
            finally
            {
                try
                {
                    gc.CerrarConexion();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error al cerrar la conexión: " + e.Message);
                }
            }
            return false;
        }
    }
}