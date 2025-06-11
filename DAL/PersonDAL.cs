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

        public void GetPersonByFullName(string firstname, string lastName) {
            this._conn.Open();
            this.localQuery = $"SELECT * FROM people WHERE firstName = '{firstname}' AND lastName = '{lastName}'";
            GetPerson(this.localQuery);
            this._conn.Close();
        }

        public void GetPersonBySecretCode(string secretCode) {
            this._conn.Open();
            this.localQuery = $"SELECT * FROM people WHERE secret_code = '{secretCode}'";
            GetPerson(this.localQuery);
            this._conn.Close();
        }

        public void UpdateReportCount(int malshintid)
        {
            this.localQuery = $"UPDATE people SET num_reports = num_reports + 1 WHERE id = '{malshintid}'";
            UpdateStatusPerson(this.localQuery);
        }

        public void UpdateMentionCount(int targetid)
        {
            this.localQuery = $"UPDATE people SET num_mentions = num_mentions + 1 WHERE id = '{targetid}'";
            UpdateStatusPerson(this.localQuery);
        }

        public void UpdateType(int targetid, string newType)
        {
            this.localQuery = $"UPDATE people SET type = '{newType}' WHERE id = '{targetid}'";
            UpdateStatusPerson(this.localQuery);
        }

        public void InsertNewPerson(Person person) {
            this._conn.Open();
            this._query = "INSERT INTO people (firstName,lastName,num_mentions,num_reports,secret_code, type) VALUES (@firstName,@lastName,@numMentios,@numReport,@secretCode,@type)";
            try
            {
                this.cmd = new MySqlCommand(this._query, this._conn);
                this.cmd.Parameters.AddWithValue("@firstName", person.FirstName);
                this.cmd.Parameters.AddWithValue("@lastName", person.LastName);
                this.cmd.Parameters.AddWithValue("@numMentios", person.NumMentions);
                this.cmd.Parameters.AddWithValue("@numReport", person.NumReports);
                this.cmd.Parameters.AddWithValue("@secretCode", person.SecretCode);
                this.cmd.Parameters.AddWithValue("@type", person.Type);
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

        private List<Person> GetPerson(string query)
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

        public void UpdateStatusPerson(string localQuery)
        {
            this._query = localQuery;
            try
            {
                this.cmd = new MySqlCommand(this._query, this._conn);
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
        }

    }
}
