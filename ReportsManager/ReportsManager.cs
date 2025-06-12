using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    internal class ReportsManager : ReportsDAL
    {
        public int GetReporterStats()
        {
            int sumWords = 0;
            foreach (IntelReport report in reportsList)
            {
                sumWords += (report.Text).Split(' ').Length;
            }

            return sumWords / reportsList.Count;
        }

        public void ShowReportsList()
        {
            foreach (IntelReport report in this.reportsList)
            {
                report.ShowReport();
            }
        }

        public int GetMinuteDifference()
        {
            if(this.reportsList.Count >= 3)
            {
                TimeSpan disdans = this.reportsList[this.reportsList.Count() - 1].DateTime - this.reportsList[this.reportsList.Count() - 3].DateTime;
                return (int)Math.Ceiling(disdans.TotalMinutes);
            }
            return 0;
        }
    }
}
