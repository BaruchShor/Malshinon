using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    internal class RealThreatsManager : RealThreatsDAL
    {
        public string ReportsReason { get; set; }
        public RealThreats RealThreats { get; set; }

        public void CreateReport(int targetId, string reason)
        {
            this.ReportsReason = reason;
            this.RealThreats = new RealThreats(targetId, this.ReportsReason);
            InsertRealThreats(RealThreats);
        }

        public void ShowRealThreats()
        {
            foreach (RealThreats realThreats in this.realThreatsList)
            {
                realThreats.ShowRealThreats();
            }
        }
    }
}
