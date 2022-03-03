using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace Control
{
    class DBconnect
    {
       static string conString = "server=87.249.53.69;user=krotov;database=krotov;password=D8YHK6ga!;charset=utf8";

        private MySqlConnection con;

        public MySqlConnection Connection()
        {   
            con = new MySqlConnection(conString);

            return con;
        }

        public void OpenCon()
        {
            con.Open();
        }

        public void CloseCon()
        {
            con.Close();
        }

        public MySqlDataAdapter Adapter(string query)
        {
            return new MySqlDataAdapter(query, Connection());
        }

        public MySqlDataAdapter Adapter()
        {
            return new MySqlDataAdapter();
        }

        public DataSet GetDataSet()
        {
            return new DataSet();
        }
    }
}
