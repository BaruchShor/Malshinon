using MySql.Data.MySqlClient;

namespace Malshinon
{
    public class DAL
    {
        public string connStr { get; set; }
        public string _query { get; set; }
        public string localQuery { get; set; }
        public MySqlConnection _conn { get; set; }
        public MySqlCommand cmd { get; set; }

        public void MalshinonDBConnection()
        {
            this.connStr = "server=localhost;username=root;password=;database=malshinon";
            this._conn = new MySqlConnection(connStr);
        }
        public DAL()
        {
            MalshinonDBConnection();
        }
    }
}