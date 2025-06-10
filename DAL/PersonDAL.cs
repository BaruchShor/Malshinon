using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    internal class PersonDAL : DAL
    {
        public List<Person> peopleList = new List<Person>();

        public void GetPersonByName(int firstname) {

            this._query = "SELECT * FROME people WHERE firstname = @firstname";
            this.cmd = new MySqlCommand(this._query, this._conn);
            cmd.Parameters.AddWithValue("@agentId", firstname);
            getPerson(this._query);

        }

        public void GetPersonBySecretCode(string secretCode) {
            this._query = "SELECT * FROME people WHERE secretcode = @secretCode";
            this.cmd = new MySqlCommand(this._query, this._conn);
            cmd.Parameters.AddWithValue("@agentId", secretCode);
            getPerson(this._query);
        }

        public void InsertNewPerson(Person person) {
            this._query = "INSERT INTO people (firstName,lastName,type,numMentios,numReport) VALUES (@firstName,@lastName,@type,@numMentios,@numReport)";
            try
            {
                this.cmd = new MySqlCommand(this._query, this._conn);
                cmd.Parameters.AddWithValue("@firstName", person.FirstName);
                cmd.Parameters.AddWithValue("@lastName", person.LastName);
                cmd.Parameters.AddWithValue("@type", person.Type);
                cmd.Parameters.AddWithValue("@numMentios", person.NumMentions);
                cmd.Parameters.AddWithValue("@numReport", person.NumReports);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error! {ex.GetType()} : {ex.Message}");
            }
        }

        public void CreateAlert() { }

        public void GetAlerts() { }

        private List<Person> getPerson(string query)
        {
            this._query = query;
            this.cmd = new MySqlCommand(this._query, this._conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32("id");
                    string firstName = reader.GetString("firstName");
                    string lastName = reader.GetString("lastName");
                    int numMention = reader.GetInt32("num_mention");
                    int numReports = reader.GetInt32("num_reports");
                    string secretCode = reader.GetString("secret_code");
                    string type = reader.GetString("type");
                    peopleList.Add(new Person(id, firstName, lastName, numMention, numReports, secretCode, type));
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error! {ex.GetType()} : {ex.Message}");
            }
            return peopleList;
        }


    }
}
