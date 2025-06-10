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

        public void GetPersonByName(string firstname) {
            this._conn.Open();
            string query = $"SELECT * FROM people WHERE firstName = '{firstname}'";
            getPerson(query);
            this._conn.Close();
        }

        public void GetPersonBySecretCode(string secretCode) {
            this._conn.Open();
            this._query = $"SELECT * FROM people WHERE secret_code = '{secretCode}'";
            getPerson(this._query);
            this._conn.Close();
        }

        public void InsertNewPerson(Person person) {
            this._conn.Open();
            this._query = "INSERT INTO people (firstName,lastName,type,num_mentions,num_reports) VALUES (@firstName,@lastName,@type,@numMentios,@numReport)";
            try
            {
                this.cmd = new MySqlCommand(this._query, this._conn);
                this.cmd.Parameters.AddWithValue("@firstName", person.FirstName);
                this.cmd.Parameters.AddWithValue("@lastName", person.LastName);
                this.cmd.Parameters.AddWithValue("@type", person.Type);
                this.cmd.Parameters.AddWithValue("@numMentios", person.NumMentions);
                this.cmd.Parameters.AddWithValue("@numReport", person.NumReports);
                this.cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error! {ex.GetType()} : {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error! {ex.GetType()} : {ex.Message}");
            }
            this._conn.Close();
        }

        public void CreateAlert() { }

        public void GetAlerts() { }

        private List<Person> getPerson(string query)
        {

            this._query = query;
            this.cmd = new MySqlCommand(this._query, this._conn);
            MySqlDataReader reader = this.cmd.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32("id");
                    string firstName = reader.GetString("firstName");
                    string lastName = reader.GetString("lastName");
                    int numMention = reader.GetInt32("num_mentions");
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
            catch (Exception ex)
            {
                Console.WriteLine($"Error! {ex.GetType()} : {ex.Message}");
            }
            return this.peopleList;
        }

        public void ShowPeopleList()
        {
            foreach(Person person in this.peopleList)
            {
                person.ShowPerson();
            }
        }


    }
}
