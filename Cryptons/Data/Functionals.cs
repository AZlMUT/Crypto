using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using Cryptons.Views.Dialogs;

namespace Cryptons
{
    class Functionals
    {
        private Functionals() { }
        private static Functionals _Functionals;
        public static Functionals DB()
        {
            if (_Functionals == null)
            {
                _Functionals = new Functionals();
            }
            return _Functionals;
        }
        public string nameDB = Properties.Settings.Default.MyDatabaseConnectionString;

        public SqlConnection getConn()
        {
            try
            {
                SqlConnection conn = new SqlConnection(nameDB);
                return conn;
            }
            catch
            {
                new ErrorFrame("Не удалось подключится к файлу Базы Данных. Возможно отстутствует подключение!");
                return null;
            }
        }


        public int GetCount(string sqlQuery)
        {
            SqlConnection conn = getConn();
            conn.Open();

            int x = 0;

            using (SqlCommand myCommand = new SqlCommand(sqlQuery, conn))
            {
                SqlDataReader reader = myCommand.ExecuteReader();
                while (reader.Read()) x++;
                reader.Close();
            }
            conn.Close();
            return x;
        }
        public int GetMax(string sql, string selectCol)
        {
            SqlConnection conn = getConn();
            conn.Open();

            int max = 0, x;

            using (SqlCommand myCommand = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = myCommand.ExecuteReader();

                while (reader.Read())
                {
                    x = reader.GetInt32(reader.GetOrdinal(selectCol));
                    if (x > max) max = x;
                };
                reader.Close();
            }
            conn.Close();
            return max;
        }
        public int GetMin(string sql, string selectCol)
        {
            SqlConnection conn = getConn();
            conn.Open();

            int min = int.MaxValue, x;

            using (SqlCommand myCommand = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = myCommand.ExecuteReader();

                while (reader.Read())
                {
                    x = reader.GetInt32(reader.GetOrdinal(selectCol));
                    if (x < min) min = x;
                };
                reader.Close();
            }
            conn.Close();
            return min;
        }
        public int GetId(string Table = "[User]", string selectCols = "id_user")
        {
            SqlConnection conn = getConn();
            conn.Open(); int max = 0, x;

            using (SqlCommand myCommand = new SqlCommand($"select {selectCols} from {Table}", conn))
            {
                SqlDataReader reader = myCommand.ExecuteReader();

                while (reader.Read())
                {
                    x = reader.GetInt32(reader.GetOrdinal(selectCols));
                    if (x > max) max = x;
                };
                reader.Close();
            }
            conn.Close();
            return max;
        }
        public int GetId(string login)
        {
            SqlConnection conn = getConn();
            conn.Open(); int x = -1;

            using (SqlCommand myCommand = new SqlCommand($"select id_user from [User] where login = '{login}'", conn))
            {
                SqlDataReader reader = myCommand.ExecuteReader();

                while (reader.Read())
                {
                    x = reader.GetInt32(0);
                };
                reader.Close();
            }
            conn.Close();
            return x;
        }

        public string GetString<T>(string Table, string colName, string idCol, T id)
        {
            SqlConnection conn = getConn();
            conn.Open();
            string myValue = "";
            string sql = string.Format($"select {colName} from {Table} where {idCol} = '{id}'");
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                    myValue = reader.GetString(reader.GetOrdinal(colName));

                reader.Close();
            }
            conn.Close();
            return myValue;
        }
        public int GetInt<T>(string Table, string colName, string idCol, T id)
        {
            SqlConnection conn = getConn();
            conn.Open();
            int myValue = 0;
            string sql = string.Format($"select {colName} from {Table} where {idCol} = '{id}'");
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                    myValue = reader.GetInt32(reader.GetOrdinal(colName));

                reader.Close();
            }
            conn.Close();
            return myValue;
        }
        public int GetInt(string sql, string colName)
        {
            SqlConnection conn = getConn();
            conn.Open();
            int myValue = 0;
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                    myValue = reader.GetInt32(reader.GetOrdinal(colName));

                reader.Close();
            }
            conn.Close();
            return myValue;
        }

        public DataTable GetQuery(string myQuery)
        {
            SqlConnection conDB = new SqlConnection(nameDB);//all
            conDB.Open();

            DataTable tabord = new DataTable();
            SqlDataAdapter dazak = new SqlDataAdapter(myQuery, conDB);
            dazak.Fill(tabord);

            return tabord;
        }
        public DataTable GetTable(string tableName)
        {
            SqlConnection conDB = new SqlConnection(nameDB);
            conDB.Open();
            DataTable tabord = new DataTable();
            SqlDataAdapter dazak = new SqlDataAdapter("SELECT * FROM " + tableName, conDB);
            dazak.Fill(tabord);
            return tabord;
        }

        public bool DeleteFrom(int delID, string Table, string colName)
        {

            SqlConnection conn = getConn();
            conn.Open();
            string sql = string.Format($"Delete from {Table} where {colName} = '{delID}'");
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                { Exception error = new Exception("К сожалению!", ex); throw error; }
            }
            conn.Close();
            return true;
        }
        public bool DeleteFrom<T>(T delID, string Table, string colName)
        {

            SqlConnection conn = getConn();
            conn.Open();
            string sql = string.Format($"Delete from {Table} where {colName} = '{delID}'");
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                { Exception error = new Exception("К сожалению!", ex); throw error; }
            }
            conn.Close();
            return true;
        }
        public bool Delete(string sql)
        {
            SqlConnection conn = getConn();
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Delete");
                }
            }
            conn.Close();
            return true;
        }

        public bool Add(string login, string password, string username, string firstname, string groupes)
        {
            SqlConnection conn = getConn();
            conn.Open();

            string sql = "INSERT INTO [User] (login,password,usertype,username,firstname,groupes) " +
                "values (@login,@password,@usertype,@username,@firstname,@groupes)";

            using (SqlCommand myCommand = new SqlCommand(sql, conn))
            {
                myCommand.Parameters.AddWithValue("@login", login);
                myCommand.Parameters.AddWithValue("@password", password);
                myCommand.Parameters.AddWithValue("@usertype", "Student");
                myCommand.Parameters.AddWithValue("@username", username);
                myCommand.Parameters.AddWithValue("@firstname", firstname);
                myCommand.Parameters.AddWithValue("@groupes", groupes);
                myCommand.ExecuteNonQuery();
            }
            conn.Close();
            return true;
        }
        public bool AddAdmin(string login, string password, string username, string firstname)
        {
            SqlConnection conn = getConn();
            conn.Open();

            string sql = "INSERT INTO [User] (login,password,usertype,username,firstname,groupes) " +
                "values (@login,@password,@usertype,@username,@firstname,@groupes)";
            try
            {
                using (SqlCommand myCommand = new SqlCommand(sql, conn))
                {
                    myCommand.Parameters.AddWithValue("@login", login);
                    myCommand.Parameters.AddWithValue("@password", password);
                    myCommand.Parameters.AddWithValue("@usertype", "Admin");
                    myCommand.Parameters.AddWithValue("@username", username);
                    myCommand.Parameters.AddWithValue("@firstname", firstname);
                    myCommand.Parameters.AddWithValue("@groupes", "Admin");
                    myCommand.ExecuteNonQuery();
                }
            }
            catch
            {
                conn.Close(); return false;
            }
            
            conn.Close();
            return true;
        }
        public bool AddQuestion(List<string> data)
        {
            SqlConnection conn = getConn();
            conn.Open();

            string sql = "INSERT INTO [Question] (quest,answer1,answer2,answer3,answer4,trueAnswer) " +
                "values (@quest,@answer1,@answer2,@answer3,@answer4,@trueAnswer)";
            
            try
            {
                using (SqlCommand myCommand = new SqlCommand(sql, conn))
                {
                    myCommand.Parameters.AddWithValue("@quest", data[0]);
                    myCommand.Parameters.AddWithValue("@answer1", data[1]);
                    myCommand.Parameters.AddWithValue("@answer2", data[2]);
                    myCommand.Parameters.AddWithValue("@answer3", (data.Count > 4) ? data[3] : "NULL");
                    myCommand.Parameters.AddWithValue("@answer4", (data.Count > 5) ? data[4] : "NULL");
                    myCommand.Parameters.AddWithValue("@trueAnswer", Convert.ToInt32(data[data.Count - 1]));

                    myCommand.ExecuteNonQuery();
                }
                MessageBox.Show("Вопрос успешно добавлен!");
            }
            catch
            {
                conn.Close(); return false;
            }
            conn.Close();
            return true;
        }
        public bool UpdateUser(string Col, string value, int id)
        {
            SqlConnection conn = getConn();
            conn.Open();

            string sql = $"UPDATE [User] SET {Col}=@x1 Where id_user=@id_user";
            using (SqlCommand myCommand = new SqlCommand(sql, conn))
            {
                myCommand.Parameters.AddWithValue("@id_user", id);
                myCommand.Parameters.AddWithValue("@x1", value);
                myCommand.ExecuteNonQuery();
            }
            conn.Close();
            return true;
        }
        public bool SaveTest(int rating)
        {
            SqlConnection conn = getConn();
            conn.Open();

            string sql = "INSERT INTO [Rating] (id_user,rating) " +
                "values (@id_user,@rating)";
            try
            {
                using (SqlCommand myCommand = new SqlCommand(sql, conn))
                {
                    myCommand.Parameters.AddWithValue("@id_user", Properties.Settings.Default.UserId);
                    myCommand.Parameters.AddWithValue("@rating", rating);
                    myCommand.ExecuteNonQuery();
                }
            }
            catch
            {
                MessageBox.Show("SaveTest");
                conn.Close(); return false;
            }
            conn.Close();
            return true;
        }
        public bool AddInfo(List<string> data)
        {
            SqlConnection conn = getConn();
            conn.Open();

            string sql = "INSERT INTO [Infos] (header,body,icon) " +
                "values (@header,@body,@icon)";
            try
            {
                using (SqlCommand myCommand = new SqlCommand(sql, conn))
                {
                    myCommand.Parameters.AddWithValue("@header", data[0]);
                    myCommand.Parameters.AddWithValue("@body", data[1]);
                    myCommand.Parameters.AddWithValue("@icon", data[2]);
                    myCommand.ExecuteNonQuery();
                }
            }
            catch
            {
                conn.Close(); return false;
            }
            conn.Close();
            return true;
        }

        public string getPassword(string login)
        {

            string myValue = "Error1";
            SqlConnection conn = getConn();
            conn.Open();

            string sql = $"select * from [User] where login = '{login}'";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                    myValue = reader.GetString(reader.GetOrdinal("password"));

                reader.Close();
            }
            conn.Close();
            return myValue; try
            {
            }
            catch
            {
                MessageBox.Show("getPassword");
                return "Error";
            }

        }
        public int getIdUser(string login)
        {
            SqlConnection conn = getConn();
            conn.Open();
            int myValue = -1;
            string sql = string.Format($"select id_user from [User] where login = '{login}'");
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                    myValue = reader.GetInt32(reader.GetOrdinal("id_user"));

                reader.Close();
            }
            conn.Close();
            return myValue;
        }
        public List<List<string>> getRating()
        {
            List<List<string>> result = new List<List<string>>();

            SqlConnection conn = getConn();
            conn.Open();
            string sql = "select username,firstname,groupes,rating from [User],[Rating] " +
                "where [User].id_user = [Rating].id_user";

            using (SqlCommand myCommand = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = myCommand.ExecuteReader();

                while (reader.Read())
                {
                    List<string> res = new List<string>();
                    res.Add(reader.GetString(0));
                    res.Add(reader.GetString(1));
                    res.Add(reader.GetString(2));
                    res.Add(reader.GetInt32(3).ToString());
                    result.Add(res);
                };
                reader.Close();
            }
            conn.Close();

            return result;
        }
        public List<List<string>> getQuestions()
        {
            List<List<string>> result = new List<List<string>>();
            SqlConnection conn = getConn();
            conn.Open();
            string sql = string.Format($"select * from [Question]");
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    List<string> quest = new List<string>();
                    quest.Add(reader.GetInt32(0).ToString());
                    quest.Add(reader.GetString(1));
                    quest.Add(reader.GetString(2));
                    quest.Add(reader.GetString(3));
                    quest.Add(reader.GetString(4));
                    quest.Add(reader.GetString(5));
                    quest.Add(reader.GetInt32(6).ToString());
                    result.Add(quest);
                }
                reader.Close();
            }
            conn.Close();
            return result;
        }
        public List<List<string>>  getListQuest()
        {
            List<List<string>> result = new List<List<string>>();
            

            SqlConnection conn = getConn();
            conn.Open();
            string sql = "select id_quest,quest from [Question]";

            using (SqlCommand myCommand = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = myCommand.ExecuteReader();
                while (reader.Read())
                {
                    List<string> res = new List<string>();
                    res.Add(reader.GetInt32(0).ToString());
                    res.Add(reader.GetString(1));
                    result.Add(res);
                }
                reader.Close();
            }
            conn.Close();
            return result;
        }
        public List<List<string>> getListInfo(string filter = "%")
        {
            List<List<string>> result = new List<List<string>>();
            SqlConnection conn = getConn();
            conn.Open();
            string sql = "select * from [Infos]";

            using (SqlCommand myCommand = new SqlCommand(sql, conn))
            {
                myCommand.Parameters.AddWithValue("@filter",filter);
                SqlDataReader reader = myCommand.ExecuteReader();
                while (reader.Read())
                {
                    List<string> res = new List<string>();
                    res.Add(reader.GetString(1));
                    res.Add(reader.GetString(2));
                    res.Add(reader.GetString(3));
                    result.Add(res);
                }
                reader.Close();
            }
            conn.Close();
            return result;
        }

        public void update()
        {
            nameDB = Properties.Settings.Default.MyDatabaseConnectionString;
        }
    }
}
