using MySql.Data.MySqlClient;
using System;

namespace MySQL
{
    class Program
    {
        static void Main(string[] args)
        {
            string connStr = "Server=localhost;Database=test;Uid=root;Pwd=zzz;";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT * FROM Tab1 WHERE Id>=2";

                //ExecuteReader를 이용하여
                //연결 모드로 데이타 가져오기
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Console.WriteLine("{0}: {1}", rdr["Id"], rdr["Name"]);
                }
                rdr.Close();
            }
        }
    }
}
