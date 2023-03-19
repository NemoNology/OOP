using Npgsql;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WPF
{
    class DataBaseModel
    {
        public string ServerIP { get; set; } = "localhost";
        public string ServerPort { get; set; } = "5432";
        public string UserID { get; set; } = "postgres";
        public string Password { get; set; } = "123";
        public string DatabaseName { get; set; } = "postgres";
        public ObservableCollection<Professor> Professors { get; } = new ObservableCollection<Professor>();

        private NpgsqlConnection? _connection;

        public DataBaseModel()
        {
            UpdateProfessors();
        }

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

        public NpgsqlCommand Command(string postgressSQLCommand, bool NeedToKeepOpenConnection = false)
        {
            NpgsqlCommand command = new NpgsqlCommand();

            if (Connection.State == System.Data.ConnectionState.Closed)
            {
                Connection.Open();
            }

            command.Connection = Connection;
            command.CommandText = postgressSQLCommand;

            if (NeedToKeepOpenConnection)
            {
                Connection.Close();
            }

            return command;
        }

        public List<string> ColumnsNames
        {
            get
            {
                var tableName = "professor";

                List<string> tableNames = new List<string>();

                var command = Command($"SELECT column_name FROM information_schema.columns WHERE table_name = '{tableName}' ORDER BY ordinal_position ASC;");
                var er = command.ExecuteReader();

                if (er == null)
                {
                    MessageBox.Show($"There is no table wich name is {tableName}",
                        "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    Connection.Close();
                    return tableNames;
                }

                while (er.Read())
                {
                    tableNames.Add(er.GetString(0));
                }

                Connection.Close();

                return tableNames;
            }
        }

        public GridViewColumnCollection ColumnNamesForGrid
        {
            get
            {
                var columnNames = ColumnsNames;

                GridViewColumnCollection res = new GridViewColumnCollection();

                foreach (var item in columnNames)
                {
                    GridViewColumn buffer = new GridViewColumn();
                    buffer.Header = item;

                    res.Add(buffer);
                }

                return res;
            }
        }

        public void UpdateProfessors(string columnName = "ID", bool IsDecrease = false)
        {
            string sortType = IsDecrease ? "DESC" : string.Empty; 

            var command = Command($"SELECT * FROM professor ORDER BY {columnName} {sortType};");
            var er = command.ExecuteReader();

            if (er == null)
            {
                Connection.Close();
                return;
            }

            if (er.HasRows)
            {
                Professors.Clear();

                while (er.Read())
                {
                    Professors.Add(
                        new Professor(
                            er.GetInt32(0),
                            er.GetString(1),
                            er.GetString(2),
                            er.GetInt16(3),
                            er.GetBoolean(4)
                            ));
                }
            }

            Connection.Close();
        }

        public void DeleteLine(int id)
        {
            var command = Command($"DELETE FROM professor * WHERE ID = {id};");

            command.ExecuteNonQuery();

            Professors.Remove(Professors.First(x => x.ID == id));
        }

        public void UpdateLine(int id, int newID, string newFirstName, string newSecondName, short newAge, bool newSex)
        {
            var columnsNames = ColumnsNames;

            var sex = newSex ? 1 : 0;

            var command = Command($"UPDATE professor " +
                $"SET {columnsNames[0]} = {newID}, " +
                $"{columnsNames[1]} = '{newFirstName}', " +
                $"{columnsNames[2]} = '{newSecondName}', " +
                $"{columnsNames[3]} = {newAge}, " +
                $"{columnsNames[4]} = '{sex}' " +
                $"WHERE ID = {id};");

            command.ExecuteNonQuery();

            UpdateProfessors();
        }

        public void InsertLine(string newLine)
        {
            var command = Command($"INSERT INTO professor VALUES ({newLine});");

            command.ExecuteNonQuery();

            UpdateProfessors();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}
