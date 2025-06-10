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

        public void GetReporterStats() { }

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
