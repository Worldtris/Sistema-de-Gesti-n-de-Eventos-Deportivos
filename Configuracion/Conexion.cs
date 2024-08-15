using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Sistema_de_Gestión_de_Eventos_Deportivos.Configuracion
{
    class Conexion
    {
        private SqlConnection con = new SqlConnection("Server=.;database=Sistema de Gestión de Eventos Deportivos;uid=sa;pwd=1234");

        public SqlConnection abrirConexion()
        {
            if(con.State == ConnectionState.Closed)
                con.Open();
            return con;

        }

        public SqlConnection cerrarConexion()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            return con;
        }

    }
}
