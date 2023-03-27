using Npgsql;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

// var Author = "NemoNology - Банковский А.С.";

namespace WPF
{
    class DataBaseModel
    {
        // Info for DB connection
        public string ServerIP { get; set; } = "localhost";
        public string ServerPort { get; set; } = "5432";
        public string UserID { get; set; } = "postgres";
        public string Password { get; set; } = "123";
        public string DatabaseName { get; set; } = "postgres";

        /// <summary>
        /// List of our professors
        /// </summary>
        public ObservableCollection<Professor> Professors { get; } = new ObservableCollection<Professor>();

        private NpgsqlConnection? _connection;

        public DataBaseModel()
        {
            UpdateProfessors();
        }

        /// <summary>
        /// String that needs to create connection. <br/>
        /// It's take info for DB connection and brings them all together
        /// </summary>
        /// <value> Completed string connection config for PostgreSQL DB  </value>
        public string ConnectionStringConfig
        {
            get
            {
                return $"Server={ServerIP};Port={ServerPort};" +
                    $"User ID={UserID};Password={Password};" +
                    $"Database={DatabaseName}";
            }
        }

        /// <summary>
        /// Connection to PostgreSQL DB. <br/>
        /// If there is connection already, than property return that connection, <br/>
        /// Otherwise: create a connection and return it
        /// </summary>
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

        /// <summary>
        /// Forming new PostgreSQL command
        /// </summary>
        /// <param name="postgreSQLCommand"> String, that contains PostgreSQL command </param>
        /// <param name="NeedToCloseConnection"> Chose for close/keep open connection </param>
        /// <returns> Formed PostgreSQLcommand with already established connection </returns>
        public NpgsqlCommand Command(string postgreSQLCommand, bool NeedToCloseConnection = false)
        {
            NpgsqlCommand command = new NpgsqlCommand();

            if (Connection.State == System.Data.ConnectionState.Closed)
            {
                Connection.Open();
            }

            command.Connection = Connection;
            command.CommandText = postgreSQLCommand;

            if (NeedToCloseConnection)
            {
                Connection.Close();
            }

            return command;
        }

        /// <value> Professor Table in DB columns names </value>
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
                    MessageBox.Show($"There is no table which name is {tableName}",
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

        /// <summary>
        /// Convert columns name string type to GridViewColumn type
        /// </summary>
        /// <value> New columns name collection which can be taken by Grid </value>
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

        /// <summary>
        /// Refilling professors collection using connected PostgreSQL DB
        /// </summary>
        /// <param name="columnName"> Column name by which professors will be sorted </param>
        /// <param name="IsDecrease"> Sortyng type: True - descending search <br/> False - ascending search </param>
        public void UpdateProfessors(string columnName = "ID", bool IsDecrease = false)
        {
            string sortType = IsDecrease ? "DESC" : string.Empty; 

            var command = Command($"SELECT * FROM professor ORDER BY {columnName} {sortType};");

            // Method ExecuteReader start reading data from PostgreSQL DB using inputted command
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

        /// <summary>
        /// Deleting from PostgreSQL DB and professors collection some row (professor info) with inputted ID
        /// </summary>
        /// <param name="id"> ID by which will be deleted row (professor) </param>
        public void DeleteLine(int id)
        {
            var command = Command($"DELETE FROM professor * WHERE ID = {id};");

            // Method ExecuteNonQuery use inputted command in PostgreSQL
            command.ExecuteNonQuery();

            Professors.Remove(Professors.First(x => x.ID == id));
        }

        /// <summary>
        /// Updating some row by inputted id in PostgreSQL with new inputted info 
        /// </summary>
        /// <param name="id"> ID by which will be updated row (professor) </param>
        /// <param name="newID"> New ID for updated row (professor) </param>
        /// <param name="newFirstName"> New First Name for updated row (professor) </param>
        /// <param name="newSecondName"> New Second Name for updated row (professor) </param>
        /// <param name="newAge"> New Age for updated row (professor) </param>
        /// <param name="newSex"> New Sex for updated row (professor) </param>
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

        /// <summary>
        /// Inserting new line in (end of) PostgreSQL DB
        /// </summary>
        /// <param name="newLine"> Line which contains all needed info for new row (professor) </param>
        public void InsertLine(string newLine)
        {
            var command = Command($"INSERT INTO professor VALUES ({newLine});");

            command.ExecuteNonQuery();

            UpdateProfessors();
        }

        /// <summary>
        /// Search inputted value in PostgreSQL by inputted column
        /// </summary>
        /// <param name="columnName"> Column name which will be searched value </param>
        /// <param name="searchedValue"> Searched value </param>
        /// <returns> Rows (professor) amount that contains searched value in searched column </returns>
        public int SearchValue(string columnName, string searchedValue)
        {
            var command = Command($"SELECT * FROM professor " +
                $"WHERE {columnName} = '{searchedValue}';");

            Professors.Clear();

            var er = command.ExecuteReader();

            if (er == null)
            {
                Connection.Close();
                return 0;
            }

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
                            er.GetBoolean(4)
                            ));
                }
            }

            Connection.Close();

            return Professors.Count;
        }

    }
}
