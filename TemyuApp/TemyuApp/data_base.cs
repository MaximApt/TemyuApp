using System.Data.SqlClient;
using System.Xml;

namespace TemyuApp
{
    class data_base
    {
        public void settings()
        {
            XmlDocument server_settings = new XmlDocument();
            server_settings.Load("xml/server_settings.xml");
        }

        SqlConnection connection = new SqlConnection(@"Data Source=MAX\SQLEXPRESS;Initial Catalog=dev_db;User ID=sa;Password=12345");
        public string check_c;

        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }
        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }
        public SqlConnection GetConnection()
        {
            return connection;
        }

        // Проверка соединения
        public void checkConnection()
        {
            auth auth_form = new auth();
            if (connection.State == System.Data.ConnectionState.Open)
            {
                check_c = "Соединение открыто";
            }
            else
            {
                check_c = "Соединение отсутствует";
            }
        }
    }
}
