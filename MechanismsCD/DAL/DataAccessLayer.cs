using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace MechanismsCD.DAL
{
    class DataAccessLayer
    {
        SqlConnection sqlcon, sqlcon1, sqlcon2, sqlcon3;

        public DataAccessLayer()
        {
            sqlcon = new SqlConnection("Data Source=" + Properties.Settings.Default.ServerIp.ToString() + ";initial Catalog=" + Properties.Settings.Default.DBName.ToString() + "; persist Security info=True; user id=" + Properties.Settings.Default.DBuserName.ToString() + ";password=" + Properties.Settings.Default.DBpassword.ToString() + "");
            sqlcon1 = new SqlConnection("Data Source=" + Properties.Settings.Default.ServerIp1.ToString() + ";initial Catalog=" + Properties.Settings.Default.DBName1.ToString() + "; persist Security info=True; user id=" + Properties.Settings.Default.DBuserName1.ToString() + ";password=" + Properties.Settings.Default.DBpassword1.ToString() + "");
            sqlcon2 = new SqlConnection("Data Source=" + Properties.Settings.Default.ServerIp2.ToString() + ";initial Catalog=" + Properties.Settings.Default.DBName2.ToString() + "; persist Security info=True; user id=" + Properties.Settings.Default.DBuserName2.ToString() + ";password=" + Properties.Settings.Default.DBpassword2.ToString() + "");
            sqlcon3 = new SqlConnection("Data Source=" + Properties.Settings.Default.ServerIp3.ToString() + ";initial Catalog=" + Properties.Settings.Default.DBName3.ToString() + "; persist Security info=True; user id=" + Properties.Settings.Default.DBuserName3.ToString() + ";password=" + Properties.Settings.Default.DBpassword3.ToString() + "");
        }

        //open and close connection for Our
        public void open()
        {
            if(sqlcon.State !=ConnectionState.Open)
            {
                sqlcon.Open();
            }
        }
        public void close()
        {
            if (sqlcon.State != ConnectionState.Closed)
            {
                sqlcon.Close();
            }
        }
        
        //open and close connection for 1
        public void open1()
        {
            if (sqlcon1.State != ConnectionState.Open)
            {
                sqlcon1.Open();
            }
        }
        public void close1()
        {
            if (sqlcon1.State != ConnectionState.Closed)
            {
                sqlcon1.Close();
            }
        }

        //oprn and close connection for 2
        public void open2()
        {
            if (sqlcon2.State != ConnectionState.Open)
            {
                sqlcon2.Open();
            }
        }
        public void close2()
        {
            if (sqlcon2.State != ConnectionState.Closed)
            {
                sqlcon2.Close();
            }
        }

        //open and close connection for 3
        public void open3()
        {
            if (sqlcon3.State != ConnectionState.Open)
            {
                sqlcon3.Open();
            }
        }
        public void close3()
        {
            if (sqlcon3.State != ConnectionState.Closed)
            {
                sqlcon3.Close();
            }
        }

        //execute stored procedure for Our
        public DataTable SelectingData(string stored_Procedure,SqlParameter[] param)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = stored_Procedure;
            sqlcmd.Connection = sqlcon;


            if (param !=null)
            {
                for(int i=0; i <param.Length; i++)
                {
                    sqlcmd.Parameters.Add(param[i]);

                }
            }
            SqlDataAdapter Da = new SqlDataAdapter(sqlcmd);
            DataTable Dt = new DataTable();
            Da.Fill(Dt);
            return Dt;

        }
        public void ExecuteCommand(string Stored_Procedure,SqlParameter[] param)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = Stored_Procedure;
            sqlcmd.Connection = sqlcon;

            if(param != null)
            {
                for(int i = 0; i < param.Length; i++)
                {
                    sqlcmd.Parameters.Add(param[i]);

                }
            }
            sqlcmd.ExecuteNonQuery();

        }


        //execute stored procedure for 1
        public DataTable SelectingData1(string stored_Procedure, SqlParameter[] param)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = stored_Procedure;
            sqlcmd.Connection = sqlcon1;


            if (param != null)
            {
                for (int i = 0; i < param.Length; i++)
                {
                    sqlcmd.Parameters.Add(param[i]);

                }
            }
            SqlDataAdapter Da = new SqlDataAdapter(sqlcmd);
            DataTable Dt = new DataTable();
            Da.Fill(Dt);
            return Dt;

        }
        public void ExecuteCommand1(string Stored_Procedure, SqlParameter[] param)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = Stored_Procedure;
            sqlcmd.Connection = sqlcon1;

            if (param != null)
            {
                for (int i = 0; i < param.Length; i++)
                {
                    sqlcmd.Parameters.Add(param[i]);

                }
            }
            sqlcmd.ExecuteNonQuery();

        }

        //execute stored procedure for 2
        public DataTable SelectingData2(string stored_Procedure, SqlParameter[] param)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = stored_Procedure;
            sqlcmd.Connection = sqlcon2;


            if (param != null)
            {
                for (int i = 0; i < param.Length; i++)
                {
                    sqlcmd.Parameters.Add(param[i]);

                }
            }
            SqlDataAdapter Da = new SqlDataAdapter(sqlcmd);
            DataTable Dt = new DataTable();
            Da.Fill(Dt);
            return Dt;

        }
        public void ExecuteCommand2(string Stored_Procedure, SqlParameter[] param)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = Stored_Procedure;
            sqlcmd.Connection = sqlcon2;

            if (param != null)
            {
                for (int i = 0; i < param.Length; i++)
                {
                    sqlcmd.Parameters.Add(param[i]);

                }
            }
            sqlcmd.ExecuteNonQuery();

        }

        //execute stored procedure for 3
        public DataTable SelectingData3(string stored_Procedure, SqlParameter[] param)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = stored_Procedure;
            sqlcmd.Connection = sqlcon3;


            if (param != null)
            {
                for (int i = 0; i < param.Length; i++)
                {
                    sqlcmd.Parameters.Add(param[i]);

                }
            }
            SqlDataAdapter Da = new SqlDataAdapter(sqlcmd);
            DataTable Dt = new DataTable();
            Da.Fill(Dt);
            return Dt;

        }
        public void ExecuteCommand3(string Stored_Procedure, SqlParameter[] param)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = Stored_Procedure;
            sqlcmd.Connection = sqlcon3;

            if (param != null)
            {
                for (int i = 0; i < param.Length; i++)
                {
                    sqlcmd.Parameters.Add(param[i]);

                }
            }
            sqlcmd.ExecuteNonQuery();

        }


        //create backup database
        public void createBackup(string path)
        {
            sqlcon.Open();
            SqlCommand cmd1 = new SqlCommand("ALTER DATABASE [" + Properties.Settings.Default.DBName.ToString() + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE ", sqlcon);
            cmd1.ExecuteNonQuery();

            string cmd = "BACKUP DATABASE [" + Properties.Settings.Default.DBName.ToString() + "] TO DISK='" + path + "\\" + Properties.Settings.Default.DBName.ToString() +
                "-" + DateTime.Now.ToShortDateString().Replace("/", "-") + "_" + DateTime.Now.ToShortTimeString().Replace(":", "-") + ".bak'";
            SqlCommand command = new SqlCommand(cmd, sqlcon);
            command.ExecuteNonQuery();

            SqlCommand cmd3 = new SqlCommand("ALTER DATABASE [" + Properties.Settings.Default.DBName.ToString() + "] SET MULTI_USER", sqlcon);
            cmd3.ExecuteNonQuery();
            sqlcon.Close();
        }


        //recovery database from bak file
        public void Restore(string path)
        {
            sqlcon.Open();
            SqlCommand cmd1 = new SqlCommand("ALTER DATABASE [" + Properties.Settings.Default.DBName.ToString() + "] SET SETOFFLINE WITH ROLLBACK IMMEDIATE ", sqlcon);
            cmd1.ExecuteNonQuery();
            SqlCommand cmd2 = new SqlCommand("USE MASTER RESTORE DATABASE [" + Properties.Settings.Default.DBName.ToString() + "] FROM DISK=N'" + path + "' WITH REPLACE", sqlcon);
            cmd2.ExecuteNonQuery();
            SqlCommand cmd3 = new SqlCommand("ALTER DATABASE [" + Properties.Settings.Default.DBName.ToString() + "] SET ONLINE WITH ROLLBACK IMMEDIATE", sqlcon);
            cmd3.ExecuteNonQuery();
            sqlcon.Close();           
        }

    }
}
