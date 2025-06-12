using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    internal class RealThreatsDAL : DAL
    {
        public List<RealThreats> realThreatsList = new List<RealThreats>();

        public void InsertRealThreats(RealThreats realThreats)
        {
            this._conn.Open();
            this._query = "INSERT INTO real_threats (target_id,alert_reason) VALUES (@targetId, @alertReason)";
            try
            {
                this.cmd = new MySqlCommand(this._query, this._conn);
                this.cmd.Parameters.AddWithValue("@targetId", realThreats.TargetId);
                this.cmd.Parameters.AddWithValue("@alertReason", realThreats.AlertReason);
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

        public void GetAllRealThreats()
        {
            _conn.Open();
            this.localQuery = $"SELECT * FROM real_threats";
            GetRealThreats(this.localQuery);
            _conn.Close();
        }

        public void GetRealThreatsByTargetId(int targetId)
        {
            _conn.Open();
            this.localQuery = $"SELECT * FROM real_threats r JOIN people p ON r.target_id = p.id WHERE r.target_id = '{targetId}'";
            GetRealThreats(this.localQuery);
            _conn.Close();
        }

        public List<RealThreats> GetRealThreats(string localQuery)
        {
            this._query = localQuery;
            try
            {
                this.cmd = new MySqlCommand(this._query, this._conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32("id");
                    int targetId = reader.GetInt32("target_id");
                    string targetFirstName = reader.GetString("firstName");
                    string targetLastName = reader.GetString("lastName");
                    string alertReason = reader.GetString("alert_reason");
                    this.realThreatsList.Add(new RealThreats(id, targetId, targetFirstName, targetLastName, alertReason));
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error! : {ex.GetType()} == {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error! : {ex.GetType()} == {ex.Message}");
            }
            return this.realThreatsList;
        }
    }
}
