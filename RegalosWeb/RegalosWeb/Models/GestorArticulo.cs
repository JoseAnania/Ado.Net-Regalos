using RegalosWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RegalosWeb.Models
{
    public class GestorArticulo
    {
        GestorConexion gc = new GestorConexion();
        private SqlCommand comando;
        private SqlDataReader dr;
        public void AltaArticulo(Articulo nuevoArticulo)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("INSERT INTO Articulo (codigoA, denominacionA, precioUnitario, idTA) VALUES (@codigoA, @denominacionA, @precioUnitario, @idTA)", gc.conexion);

                comando.Parameters.Add(new SqlParameter("@codigoA", nuevoArticulo.codigoA));
                comando.Parameters.Add(new SqlParameter("@denominacionA", nuevoArticulo.DenominacionA));
                comando.Parameters.Add(new SqlParameter("@precioUnitario", nuevoArticulo.PrecioUnitario));
                comando.Parameters.Add(new SqlParameter("@idTA", nuevoArticulo.IdTA));

                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine("Ocurrió un error al insertar un Articulo: " + e.Message);
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
        public List<TipoArticulo> cboTipoArticulo()
        {
            List<TipoArticulo> lista = new List<TipoArticulo>();

            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("SELECT * FROM TipoArticulo", gc.conexion);
                dr = comando.ExecuteReader();

                while (dr.Read())
                {

                    TipoArticulo TA = new TipoArticulo();
                    TA.IdTA = dr.GetInt32(0);
                    TA.DenominacionTA = dr.GetString(1);
                    lista.Add(TA);

                }

                dr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocurrió un error al mostrar los Tipos de Artículos: " + e.Message);
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
        public void bajaArticulo(Articulo borrarArticulo)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("DELETE FROM Articulo WHERE idA=@idA", gc.conexion);

                comando.Parameters.Add(new SqlParameter("@idA", borrarArticulo.IdA));
                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine("Ocurrió un error al borrar un Artículo: " + e.Message);
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
        public void modificarArticulo(Articulo cambiarArticulo)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("UPDATE Articulo SET codigoA=@codigoA, denominacionA=@denominacionA, precioUnitario=@precioUnitario, idTA=@idTA WHERE idA=@idA", gc.conexion);

                comando.Parameters.Add(new SqlParameter("@codigoA", cambiarArticulo.codigoA));
                comando.Parameters.Add(new SqlParameter("@denominacionA", cambiarArticulo.DenominacionA));
                comando.Parameters.Add(new SqlParameter("@precioUnitario", cambiarArticulo.PrecioUnitario));
                comando.Parameters.Add(new SqlParameter("@idTA", cambiarArticulo.IdTA));
                comando.Parameters.Add(new SqlParameter("@idA", cambiarArticulo.IdA));

                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine("Ocurrió un error al modificar un Artículo: " + e.Message);
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
        public List<ArticuloTipoDto> Listar()
        {
            List<ArticuloTipoDto> lista = new List<ArticuloTipoDto>();

            gc.AbrirConexion();
            comando = new SqlCommand("SELECT a.idA, a.codigoA, a.denominacionA, a.precioUnitario, ta.denominacionTA FROM Articulo a INNER JOIN tipoArticulo ta ON a.idTA=ta.idTA ORDER BY ta.denominacionTA", gc.conexion);
            dr = comando.ExecuteReader();

            while (dr.Read())
            {
                int idA = dr.GetInt32(0);
                string codigoA = dr.GetString(1);
                string denominacionA = dr.GetString(2);
                float precioUnitario = dr.GetFloat(3);
                string denominacionTA = dr.GetString(4);

                ArticuloTipoDto AT = new ArticuloTipoDto(idA, codigoA, denominacionA, precioUnitario, denominacionTA);
                lista.Add(AT);
            }
            gc.CerrarConexion();
            return lista;
        }

    }
}