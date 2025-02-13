using MySql.Data.MySqlClient;
using System;

namespace UAS_PBO.controller
{
    internal class Connection
    {
        string conectionstring = "Server=localhost; Database=pbo_rentalaudio; Uid=root; Pwd=;";
        MySqlConnection kon;

        public void OpenConnection()
        {
            kon = new MySqlConnection(conectionstring);
            kon.Open();
        }

        public void CloseConnection()
        {
            kon.Close();
        }

        public void ExecuteQueries(string Query_)
        {
            MySqlCommand cmd = new MySqlCommand(Query_, kon);
            cmd.ExecuteNonQuery();
        }

        public object ShowData(string Query_)
        {
            MySqlCommand cmd = new MySqlCommand(Query_, kon);
            return cmd.ExecuteScalar();
        }

        public MySqlDataReader reader(string Query_)
        {
            MySqlCommand cmd = new MySqlCommand(Query_, kon);
            MySqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

        internal string GenerateID(string v1, string v2)
        {
            throw new NotImplementedException();
        }
    }
}
