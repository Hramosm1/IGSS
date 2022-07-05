using MySql.Data.MySqlClient;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaSalud
{
    public class BdComun
    {
        string nombre;
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        public int Agregar2(PersonaViewModel persona)
        {

            int retorno = 0;
            conexion.Open();
            SqlDataReader reader;
            SqlCommand cmd = conexion.CreateCommand();
            PersonaViewModel person = new PersonaViewModel();
            String sql;
            try
            {


                sql = "SELECT DPI, NOMBRE, FECHA_NACIMIENTO, CONVERT(NVARCHAR, TELEFONO) TELEFONO FROM PERSONAS";
                sql = sql + " WHERE DPI = @DPI";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@DPI", person.dpi);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    person.dpi = reader.GetDecimal(0);
                    person.nombre = reader.GetString(1);
                    person.fecha = reader.GetDateTime(2);
                    person.telefono = reader.GetString(3);
                    retorno = 1;
                    if (person.telefono.All(char.IsDigit) && persona.telefono.All(char.IsDigit))
                    {
                        if (Convert.ToInt32(person.telefono) == 0 && Convert.ToInt32(persona.telefono) > 0)
                        {
                            //            conexion.Open();
                            cmd = conexion.CreateCommand();
                            SqlTransaction transaction;
                            transaction = conexion.BeginTransaction();
                            cmd.Connection = conexion;
                            cmd.Transaction = transaction;
                            try
                            {
                                sql = "update PERSONAS set  TELEFONO = @TELEFONO WHERE DPI = @DPI";
                                cmd.CommandText = sql;
                                cmd.Parameters.AddWithValue("@DPI", persona.dpi);
                                cmd.Parameters.AddWithValue("@TELEFONO", persona.telefono);
                                retorno = cmd.ExecuteNonQuery();

                                transaction.Commit();
                                conexion.Close();
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                conexion.Close();

                            }
                        }
                    }
                }
                conexion.Close();
                if (person.dpi == 0)
                {
                    conexion.Open();
                    cmd = conexion.CreateCommand();
                    SqlTransaction transaction;
                    transaction = conexion.BeginTransaction();
                    cmd.Connection = conexion;
                    cmd.Transaction = transaction;
                    try
                    {
                        sql = "Insert into personas (DPI,NOMBRE,FECHA_NACIMIENTO, TELEFONO)";
                        sql = sql + " VALUES (@DPI,@NOMBRE,@FECHA,@TELEFONO)";

                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@DPI", persona.dpi);
                        cmd.Parameters.AddWithValue("@NOMBRE", persona.nombre);
                        cmd.Parameters.AddWithValue("@FECHA", persona.fecha);
                        cmd.Parameters.AddWithValue("@TELEFONO", persona.telefono);
                        retorno = cmd.ExecuteNonQuery();

                        transaction.Commit();
                        conexion.Close();

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        conexion.Close();

                    }
                }
                return retorno;
            }
            catch (Exception)
            {
                conexion.Close();
                return 0;
            }

        }
        public int Agregar(PersonaViewModel persona)
        {
            int retorno = 0;
            PersonaViewModel person = new PersonaViewModel();
            String sql;

            SqlDataReader reader;
            conexion.Open();
            SqlCommand cmd = conexion.CreateCommand();

            try
            {
                sql = "SELECT DPI, NOMBRE, FECHA_NACIMIENTO, CONVERT(NVARCHAR, TELEFONO) TELEFONO FROM SALUD.PERSONAS";
                sql = sql + " WHERE DPI = @DPI";


                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@DPI", persona.dpi);
                reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    person.dpi = reader.GetDecimal(0);
                    person.nombre = reader.GetString(1);
                    person.fecha = reader.GetDateTime(2);
                    person.telefono = reader.GetString(3);
                    retorno = 1;
                    if (person.telefono.All(char.IsDigit) && persona.telefono.All(char.IsDigit))
                    {
                        if (Convert.ToInt32(person.telefono) == 0 && Convert.ToInt32(persona.telefono) > 0)
                        {
                            //  conexion.Open();
                            cmd.Connection = conexion;

                            sql = "update SALUD.PERSONAS set  TELEFONO = @TELEFONO WHERE DPI = @DPI";
                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@TELEFONO", persona.telefono);
                            retorno = cmd.ExecuteNonQuery();
                            conexion.Close();
                        }
                    }
                }
                conexion.Close();
                if (person.dpi == 0)
                {
                    conexion.Open();
                    cmd.Connection = conexion;

                    sql = "Insert into personas (DPI,NOMBRE,FECHA_NACIMIENTO, TELEFONO)";
                    sql = sql + " VALUES (@DPI,@NOMBRE,@FECHA,@TELEFONO)";

                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@NOMBRE", persona.nombre);
                    cmd.Parameters.AddWithValue("@FECHA", persona.fecha);
                    cmd.Parameters.AddWithValue("@TELEFONO", persona.telefono);

                    retorno = cmd.ExecuteNonQuery();
                    conexion.Close();
                }
                return retorno;
            }
            catch (Exception)
            {
                conexion.Close();
                return 0;
            }

        }
        public int AgregarTelefono(PersonaViewModel persona)
        {
            int retorno = 0;
            PersonaViewModel person = new PersonaViewModel();
            String sql;

            SqlDataReader reader;
            conexion.Open();
            SqlCommand cmd = conexion.CreateCommand();

            try
            {
                sql = "SELECT DPI, NOMBRE, FECHA_NACIMIENTO, ISNULL(TELEFONO,0) FROM SALUD.PERSONAS";
                sql = sql + " WHERE DPI = @DPI";

                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@DPI", persona.dpi);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    person.dpi = reader.GetInt64(0);
                    person.nombre = reader.GetString(1);
                    person.fecha = reader.GetDateTime(2);
                    person.telefono = reader.GetString(3);
                    retorno = 1;
                    if (person.telefono.All(char.IsDigit) && persona.telefono.All(char.IsDigit))
                    {
                        if (Convert.ToInt32(person.telefono) == 0)
                        {
                            // conexion.Open();
                            cmd.Connection = conexion;
                            sql = "update SALUD.PERSONAS set  TELEFONO = @TELEFONO WHERE DPI = @DPI";


                            cmd.CommandText = sql;
                            cmd.Parameters.AddWithValue("@TELEFONO", persona.telefono);

                            cmd.ExecuteNonQuery();
                            conexion.Close();
                        }
                    }
                }
                conexion.Close();
                if (person.dpi == 0)
                {
                    conexion.Open();
                    cmd.Connection = conexion;
                    sql = "Insert into personas (DPI,NOMBRE,FECHA_NACIMIENTO, TELEFONO)";
                    sql = sql + " VALUES (@DPI,@NOMBRE,@FECHA,@TELEFONO)";


                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@NOMBRE", persona.nombre);
                    cmd.Parameters.AddWithValue("@FECHA", persona.fecha);
                    cmd.Parameters.AddWithValue("@TELEFONO", persona.telefono);

                    retorno = cmd.ExecuteNonQuery();
                    conexion.Close();
                }
                return retorno;
            }
            catch (Exception EX)
            {
                conexion.Close();
                return 0;
            }

        }
        public int Agregarnew(ModelIgss persona)
        {

            int retorno = 0;
            PersonaViewModel person = new PersonaViewModel();
            String sql;

            SqlDataReader reader;
            conexion.Open();
            SqlCommand cmd = conexion.CreateCommand();

            sql = "SELECT DPI, NOMBRE, FECHA_NACIMIENTO, CONVERT(NVARCHAR, TELEFONO) TELEFONO FROM SALUD.PERSONAS";
            sql = sql + " WHERE DPI = @DPI";

            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@DPI", persona.dpi);
            reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                person.dpi = reader.GetDecimal(0);
                person.nombre = reader.GetString(1);
                person.fecha = reader.GetDateTime(2);
                if(reader.GetString(3) == null)
                {
                    person.telefono = "0";
                }
                else
                {
                    person.telefono = reader.GetString(3);
                }
                retorno = 1;
                if (person.telefono.All(char.IsDigit) && persona.Telefono.All(char.IsDigit))
                {
                    if (Convert.ToInt32(person.telefono) == 0 && Convert.ToInt32(persona.Telefono) > 0)
                    {
                        //  conexion.Open();
                        cmd.Connection = conexion;
                        sql = "update SALUD.PERSONAS set  TELEFONO = @TELEFONO WHERE DPI = @DPI";

                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@TELEFONO", persona.Telefono);
                        cmd.Parameters.AddWithValue("@DPI", persona.dpi);

                        cmd.ExecuteNonQuery();
                        conexion.Close();
                    }
                }
            }
            conexion.Close();
            if (person.dpi == 0)
            {
                conexion.Open();
                cmd.Connection = conexion;
                sql = "Insert into SALUD.personas (DPI,NOMBRE,FECHA_NACIMIENTO, TELEFONO)";
                sql = sql + " VALUES (@DPI,@NOMBRE,@FECHA,@TELEFONO)";

                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@NOMBRE", persona.nombre);
                cmd.Parameters.AddWithValue("@FECHA", persona.fecha);
                cmd.Parameters.AddWithValue("@TELEFONO", persona.Telefono);

                cmd.ExecuteNonQuery();
                conexion.Close();
            }
            return retorno;


        }
        public int agregar_detalle(ControbucionesModel controbuciones)
        {

            ControbucionesModel patrono = new ControbucionesModel();
            int retorno = 0;
            String sql;

            SqlDataReader reader;
            conexion.Open();
            SqlCommand cmd = conexion.CreateCommand();

            sql = "SELECT DPI, CODIGO_PATRONO, AÑO, MES, RAZON_SOCIAL, APORTE FROM SALUD.CONTRIBUCIONES WHERE CODIGO_PATRONO = @PATRONO AND DPI = @DPI AND MES = @MES AND AÑO = @AÑO";

            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@PATRONO", controbuciones.codigo_patron);
            cmd.Parameters.AddWithValue("@DPI", controbuciones.dpi);
            cmd.Parameters.AddWithValue("@MES", controbuciones.mes);
            cmd.Parameters.AddWithValue("@AÑO", controbuciones.año);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                patrono.codigo_patron = reader.GetInt32(1);
                patrono.dpi = reader.GetInt64(0);
                patrono.año = Convert.ToInt32(reader.GetDecimal(2));
                patrono.mes = Convert.ToInt32(reader.GetDecimal(3));
                patrono.razon = reader.GetString(4);
                patrono.aporte = reader.GetString(5);
                retorno = 1;
            }
            conexion.Close();
            if (patrono.codigo_patron == 0)
            {
                conexion.Open();
                cmd.Connection = conexion;
                sql = "Insert into SALUD.contribuciones(DPI, CODIGO_PATRONO, AÑO, MES, RAZON_SOCIAL, APORTE)";
                sql = sql + " VALUES (@DPI,@PATRON,@AÑO,@MES,@RAZON,APORTE)";

                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@RAZON_SOCIAL", controbuciones.razon);
                cmd.Parameters.AddWithValue("@APORTE", controbuciones.aporte);
                cmd.ExecuteNonQuery();
                conexion.Close();
            }
            else
            {
                conexion.Open();
                cmd.Connection = conexion;
                sql = "update SALUD.contribuciones set  APORTE = @APORTE WHERE CODIGO_PATRONO = @PATRONO AND DPI = @DPI AND MES = @MES AND AÑO = @AÑO";

                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@APORTE", controbuciones.aporte);
                cmd.ExecuteNonQuery();
                conexion.Close();
            }
            conexion.Close();
            return retorno;



        }
        public int agregar_detalle(int codigo_patron, decimal dpi, int mes, int año, string razon, string aporte)
        {
            ControbucionesModel patrono = new ControbucionesModel();
            int retorno = 0;
            SqlDataReader reader;
            conexion.Open();
            SqlCommand cmd = conexion.CreateCommand();
            String sql;
            sql = "SELECT DPI, CODIGO_PATRONO,CONVERT(int,AÑO) AÑO, CONVERT(int,MES) MES, RAZON_SOCIAL, APORTE FROM SALUD.CONTRIBUCIONES WHERE CODIGO_PATRONO = @PATRONO AND DPI = @DPI AND MES = @MES AND AÑO = @AÑO";

            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@PATRONO", codigo_patron);
            cmd.Parameters.AddWithValue("@DPI", dpi);
            cmd.Parameters.AddWithValue("@MES", mes);
            cmd.Parameters.AddWithValue("@AÑO", año);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                patrono.codigo_patron = reader.GetInt32(1);
                patrono.dpi = reader.GetDecimal(0);
                patrono.año = reader.GetInt32(2);
                patrono.mes = reader.GetInt32(3);
                patrono.razon = reader.GetString(4);
                patrono.aporte = reader.GetString(5);
                retorno = 1;
            }
            conexion.Close();
            if (patrono.codigo_patron == 0)
            {
                conexion.Open();
                cmd.Connection = conexion;

                sql = "Insert into SALUD.contribuciones(DPI, CODIGO_PATRONO, AÑO, MES, RAZON_SOCIAL, APORTE)";
                sql = sql + " VALUES (@DPI,@PATRONO,@AÑO,@MES,@RAZON,@APORTE)";

                cmd.CommandText = sql;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@PATRONO", codigo_patron);
                cmd.Parameters.AddWithValue("@DPI", dpi);
                cmd.Parameters.AddWithValue("@MES", mes);
                cmd.Parameters.AddWithValue("@AÑO", año);
                cmd.Parameters.AddWithValue("@RAZON", razon);
                cmd.Parameters.AddWithValue("@APORTE", aporte);

                retorno = cmd.ExecuteNonQuery();
                conexion.Close();

            }
            else
            {
                conexion.Open();
                cmd.Connection = conexion;
                sql = "update SALUD.contribuciones set  APORTE = @APORTE WHERE CODIGO_PATRONO = @PATRONO AND DPI = @DPI AND MES = @MES AND AÑO = @AÑO";

                cmd.CommandText = sql;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@PATRONO", codigo_patron);
                cmd.Parameters.AddWithValue("@DPI", dpi);
                cmd.Parameters.AddWithValue("@MES", mes);
                cmd.Parameters.AddWithValue("@AÑO", año);
                cmd.Parameters.AddWithValue("@RAZON", razon);
                cmd.Parameters.AddWithValue("@APORTE", aporte);

                retorno = cmd.ExecuteNonQuery();
                conexion.Close();
            }
            conexion.Close();
            return retorno;

        }
        public int agregar_patrono(PatronModel patron)
        {
            int retorno = 0;
            PatronModel patrono = new PatronModel();
            SqlDataReader reader;
            
            try
            {
                conexion.Open();
                SqlCommand cmd = conexion.CreateCommand();
                SqlCommand cmd2 = conexion.CreateCommand();

                String sql;
                String update;

                sql = "SELECT CODIGO_PATRONO, NOMBRE FROM SALUD.PATRONO WHERE CODIGO_PATRONO = @PATRONO";

                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@PATRONO", patron.codigo_patron);
                cmd.Parameters.AddWithValue("@NOMBRE", patron.nombre);
                reader = cmd.ExecuteReader();

                if (reader.Read()==true)
                {
                    conexion.Close();
                    conexion.Open();
                    cmd2.Connection = conexion;
                    update = "update SALUD.patrono set NOMBRE = @NOMBRE WHERE CODIGO_PATRONO = @PATRONO";
                    cmd2.CommandText = update;
                    cmd2.Parameters.AddWithValue("@PATRONO", patron.codigo_patron);
                    cmd2.Parameters.AddWithValue("@NOMBRE", patron.nombre);
                    cmd2.ExecuteNonQuery();
                }
                conexion.Close();
                conexion.Open();
                cmd.CommandText = sql;
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    patrono.codigo_patron = reader.GetInt32(0);
                    patrono.nombre = reader.GetString(1);
                    retorno = 1;
                }
                conexion.Close();
                if (patrono.codigo_patron == 0)
                {
                    conexion.Open();
                    cmd.Connection = conexion;
                    sql = "Insert into SALUD.patrono (codigo_patrono, nombre)";
                    sql = sql + " VALUES (@PATRONO,@NOMBRE)";
                    cmd.CommandText = sql;
                    retorno = cmd.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {

            }

            
            conexion.Close();
            return retorno;


        }

        public PersonaViewModel BuscarP(decimal dpi)
        {
            PersonaViewModel persona = new PersonaViewModel();

            SqlDataReader reader;
            conexion.Open();
            SqlCommand cmd = conexion.CreateCommand();

            string sql;
            sql = "SELECT DPI, NOMBRE, FECHA_NACIMIENTO, CONVERT(NVARCHAR, TELEFONO) TELEFONO FROM SALUD.PERSONAS";
            sql = sql + " WHERE DPI = @DPI";

            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@DPI", dpi);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                persona.dpi = reader.GetDecimal(0);
                persona.nombre = reader.GetString(1);
                persona.fecha = reader.GetDateTime(2);
                persona.telefono = reader.GetString(3);
            }
            conexion.Close();
            return persona;


        }


        public List<ModelIgss> Buscarnew(String dpis)
        {
            List<ModelIgss> Result = new List<ModelIgss>();
            try 
            {
               
                SqlDataReader reader;
                conexion.Open();
                SqlCommand cmd = conexion.CreateCommand();

                string sql;
                sql = "SELECT PERSONAS.DPI, PERSONAS.NOMBRE, PERSONAS.FECHA_NACIMIENTO,  Convert(nvarchar,personas.telefono) TELEFONO, Convert(int,ISNULL(PATRONO.CODIGO_PATRONO,0)) CODIGO_PATRONO, ISNULL(PATRONO.NOMBRE,'NO EXISTEN DATOS') ";
                sql = sql + " NOMBRE_PATRONO, Convert(int,ISNULL(CONTRIBUCIONES.AÑO,0)) AÑO, Convert(int,ISNULL(CONTRIBUCIONES.MES,0)) MES, ISNULL(CONTRIBUCIONES.RAZON_SOCIAL,'') RAZON_SOCIAL, case ISNULL(CONTRIBUCIONES.APORTE,'N') when 'S' THEN 'SI' ELSE 'NO' END APORTE ";
                sql = sql + " FROM SALUD.PERSONAS   left join SALUD.CONTRIBUCIONES  on PERSONAS.DPI = CONTRIBUCIONES.DPI   left join   SALUD.PATRONO on PATRONO.CODIGO_PATRONO = CONTRIBUCIONES.CODIGO_PATRONO";
                sql = sql + " where PERSONAS.DPI IN (" + dpis + ") ";
                sql = sql + " order by 1,7 DESC,8 DESC ;";


                cmd.CommandText = sql;
                // cmd.Parameters.AddWithValue("@DPI", dpi);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ModelIgss persona = new ModelIgss();
                    Result.Add(new ModelIgss
                    {
                        dpi = reader.GetDecimal(0),
                        nombre = reader.GetString(1),
                        fecha = reader.GetDateTime(2),
                        Telefono = reader.GetString(3),
                        codigo_patron = reader.GetInt32(4),
                        nombre_patrono = reader.GetString(5),
                        año = reader.GetInt32(6),
                        mes = reader.GetInt32(7),
                        razon = reader.GetString(8),
                        aporte = reader.GetString(9)
                    }); ;
                }
                conexion.Close();
                

            }
            catch (Exception ex)
            {
             
            }

            return Result;

        }

        public List<ModelIgss> BuscarM(string dpis)
        {
            List<ModelIgss> Result = new List<ModelIgss>();

            SqlDataReader reader;
            conexion.Open();
            SqlCommand cmd = conexion.CreateCommand();

            string sql;
            sql = "SELECT PERSONAS.DPI, PERSONAS.NOMBRE, isnull(convert(date,PERSONAS.FECHA_NACIMIENTO,1),'') FECHA_NACIMIENTO,  Convert(nvarchar,personas.telefono) TELEFONO, Convert(int,ISNULL(PATRONO.CODIGO_PATRONO,0)) CODIGO_PATRONO, ISNULL(PATRONO.NOMBRE,'NO EXISTEN DATOS') ";
            sql = sql + " NOMBRE_PATRONO, Convert(int,ISNULL(CONTRIBUCIONES.AÑO,0)) AÑO, Convert(int,ISNULL(CONTRIBUCIONES.MES,0)) MES, ISNULL(CONTRIBUCIONES.RAZON_SOCIAL,'') RAZON_SOCIAL, case ISNULL(CONTRIBUCIONES.APORTE,'N') when 'S' THEN 'SI' ELSE 'NO' END APORTE ";
            sql = sql + " FROM SALUD.PERSONAS   left join SALUD.CONTRIBUCIONES  on PERSONAS.DPI = CONTRIBUCIONES.DPI   left join   SALUD.PATRONO on PATRONO.CODIGO_PATRONO = CONTRIBUCIONES.CODIGO_PATRONO";
            sql = sql + " where PERSONAS.DPI IN (" + dpis + ") ";
            sql = sql + " order by 1,7 DESC,8 DESC ;";

            cmd.CommandText = sql;
            //cmd.Parameters.AddWithValue("@DPI", dpi);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ModelIgss persona = new ModelIgss();
                Result.Add(new ModelIgss
                {
                    dpi = reader.GetDecimal(0),
                    nombre = reader.GetString(1),
                    fecha = reader.GetDateTime(2),
                    Telefono = reader.GetString(3),
                    codigo_patron = reader.GetInt32(4),
                    nombre_patrono = reader.GetString(5),
                    año = reader.GetInt32(6),
                    mes = reader.GetInt32(7),
                    razon = reader.GetString(8),
                    aporte = reader.GetString(9)
                }); ;
            }
            conexion.Close();
            return Result;

        }
        public List<PersonaViewModel> BuscarTelefono(string dpi)
        {
            List<PersonaViewModel> Result = new List<PersonaViewModel>();
            SqlDataReader reader;
            conexion.Open();
            SqlCommand cmd = conexion.CreateCommand();
            string sql;
            sql = "SELECT PERSONAS.DPI, PERSONAS.NOMBRE, PERSONAS.FECHA_NACIMIENTO, PERSONAS.TELEFONO ";
            sql = sql + "FROM SALUD.PERSONAS where PERSONAS.DPI IN (@DPI) AND PERSONAS.TELEFONO > 0 ";
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@DPI", dpi);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                PersonaViewModel persona = new PersonaViewModel();
                persona.dpi = reader.GetInt64(0);
                persona.nombre = reader.GetString(1);
                persona.fecha = reader.GetDateTime(2);
                persona.telefono = reader.GetString(3);

                Result.Add(persona);
            }
            conexion.Close();
            return Result;
        }
        //public void borrarDatos()
        //{
        //    conexion.Open();
        //    try
        //    {
        //        string sql;
        //        sql = "DELETE FROM contribuciones WHERE EXISTS ( SELECT * FROM PERSONAS  WHERE PERSONAS.DPI = CONTRIBUCIONES.DPI)";
        //        MySqlCommand command = new MySqlCommand(string.Format(sql), conexion);
        //        command.ExecuteNonQuery();

        //        conexion.Close();
        //    }
        //    catch (Exception)
        //    {
        //        conexion.Close();
        //    }
        //}
    }
}

