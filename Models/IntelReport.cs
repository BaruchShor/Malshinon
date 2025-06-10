using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    internal class IntelReport
    {
        public int NumMention { get; set; }
        public int NumReports { get; set; }
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

        public IntelReport(int numMention, int numReports ,int reportId, int targetId, string text, DateTime dateTime)
        {
            this.NumMention = numMention;
            this.NumReports = numReports;
            this.ReporterId = reportId;
            this.TargetId = targetId;
            this.Text = text;
            this.DateTime = dateTime;
        }

    }
}
