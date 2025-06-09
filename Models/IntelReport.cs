using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    internal class IntelReport
    {
        public int ReporterId { get; set; }
        public int TargetId { get; set; }
        public string Text { get; set; }

        public IntelReport(int reportId, int targetId, string text)
        {
            this.ReporterId = reportId;
            this.TargetId = targetId;
            this.Text = text;
        }

    }
}
