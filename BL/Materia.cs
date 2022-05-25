using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BL
{
    public class Materia
    {
        public static ML.Result Add(string nombre, decimal costo, byte creditos)
        {
            //instancia
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "INSERT INTO [Materia]  ([Nombre] ,[Costo] ,[Creditos]) VALUES (@Nombre, @Costo, @Creditos )";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;

                        SqlParameter[] parameter = new SqlParameter[3];

                        parameter[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                        parameter[0].Value = nombre;

                        parameter[1] = new SqlParameter("@Costo", SqlDbType.Decimal);
                        parameter[1].Value = costo;

                        parameter[2] = new SqlParameter("@Creditos", SqlDbType.TinyInt);
                        parameter[2].Value = creditos;

                        cmd.Parameters.AddRange(parameter);
                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
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
                result.Ex = ex;
            }
            return result;
        }
    }
}
