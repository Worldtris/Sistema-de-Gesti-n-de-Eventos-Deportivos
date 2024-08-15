using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_de_Gestión_de_Eventos_Deportivos.Configuracion;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace Sistema_de_Gestión_de_Eventos_Deportivos.Modelos
{
    class EventosModel
    {

        public int evento_id {  get; set; }
        public string Nombre { get; set; }
        public string Fecha { get; set; }
        public string Ubicacion { get; set; }
        public string Descripcion { get;set; }

        List<EventosModel> listaEventos = new List<EventosModel>();

        private Conexion conexion = new Conexion();
        SqlCommand cmd = new SqlCommand();

        public List<EventosModel> todos ()
        {
            string cadena = "select * from evento";
            SqlDataAdapter adapter = new SqlDataAdapter(cadena, conexion.abrirConexion());
            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            foreach (DataRow evento in tabla.Rows)
            {
                EventosModel eventos = new EventosModel()
                {
                    evento_id = Convert.ToInt32(evento["evento_id"]),
                    Nombre = evento["Nombre"].ToString(),
                    Fecha = evento["Fecha"].ToString(),
                    Ubicacion = evento["Ubicacion"].ToString(),
                    Descripcion = evento["Descripcion"].ToString(),
                };
                listaEventos.Add(eventos);
            }
            conexion.cerrarConexion();
            return listaEventos;
        }

        public EventosModel uno(EventosModel eventos)
        {
            string cadena = "select * from evento where evento_id=" + eventos.evento_id;
            cmd = new SqlCommand(cadena, conexion.abrirConexion());
            SqlDataReader lector = cmd.ExecuteReader();

            lector.Read();
            EventosModel eventoRegresa = new EventosModel()
            {
                evento_id = Convert.ToInt32(lector["evento_id"]),
                Nombre = lector["Nombre"].ToString(),
                Fecha = lector["Fecha"].ToString(),
                Ubicacion = lector["Ubicacion"].ToString(),
                Descripcion = lector["Descripcion"].ToString(),
            };
            conexion.cerrarConexion();
            return eventoRegresa;
        }

        public string insertar(EventosModel evento)
        {
            try
            {
                cmd.Connection = conexion.abrirConexion();
                cmd.CommandText = "insert into evento(Nombre) values('" + evento.Nombre + "')";
                cmd.ExecuteNonQuery();
                return "ok";

            }
            catch(Exception ex) 
            {
                return "error: " + ex.Message;

            }
            finally
            {
                conexion.cerrarConexion();
            }

        }

        public string actualizar(EventosModel evento)
        {
            try
            {
                cmd.Connection = conexion.abrirConexion();
                cmd.CommandText = "update evento set detalle='" + evento.Nombre + "' where evento_id=" + evento.evento_id;
                cmd.ExecuteNonQuery();
                return "ok";

            }
            catch (Exception ex)
            {
                return "error: " + ex.Message;

            }
            finally
            {
                conexion.cerrarConexion();
            }
        }

        public string eliminar(EventosModel evento)
        {
            try
            {
                cmd.Connection = conexion.abrirConexion();
                cmd.CommandText = "Delete from Evento where evento_id=" + evento.evento_id;
                cmd.ExecuteNonQuery();
                return "ok";

            }
            catch (Exception ex)
            {
                return "error: " + ex.Message;

            }
            finally
            {
                conexion.cerrarConexion();
            }


        }
    }
}
