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
        private IntelReport report { get; set; }
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

        public void GetReportsByTargetId(int targetId)
        {
            this.localQuery = $"SELECT * FROM intelreports WHERE target_id = '{targetId}'";
            GetReports(this.localQuery);
        }

        public List<IntelReport> GetReports(string localQuery)
        {
            this._query = localQuery;
            try
            {
                this.cmd = new MySqlCommand(this._query, this._conn);
                MySqlDataReader reader =  cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32("id"); 
                    int reporter_id = reader.GetInt32("id"); 
                    int target_id = reader.GetInt32("id"); 
                    string text = reader.GetString("text"); 
                    DateTime timestamp = reader.GetDateTime("timestamp");
                    reportsList.Add(new IntelReport(id, reporter_id, target_id, text, timestamp));
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

        public int GetReporterStats() {
            int sumWords = 0;
            foreach (IntelReport report in reportsList)
            {
                sumWords += (report.Text).Split(' ').Length;
            }

            return sumWords / reportsList.Count;
        }

        public void GetTargetStats() { }

        public void ShowReportsList()
        {
            foreach(IntelReport report in this.reportsList)
            {
                report.ShowReport();
            }
        }
    }
}
