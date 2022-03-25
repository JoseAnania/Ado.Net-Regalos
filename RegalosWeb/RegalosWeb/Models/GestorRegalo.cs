using RegalosWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RegalosWeb.Models
{
    public class GestorRegalo
    {
        GestorConexion gc = new GestorConexion();
        private SqlCommand comando;
        private SqlDataReader dr;
        public void AltaRegalo(Regalo nuevoRegalo)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("INSERT INTO Regalo (idP, idA, idI, cantidad, regalado) VALUES (@idP,@idA,NULL,0,0)", gc.conexion);

                comando.Parameters.Add(new SqlParameter("@idP", nuevoRegalo.IdP));
                comando.Parameters.Add(new SqlParameter("@idA", nuevoRegalo.IdA));

                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine("Ocurrió un error al insertar un Regalo: " + e.Message);
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
        public List<RegaloDto> Listar(int numeroP)
        {

            List<RegaloDto> lista = new List<RegaloDto>();

            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("SELECT a.denominacionA, r.idA, r.idP FROM Regalo r INNER JOIN Articulo a ON r.idA=a.idA WHERE regalado=0 and idP=" + numeroP + "", gc.conexion);
                dr = comando.ExecuteReader();
                while (dr.Read())
                {

                    RegaloDto R = new RegaloDto();

                    R.DenominacionA = dr.GetString(0);
                    R.IdA = dr.GetInt32(1);
                    R.IdP = dr.GetInt32(2);

                    lista.Add(R);
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocurrió un error al mostrar la Lista: " + e.Message);
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
        public void nuevoRegalo(Regalo nuevoRegalo)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("UPDATE Regalo SET idI=?, cantidad=?, regalado=1 WHERE idR=?", gc.conexion);

                comando.Parameters.Add(new SqlParameter("idI", nuevoRegalo.IdI));
                comando.Parameters.Add(new SqlParameter("cantidad", nuevoRegalo.Cantidad));
                comando.Parameters.Add(new SqlParameter("idR", nuevoRegalo.IdR));

                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine("Ocurrió un error al modificar una Regalo: " + e.Message);
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
        public List<Invitado> InvitadoPorPareja(int numeroP)
        {
            List<Invitado> lista = new List<Invitado>();

            try
            {

                gc.AbrirConexion();
                comando = new SqlCommand("SELECT * FROM Invitado WHERE idP=" + numeroP + "", gc.conexion);
                dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    Invitado I = new Invitado();

                    int idI = dr.GetInt32(0);
                    string nombreI = dr.GetString(1);
                    int idP = dr.GetInt32(2);
                    int idTR = dr.GetInt32(3);

                    lista.Add(I);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocurrió un error al mostrar el Invitado: " + e.Message);
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
        public List<RegaloDto> ArticuloPorPareja(int numeroPareja)
        {
            List<RegaloDto> lista = new List<RegaloDto>();

            try
            {

                gc.AbrirConexion();
                comando = new SqlCommand("SELECT r.idR, a.denominacionA FROM Regalo r INNER JOIN Articulo a ON r.idA=a.idA WHERE idP=" + numeroPareja, gc.conexion);

                dr = comando.ExecuteReader();

                while (dr.Read())
                {
                    RegaloDto R = new RegaloDto();

                    int idR = dr.GetInt32(0);
                    string denominacionA = dr.GetString(1);

                    lista.Add(R);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocurrió un error al mostrar el Regalo: " + e.Message);
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
        public List<Invitado> cboInvitado()
        {
            List<Invitado> lista = new List<Invitado>();

            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("SELECT idI, nombreI FROM Invitado", gc.conexion);
                dr = comando.ExecuteReader();

                while (dr.Read())
                {

                    Invitado I = new Invitado();
                    I.IdI = dr.GetInt32(0);
                    I.NombreI = dr.GetString(1);
                    lista.Add(I);

                }

                dr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocurrió un error al mostrar los Invitados: " + e.Message);
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
    }
}