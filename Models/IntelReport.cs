using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    internal class IntelReport
    {
        public int Id { get; set; }
        public int ReporterId { get; set; }
        public int TargetId { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }

        public IntelReport(int reportId, int targetId, string text)
        {
            this.ReporterId = reportId;
            this.TargetId = targetId;
            this.Text = text;
        }

        public IntelReport(int id, int reportId, int targetId, string text, DateTime dateTime)
        {
            this.Id = id;
            this.ReporterId = reportId;
            this.TargetId = targetId;
            this.Text = text;
            this.DateTime = dateTime;
        }

        public void ShowReport()
        {
            Console.WriteLine($"Report id : {this.ReporterId}:\n" +
                              $"Target id : {this.TargetId}\n" +
                              $"Text : {this.Text}\n" +
                              $"Date time: {this.DateTime}");
        }
    }
}
