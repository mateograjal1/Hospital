using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital.Logica
{
    public static class ConexionDB
    {
        private const string STRING_DE_CONEXION = "Data Source=localhost;Initial Catalog=Hospital;Integrated Security=True";

        

        private static SqlCommand comando;
        private static SqlConnection conexion;
        private static SqlDataReader lector;

        private static bool AbrirConexion()
        {
            conexion = new SqlConnection(STRING_DE_CONEXION);
            try
            {
                conexion.Open();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(null, e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static DataTable EjecutarProcedimiento(string procedimiento, params object[] parametros)
        {
            Debug.WriteLine("Ejecutando procedimiento almacenado " + procedimiento + " con " + parametros.Length / 2 + " parametros");
            if (AbrirConexion())
            {
                try
                {
                    comando = new SqlCommand(procedimiento, conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < parametros.Length; i += 2)
                    {
                        comando.Parameters.AddWithValue((string)parametros[i], parametros[i + 1]);
                    }
                    comando.ExecuteNonQuery();
                    lector = comando.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(lector);
                    Debug.WriteLine("Procedimiento " + procedimiento + " ejecutado correctament");
                    return dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(null, "Ocurrio un error conectando con la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Debug.WriteLine("Error ejecutando procedimiento " + procedimiento + ": " + ex.Message);
                    return null;
                }
            }
            return null;
        }
    }
}
