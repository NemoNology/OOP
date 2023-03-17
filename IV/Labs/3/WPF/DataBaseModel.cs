using Npgsql;
using System.Collections.ObjectModel;

namespace WPF
{
    class DataBaseModel
    {
        public string ServerIP { get; set; } = "localhost";
        public string ServerPort { get; set; } = "5432";
        public string UserID { get; set; } = "postgres";
        public string Password { get; set; } = "123";
        public string DatabaseName { get; set; } = "postgres";
        public ObservableCollection<Professor> Professors { get; set; }

        private NpgsqlConnection? _connection;

        public string ConnectionStringConfig
        {
            get
            {
                return $"Server={ServerIP};Port={ServerPort};" +
                    $"User ID={UserID};Password={Password};" +
                    $"Database={DatabaseName}";
            }
        }

        public NpgsqlConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new NpgsqlConnection(ConnectionStringConfig);
                }

                return _connection;
            }
        }

        public NpgsqlCommand Command(string postgressSQLCommand)
        {
            NpgsqlCommand command = new NpgsqlCommand();

            if (_connection == null) 
                return command;

            Connection.Open();

            command.Connection = Connection;
            command.CommandText = postgressSQLCommand;

            Connection.Close();

            return command;
        }

        public void DBtoMainView()
        {
            var command = Command("SELECT * FROM Professors");
            var er = command.ExecuteReader();

            if (er == null)
                return;

            if (er.HasRows)
            {
                while (er.Read())
                {
                    Professors.Add(
                        new Professor(
                            er.GetInt32(0),
                            er.GetString(1),
                            er.GetString(2),
                            er.GetInt16(3),
                            er.GetBoolean(4),
                            er.GetString(5)
                            ));
                }
            }
            
        }
    }
}
