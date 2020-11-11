using Examen.Models;
using Examen.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Examen.AccesoDatos
{
    public class AD_Examen
    {
        public static bool InsertarNuevoExamen(Examenes exa)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();

                string consulta = "INSERT INTO Examenes VALUES(@idMateria, @fecha, @nota)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idMateria", exa.idMateria);
                cmd.Parameters.AddWithValue("@fecha", exa.fecha);
                cmd.Parameters.AddWithValue("@nota", exa.nota);


                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();

                resultado = true;



            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }

            return resultado;
        }

        public static List<ExamenVM> ObtenerListaExamenes()
        {
            List<ExamenVM> resultado = new List<ExamenVM>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();

                string consulta = "select fecha, nota, nombre, nivel from examenes e inner join materias m on e.IdMateria=m.IdMateria";
                cmd.Parameters.Clear();

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        ExamenVM aux = new ExamenVM();
                        aux.fecha = (dr["fecha"].ToString());
                        aux.nota = int.Parse(dr["nota"].ToString());
                        aux.nombre = dr["nombre"].ToString();
                        aux.nivel = int.Parse(dr["nivel"].ToString());

                        resultado.Add(aux);



                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }

            return resultado;
        }

        public static List<Materia> ObtenerListaMaterias()
        {
            List<Materia> resultado = new List<Materia>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();

                string consulta = "SELECT * FROM Materias";
                cmd.Parameters.Clear();


                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        Materia aux = new Materia();
                        aux.idMateria = int.Parse(dr["idMateria"].ToString());
                        aux.nombre = dr["nombre"].ToString();
                        aux.nivel = int.Parse(dr["nivel"].ToString());




                        resultado.Add(aux);
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }

            return resultado;
        }
    }
}