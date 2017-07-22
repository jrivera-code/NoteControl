using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteControl.Datos
{
    public class Conexion
    {
        private SqlConnection myConnection;
        string cadenaConexion;

        public void Conectar()
        {
            cadenaConexion = @"Data Source=DESKTOP-16VNQA4;Initial Catalog=Note_Control;Integrated Security=True";
            this.myConnection = new SqlConnection(cadenaConexion);
            this.myConnection.Open();
        }
        public void Desconectar()
        {
            this.myConnection.Close();
        }
        public SqlConnection getConexion()
        {
           return this.myConnection;
        }
    }
}
