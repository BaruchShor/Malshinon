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
        public List<Person> reportsList = new List<Person>();
        public void InsertIntelReport(IntelReport report) {
            this._query = "INSERT INTO intelreports (reportId,targetId,text) VALUES (@reportId, @targetId, @text)";
            try
            {
                this.cmd = new MySqlCommand(this._query, this._conn);
                cmd.Parameters.AddWithValue("@reportId", report.ReporterId);
                cmd.Parameters.AddWithValue("@targetId", report.TargetId);
                cmd.Parameters.AddWithValue("@text", report.Text);
                cmd.ExecuteNonQuery();
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

        public void UpdateReportCount() { }

        public void UpdateMentionCount() { }

        public void GetReporterStats() { }

        public void GetTargetStats() { }
    }
}
