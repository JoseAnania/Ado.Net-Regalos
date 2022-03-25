using RegalosWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RegalosWeb.Models
{
    public class GestorPareja
    {
        GestorConexion gc = new GestorConexion();
        private SqlCommand comando;
        private SqlDataReader dr;
        public void AltaPareja(Pareja nuevaPareja)
        {           
            try
            {
                gc.AbrirConexion();
                comando=new SqlCommand("INSERT INTO Pareja (nombre1, apellido1, nombre2, apellido2, fechaCasamiento, idC) VALUES (@nombre1, @apellido1, @nombre2, @apellido2, @fechaCasamiento, @idC)", gc.conexion);

                comando.Parameters.Add(new SqlParameter("@nombre1", nuevaPareja.Nombre1));
                comando.Parameters.Add(new SqlParameter("@apellido1", nuevaPareja.Apellido1));
                comando.Parameters.Add(new SqlParameter("@nombre2", nuevaPareja.Nombre2));
                comando.Parameters.Add(new SqlParameter("@apellido2", nuevaPareja.Apellido2));
                comando.Parameters.Add(new SqlParameter("@fechaCasamiento", nuevaPareja.FechaCasamiento));
                comando.Parameters.Add(new SqlParameter("@idC", nuevaPareja.IdC));

                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine("Ocurrió un error al insertar una Pareja: " + e.Message);
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
        }
        public List<Comercio> cboComercio()
        {
            List<Comercio> lista = new List<Comercio>();

            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("SELECT * FROM Comercio", gc.conexion);
                dr = comando.ExecuteReader();

                while (dr.Read())
                {

                    Comercio C = new Comercio();
                    C.IdC = dr.GetInt32(0);
                    C.DenominacionC = dr.GetString(1);
                    lista.Add(C);

                }

                dr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocurrió un error al mostrar los Comercios: " + e.Message);
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

            return lista;
        }
        public void bajaPareja(Pareja borrarPareja)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("DELETE FROM pareja WHERE idP=@idP",gc.conexion);

                comando.Parameters.Add(new SqlParameter("@idP", borrarPareja.IdP));
                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine("Ocurrió un error al borrar una Pareja: " + e.Message);
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
        }
        public void modificarPareja(Pareja cambiarPareja)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("UPDATE Pareja SET nombre1=@nombre1, apellido1=@apellido1, nombre2=@nombre2, apellido2=@apellido2, fechaCasamiento=@fechaCasamiento, idC=@idC WHERE idP=@idP", gc.conexion);

                comando.Parameters.Add(new SqlParameter("@nombre1", cambiarPareja.Nombre1));
                comando.Parameters.Add(new SqlParameter("@apellido1", cambiarPareja.Apellido1));
                comando.Parameters.Add(new SqlParameter("@nombre2", cambiarPareja.Nombre2));
                comando.Parameters.Add(new SqlParameter("@apellido2", cambiarPareja.Apellido2));
                comando.Parameters.Add(new SqlParameter("@fechaCasamiento", cambiarPareja.FechaCasamiento));
                comando.Parameters.Add(new SqlParameter("@idC", cambiarPareja.IdC));
                comando.Parameters.Add(new SqlParameter("@idP", cambiarPareja.IdP));

                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine("Ocurrió un error al modificar una Pareja: " + e.Message);
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
        }
        public List<ParejaComercioDto> Listar()
        {
            List<ParejaComercioDto> lista = new List<ParejaComercioDto>();

            gc.AbrirConexion();
            comando = new SqlCommand("SELECT p.idP, p.nombre1, p.apellido1, p.nombre2, p.apellido2, p.fechaCasamiento, c.denominacionC FROM Pareja p INNER JOIN Comercio c ON p.idC=c.idC ORDER BY c.denominacionC", gc.conexion);
            dr = comando.ExecuteReader();

            while (dr.Read())
            {
                int idP = dr.GetInt32(0);
                string nombre1 = dr.GetString(1);
                string apellido1 = dr.GetString(2);
                string nombre2 = dr.GetString(3);
                string apellido2= dr.GetString(4);
                string fechaCasamiento = dr.GetDateTime(5).ToShortDateString();
                string denominacionC = dr.GetString(6);

                ParejaComercioDto PC = new ParejaComercioDto(idP, nombre1, apellido1, nombre2, apellido2, fechaCasamiento, denominacionC);
                lista.Add(PC);
            }
            gc.CerrarConexion();
            return lista;
        }
        public int numeroPareja(int numeroP)
        {
            int idP=0;

            try
            {

                gc.AbrirConexion();
                comando = new SqlCommand("SELECT idP FROM Pareja WHERE idP like " + numeroP, gc.conexion);
                dr = comando.ExecuteReader();

                dr.Read();
                
                   idP = dr.GetInt32(0);
                

            }
            catch (Exception e)
            {
                Console.WriteLine("Ocurrió un error al obtener el número de la Pareja: " + e.Message);
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
            return idP;
        }
    }
}