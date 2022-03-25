using RegalosWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RegalosWeb.Models
{
    public class GestorInvitado
    {
        GestorConexion gc = new GestorConexion();
        private SqlCommand comando;
        private SqlDataReader dr;
        public void AltaInvitado(Invitado nuevoInvitado)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("INSERT INTO Invitado (nombreI, idP, idTR) VALUES (@nombreI,@idP,@idTR)", gc.conexion);

                comando.Parameters.Add(new SqlParameter("@nombreI", nuevoInvitado.NombreI));
                comando.Parameters.Add(new SqlParameter("@idP", nuevoInvitado.IdP));
                comando.Parameters.Add(new SqlParameter("@idTR", nuevoInvitado.IdTR));

                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine("Ocurrió un error al insertar un Invitado: " + e.Message);
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
        public List<Pareja> cboPareja()
        {
            List<Pareja> lista = new List<Pareja>();

            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("SELECT idP, nombre1 + ' y ' + nombre2 FROM Pareja", gc.conexion);
                dr = comando.ExecuteReader();

                while (dr.Read())
                {

                    Pareja P = new Pareja();
                    P.IdP = dr.GetInt32(0);
                    P.Nombre1 = dr.GetString(1);

                    lista.Add(P);

                }

                dr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocurrió un error al mostrar las Parejas: " + e.Message);
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
        public List<TipoRelacion> cboTipoRelacion()
        {
            List<TipoRelacion> lista = new List<TipoRelacion>();

            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("SELECT * FROM TipoRelacion", gc.conexion);
                dr = comando.ExecuteReader();

                while (dr.Read())
                {

                    TipoRelacion TR = new TipoRelacion();
                    TR.IdTR = dr.GetInt32(0);
                    TR.NombreTR = dr.GetString(1);

                    lista.Add(TR);

                }

                dr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocurrió un error al mostrar los Tipos de Relación: " + e.Message);
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
        public void bajaInvitado(Invitado borrarInvitado)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("DELETE FROM Invitado WHERE idI=@idI", gc.conexion);

                comando.Parameters.Add(new SqlParameter("@idI", borrarInvitado.IdI));
                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine("Ocurrió un error al borrar un Invitado: " + e.Message);
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
        public void modificarInvitado(Invitado cambiarInvitado)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("UPDATE invitado SET nombreI=@nombreI, idP=@idP, idTR=@idTR WHERE idI=@idI", gc.conexion);

                comando.Parameters.Add(new SqlParameter("@nombreI", cambiarInvitado.NombreI));
                comando.Parameters.Add(new SqlParameter("@idP", cambiarInvitado.IdP));
                comando.Parameters.Add(new SqlParameter("@idTR", cambiarInvitado.IdTR));
                comando.Parameters.Add(new SqlParameter("@idI", cambiarInvitado.IdI));

                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine("Ocurrió un error al modificar un Invitado: " + e.Message);
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
        public List<InvitadoParejaDto> Listar()
        {
            List<InvitadoParejaDto> lista = new List<InvitadoParejaDto>();

            gc.AbrirConexion();
            comando = new SqlCommand("SELECT i.idI, i.nombreI, p.nombre1, p.nombre2, tr.nombreTR FROM Pareja p INNER JOIN invitado i ON p.idP=i.idP INNER JOIN tipoRelacion tr ON i.idTR=tr.idTR ORDER BY p.nombre1", gc.conexion);
            dr = comando.ExecuteReader();

            while (dr.Read())
            {
                int idI = dr.GetInt32(0);
                string nombreI = dr.GetString(1);
                string nombre1 = dr.GetString(2);
                string nombre2 = dr.GetString(3);
                string nombreTR = dr.GetString(4);

                InvitadoParejaDto IP = new InvitadoParejaDto(idI, nombreI, nombre1, nombre2, nombreTR);
                lista.Add(IP);
            }
            gc.CerrarConexion();
            return lista;
        }
       
    }
}