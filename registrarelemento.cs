using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftBadase.Entidades;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;


namespace SoftBase.Datos
{
   public class ClsDatosRegistrarMovimientoDeElementos
   {
      public static  List<ClsEntidadesRegistrarMovimientoDeElementos> PersonasConElemento()
        {
            List<ClsEntidadesRegistrarMovimientoDeElementos> obtener = new List<ClsEntidadesRegistrarMovimientoDeElementos>();
            SqlConnection cn = clsConexion.obtenerConexion();
            try
            {
                string Ver = "SELECT Tbl_RegistrarPersona.Cedula, Nombres,Primer_Apellido, Elemento, Serie_Del_Elemento, Descripcion, EstadoRegistro FROM Tbl_RegistrarElemento inner join Tbl_RegistrarPersona on Tbl_RegistrarElemento.Cedula=Tbl_RegistrarPersona.Cedula";
                SqlCommand cmd = new SqlCommand(Ver, cn);
                SqlDataReader rd = cmd.ExecuteReader();
                while(rd.Read())
                {
                    ClsEntidadesRegistrarMovimientoDeElementos BD = new ClsEntidadesRegistrarMovimientoDeElementos();
                    BD.Cedula = rd[0].ToString();
                    BD.Nombres = rd[1].ToString();
                    BD.PrimerApellido = rd[2].ToString();
                    BD.Elemento = rd[3].ToString();
                    BD.SerieDelElemento = rd[4].ToString();
                    BD.Descripcion = rd[5].ToString();
                    BD.Estado = rd[6].ToString();
                    obtener.Add(BD);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar a las personas con elementos "+ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return obtener;
        }
        public static List<ClsEntidadesRegistrarMovimientoDeElementos> EstadoDelElemento(string Estado)
        {
            List<ClsEntidadesRegistrarMovimientoDeElementos> obtener = new List<ClsEntidadesRegistrarMovimientoDeElementos>();
            SqlConnection cn = clsConexion.obtenerConexion();
            try
            {
                string ver = "Select Cedula,Nombres,PrimerApellido,Elemento,SerieElemento,Estado,Fecha,Hora from Tbl_MovimientosDeElementosRegistrosSoftbadase where Estado=@Estado";
                SqlCommand cmd = new SqlCommand(ver, cn);
                cmd.Parameters.AddWithValue("@Estado", Estado);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    ClsEntidadesRegistrarMovimientoDeElementos db = new ClsEntidadesRegistrarMovimientoDeElementos();
                    db.Cedula = rd[0].ToString();
                    db.Nombres = rd[1].ToString();
                    db.PrimerApellido = rd[2].ToString();
                    db.Elemento = rd[3].ToString();
                    db.SerieDelElemento = rd[4].ToString();
                    db.Estado = rd[5].ToString();
                    db.Fecha = rd[6].ToString();
                    db.Hora = rd[7].ToString();
                    obtener.Add(db);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al buscar el estado del elemento "+ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return obtener;
        }
        public static List<ClsEntidadesRegistrarMovimientoDeElementos> EstadoDelElementoDia(string dia)
        {
            List<ClsEntidadesRegistrarMovimientoDeElementos> obtener = new List<ClsEntidadesRegistrarMovimientoDeElementos>();
            SqlConnection cn = clsConexion.obtenerConexion();
            try
            {
                string ver = "Select Cedula,Nombres,PrimerApellido,Elemento,SerieElemento,Estado,Fecha,Hora from Tbl_MovimientosDeElementosRegistrosSoftbadase where Fecha=@Fecha";
                SqlCommand cmd = new SqlCommand(ver, cn);
                cmd.Parameters.AddWithValue("@Fecha",Convert.ToDateTime(dia));
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    ClsEntidadesRegistrarMovimientoDeElementos db = new ClsEntidadesRegistrarMovimientoDeElementos();
                    db.Cedula = rd[0].ToString();
                    db.Nombres = rd[1].ToString();
                    db.PrimerApellido = rd[2].ToString();
                    db.Elemento = rd[3].ToString();
                    db.SerieDelElemento = rd[4].ToString();
                    db.Estado = rd[5].ToString();
                    db.Fecha = rd[6].ToString();
                    db.Hora = rd[7].ToString();
                    obtener.Add(db);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al buscar el estado del elemento " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return obtener;
        }
        public static ClsEntidadesRegistrarMovimientoDeElementos ConsultarElemento(string Consultar)
        {
            ClsEntidadesRegistrarMovimientoDeElementos Consul = new ClsEntidadesRegistrarMovimientoDeElementos();
            SqlConnection cn = clsConexion.obtenerConexion();
            try
            {
                string Consulta = "SELECT Cedula,Nombres,Primer_Apellido,Segundo_Apellido FROM Tbl_RegistrarPersona WHERE Cedula=@Cedula";
                SqlCommand cmd = new SqlCommand(Consulta, cn);
                cmd.Parameters.AddWithValue("@Cedula", Consultar);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    Consul.Cedula = rd[0].ToString();
                    Consul.Nombres = rd[1].ToString();
                    Consul.PrimerApellido = rd[2].ToString();
                    Consul.SegundoApellido = rd[3].ToString();
                    

                    
                    
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error"+ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return Consul;
        }
        public static ClsEntidadesRegistrarMovimientoDeElementos ConsultarElemento2(string Consultar)
        {
            ClsEntidadesRegistrarMovimientoDeElementos Consul = new ClsEntidadesRegistrarMovimientoDeElementos();
            SqlConnection cn = clsConexion.obtenerConexion();
            try
            {
                string Consulta = "SELECT Cedula,Elemento,SeriDelElemento,Descripcion FROM Tbl_RegistrarElementoInstructoresEmpleadores WHERE Cedula=@Cedula";
                SqlCommand cmd = new SqlCommand(Consulta, cn);
                cmd.Parameters.AddWithValue("@Cedula", Consultar);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    Consul.Cedula = rd[0].ToString();
                    Consul.Elemento = rd[1].ToString();
                    Consul.SerieDelElemento = rd[2].ToString();
                    Consul.Descripcion = rd[3].ToString();
                    
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error" + ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return Consul;
        }
        public static List<ClsEntidadesRegistrarMovimientoDeElementos> ConsultarElementosPES(string consultar)
        {
            List<ClsEntidadesRegistrarMovimientoDeElementos> ConsultarElementosPES = new List<ClsEntidadesRegistrarMovimientoDeElementos>();
            SqlConnection cn = clsConexion.obtenerConexion();
            try
            {
                string ConsultarEntradaOSalida = "Select * from Tbl_RegistrarElemento WHERE Cedula = @Cedula";
                SqlCommand cmd = new SqlCommand(ConsultarEntradaOSalida, cn);
                cmd.Parameters.AddWithValue("@Cedula", consultar);

                SqlDataReader rd = cmd.ExecuteReader();
                while(rd.Read())
                {
                  
                    ConsultarElementosPES.Add(AgregarInformacion(rd));
                }
            }
            catch (Exception e)
            {

                MessageBox.Show("Error De Consultar En El DataGri" + e.Message);
            }
            finally
            {
                cn.Close();
            }
            return ConsultarElementosPES;    
        }

        public static ClsEntidadesRegistrarMovimientoDeElementos AgregarInformacion(IDataReader rd)
        {
            ClsEntidadesRegistrarMovimientoDeElementos consultar = new ClsEntidadesRegistrarMovimientoDeElementos();

            consultar.Cedula = rd[0].ToString();
            consultar.Elemento = rd[1].ToString();
            consultar.SerieDelElemento = rd[2].ToString();
            consultar.Descripcion = rd[3].ToString();
            consultar.Estado = rd[4].ToString();
            
            
            return consultar; 
        }
        public static string TraerRegistro(string traer, string id)
        {
            SqlConnection cn = clsConexion.obtenerConexion();
            string Estado = "";
            try
            {
                string saber = "Select EstadoRegistro from Tbl_RegistrarElemento where Cedula=@Cedula and Serie_Del_Elemento=@Serie";
                SqlCommand cmd = new SqlCommand(saber,cn);
                cmd.Parameters.AddWithValue("@Cedula",traer);
                cmd.Parameters.AddWithValue("@Serie", id);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    Estado = rd[0].ToString();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al buscar el estado del elemento "+ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return Estado;
        }
        public static string TraerRegistroeleIns(string traer, string id)
        {
            SqlConnection cn = clsConexion.obtenerConexion();
            string Estado = "";
            try
            {
                string saber = "Select Estado from Tbl_RegistrarElementoInstructoresEmpleadores where Cedula=@Cedula and SeriDelElemento=@Serie";
                SqlCommand cmd = new SqlCommand(saber, cn);
                cmd.Parameters.AddWithValue("@Cedula", traer);
                cmd.Parameters.AddWithValue("@Serie", id);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    Estado = rd[0].ToString();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al buscar el estado del elemento " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return Estado;
        }
        public static bool ActualizarEstado(ClsEntidadesRegistrarMovimientoDeElementos Act)
        {
            bool rsp = false;
            SqlConnection cn = clsConexion.obtenerConexion();
            try
            {
                string actualizar = "update Tbl_RegistrarElemento set EstadoRegistro=@EstadoRegistro where Cedula=@Cedula AND Serie_Del_Elemento=@Serie";
                SqlCommand cmd = new SqlCommand(actualizar,cn);
                cmd.Parameters.AddWithValue("@EstadoRegistro",Act.Estado);
                cmd.Parameters.AddWithValue("@Cedula", Act.Cedula);
                cmd.Parameters.AddWithValue("@Serie", Act.SerieDelElemento);
                
                if (cmd.ExecuteNonQuery() > 0)
                {
                    rsp = true;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al cambiar el estado del elemento "+ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return rsp;
        }
        public static bool ActualizarEstado2(ClsEntidadesRegistrarMovimientoDeElementos Act)
        {
            bool rsp = false;
            SqlConnection cn = clsConexion.obtenerConexion();
            try
            {
                string actualizar = "update Tbl_RegistrarElementoInstructoresEmpleadores set Estado=@EstadoRegistro where Cedula=@Cedula AND SeriDelElemento=@Serie";
                SqlCommand cmd = new SqlCommand(actualizar, cn);
                cmd.Parameters.AddWithValue("@EstadoRegistro", Act.Estado);
                cmd.Parameters.AddWithValue("@Cedula", Act.Cedula);
                cmd.Parameters.AddWithValue("@Serie", Act.SerieDelElemento);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    rsp = true;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al cambiar el estado del elemento " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return rsp;
        }
        public static bool GuardarEstado(ClsEntidadesRegistrarMovimientoDeElementos guardar)
        {
            bool rsp = true;
            SqlConnection cn = clsConexion.obtenerConexion();
            try
            {
                string Enviar = "insert into Tbl_MovimientosDeElementosRegistrosSoftbadase (Cedula,Nombres,PrimerApellido,SegundoApellido,Elemento,SerieElemento,Descripcion,Fecha,Hora,Estado) values (@Cedula,@Nombres,@PrimerApellido,@SegundoApellido,@Elemento,@SerieElemento,@Descripcion,@Fecha,@Hora,@Estado)";
                SqlCommand cmd = new SqlCommand(Enviar, cn);
                cmd.Parameters.AddWithValue("@Cedula", guardar.Cedula);
                cmd.Parameters.AddWithValue("@Nombres", guardar.Nombres);
                cmd.Parameters.AddWithValue("@PrimerApellido", guardar.PrimerApellido);
                cmd.Parameters.AddWithValue("@SegundoApellido", guardar.SegundoApellido);
                cmd.Parameters.AddWithValue("@Elemento", guardar.Elemento);
                cmd.Parameters.AddWithValue("@SerieElemento", guardar.SerieDelElemento);
                cmd.Parameters.AddWithValue("@Descripcion", guardar.Descripcion);
                cmd.Parameters.AddWithValue("@Fecha", Convert.ToDateTime(guardar.Fecha));
                cmd.Parameters.AddWithValue("@Hora", Convert.ToDateTime(guardar.Hora));
                cmd.Parameters.AddWithValue("@Estado", guardar.Estado);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    rsp = true;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al guardar el dato de entrada o salida "+ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return rsp;
        }
        public static bool GuardarEstado2(ClsEntidadesRegistrarMovimientoDeElementos guardar)
        {
            bool rsp = true;
            SqlConnection cn = clsConexion.obtenerConexion();
            try
            {
                string Enviar = "insert into Tbl_MovimientosDeElementosRegistrosSoftbadaseInstructoresEmple (Cedula,Elemento,SerieElemento,Descripcion,FechaRegistro,HoraRegistro,Estado) values (@Cedula,@Elemento,@SerieElemento,@Descripcion,@Fecha,@Hora,@Estado)";
                SqlCommand cmd = new SqlCommand(Enviar, cn);
                cmd.Parameters.AddWithValue("@Cedula", guardar.Cedula);
                cmd.Parameters.AddWithValue("@Elemento", guardar.Elemento);
                cmd.Parameters.AddWithValue("@SerieElemento", guardar.SerieDelElemento);
                cmd.Parameters.AddWithValue("@Descripcion", guardar.Descripcion);
                cmd.Parameters.AddWithValue("@Fecha", Convert.ToDateTime(guardar.Fecha));
                cmd.Parameters.AddWithValue("@Hora", Convert.ToDateTime(guardar.Hora));
                cmd.Parameters.AddWithValue("@Estado", guardar.Estado);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    rsp = true;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al guardar el dato de entrada o salida " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return rsp;
        }
       
        
   }
}
