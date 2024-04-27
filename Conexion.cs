using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace SoftBase.Datos
{
    //public class clsConexion
    //{
    //    public static SqlConnection obtenerConexion()
    //    {
    //        SqlConnection cn = new SqlConnection("server =DJHO\\SQLEXPRESS ; initial catalog = Softbadase(Nuevo); integrated security = true");
    //        cn.Open();
    //        return cn;
    //    }


    //}

    public static class Conexion
    {
        public static SqlConnection obtenerconexion()
        {
            string ruta = VerificarRuta();
            SqlConnection conexion = new SqlConnection(ruta);
            conexion.Open();
            return conexion;
        }
        public static string VerificarRuta()
        {
            string ruta = "";
            try
            {
                String RutaAplicacion = Application.StartupPath + "\\";
                using (StreamReader sr = new StreamReader(RutaAplicacion + "archivo.txt"))
                {
                    while (sr.Peek() >= 0)
                    {
                        ruta = sr.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la conexion" + ex.Message);
            }
            return ruta;
        }

    }

}

