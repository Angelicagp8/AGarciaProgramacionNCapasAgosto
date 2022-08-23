using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BL
{
    public class Alumno
    {
        public static ML.Result Add(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using(SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    string query = "INSERT INTO [Alumno]([Nombre],[ApellidoPaterno],[ApellidoMaterno],[Sexo],[Email])VALUES(@Nombre,@ApellidoPaterno,@ApellidoMaterno,@Sexo,@Email)";

                    using(SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;

                        SqlParameter[] collection = new SqlParameter[5];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = alumno.Nombre;

                        collection[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[1].Value = alumno.ApellidoPaterno;

                        collection[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[2].Value = alumno.ApellidoMaterno;

                        collection[3] = new SqlParameter("Sexo", SqlDbType.Char);
                        collection[3].Value = alumno.Sexo;

                        collection[4] = new SqlParameter("Email", SqlDbType.VarChar);
                        collection[4].Value = alumno.Email;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();
                        if(RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static ML.Result Update(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using(SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    string query = "UPDATE [Alumno]SET [Nombre] = @Nombre,[ApellidoPaterno] = @ApellidoPaterno,[ApellidoMaterno] = @ApellidoMaterno,[Sexo] = @Sexo,[Email] = @Email WHERE IdAlumno=@IdAlumno";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;


                        SqlParameter[] collection = new SqlParameter[6];

                        collection[0] = new SqlParameter("IdAlumno", SqlDbType.Int);
                        collection[0].Value = alumno.IdAlumno;

                        collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[1].Value = alumno.Nombre;

                        collection[2] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[2].Value = alumno.ApellidoPaterno;

                        collection[3] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[3].Value = alumno.ApellidoMaterno;

                        collection[4] = new SqlParameter("Sexo", SqlDbType.Char);
                        collection[4].Value = alumno.Sexo;

                        collection[5] = new SqlParameter("Email", SqlDbType.VarChar);
                        collection[5].Value = alumno.Email;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if(RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result AddSP(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    string query = "AlumnoAdd"; //Nombre del SP
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure; //Trabajar con SP

                        SqlParameter[] collection = new SqlParameter[5];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = alumno.Nombre;

                        collection[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[1].Value = alumno.ApellidoPaterno;

                        collection[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[2].Value = alumno.ApellidoMaterno;

                        collection[3] = new SqlParameter("Sexo", SqlDbType.Char);
                        collection[3].Value = alumno.Sexo;

                        collection[4] = new SqlParameter("Email", SqlDbType.VarChar);
                        collection[4].Value = alumno.Email;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();
                        if(RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;   
            }
            return result;
        }

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using(SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    string query = "AlumnoGetAll";
                    using(SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        DataTable tableAlumno = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(cmd); //Puente entre DataSet y BD 

                        da.Fill(tableAlumno); //llenar la tabla

                        if(tableAlumno.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach(DataRow row in tableAlumno.Rows)
                            {
                                ML.Alumno alumno = new ML.Alumno();

                                alumno.IdAlumno = int.Parse(row[0].ToString());
                                alumno.Nombre = row[1].ToString();
                                alumno.ApellidoPaterno = row[2].ToString();
                                alumno.ApellidoMaterno = row[3].ToString();
                                alumno.Sexo = row[4].ToString();
                                alumno.Email = row[5].ToString();

                                result.Objects.Add(alumno);
                                //result.Object = alumno
                            }
                            result.Correct = true;

                        }
                        else
                        {
                            result.Correct = false;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static ML.Result GetById(int IdAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    string query = "AlumnoGetById";
                    using(SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdAlumno", SqlDbType.Int);
                        collection[0].Value = IdAlumno;

                        cmd.Parameters.AddRange(collection);

                        DataTable tableAlumno = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(tableAlumno);

                        if(tableAlumno.Rows.Count > 0)
                        {
                            DataRow row = tableAlumno.Rows[0];
                            ML.Alumno alumno = new ML.Alumno();
                            alumno.IdAlumno = int.Parse(row[0].ToString());
                            alumno.Nombre = row[1].ToString();
                            alumno.ApellidoPaterno = row[2].ToString();
                            alumno.ApellidoMaterno = row[3].ToString();
                            alumno.Sexo = row[4].ToString();
                            alumno.Email = row[5].ToString();

                            result.Object = alumno; //BOXING : Proceso de convertir un tipo de dato a un objeto
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static ML.Result AddEF(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            try
            { 
                using(DL_EF.AGarciaGenAgostoEntities context = new DL_EF.AGarciaGenAgostoEntities())
                {
                    var query = context.AlumnoAdd(alumno.Nombre, alumno.ApellidoPaterno, alumno.ApellidoMaterno, alumno.Sexo, alumno.Email, alumno.Semestre.IdSemestre);
                    if(query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage=ex.Message;
            }
            return result;
        }
    }
}
