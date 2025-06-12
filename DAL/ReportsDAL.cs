using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    internal class ReportsDAL : DAL
    {
        public List<IntelReport> reportsList = new List<IntelReport>();

        public void InsertIntelReport(IntelReport report) {
            this._conn.Open();
            this._query = "INSERT INTO intelreports (reporter_id,target_id,text) VALUES (@reportId, @targetId, @text)";
            try
            {
                this.cmd = new MySqlCommand(this._query, this._conn);
                this.cmd.Parameters.AddWithValue("@reportId", report.ReporterId);
                this.cmd.Parameters.AddWithValue("@targetId", report.TargetId);
                this.cmd.Parameters.AddWithValue("@text", report.Text);
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

        public void GetAllReports()
        {
            _conn.Open();
            this.localQuery = $"SELECT * FROM intelreports ORDER BY timestamp DESC";
            GetReports(this.localQuery);
            _conn.Close();
        }

        public void GetReportsByMalshinId(int malshinId)
        {
            _conn.Open();
            this.localQuery = $"SELECT * FROM intelreports WHERE reporter_id = '{malshinId}' ORDER BY timestamp DESC";
            GetReports(this.localQuery);
            _conn.Close();
        }

        public void GetReportsByTargetId(int targetId)
        {
            _conn.Open();
            this.localQuery = $"SELECT * FROM intelreports WHERE target_id = '{targetId}' ORDER BY timestamp DESC";
            GetReports(this.localQuery);
            _conn.Close();
        }

        public List<IntelReport> GetReports(string localQuery)
        {
            this._query = localQuery;
            try
            {
                this.cmd = new MySqlCommand(this._query, this._conn);
                MySqlDataReader reader =  cmd.ExecuteReader();
                if (!reader.Read())
                {
                    this.reportsList = new List<IntelReport>();
                }
                while (reader.Read())
                {
                    int id = reader.GetInt32("id"); 
                    int reporterId = reader.GetInt32("reporter_id"); 
                    int targetId = reader.GetInt32("target_id"); 
                    string text = reader.GetString("text"); 
                    DateTime timestamp = reader.GetDateTime("timestamp");
                    this.reportsList.Add(new IntelReport(id, reporterId, targetId, text, timestamp));
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
            return this.reportsList;
        }
    }
}
