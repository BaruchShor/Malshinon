using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    internal class RealThreats
    {
        public int Id { get; set; }
        public int TargetId { get; set; }
        public string AlertReason { get; set; }

        public RealThreats(int id, int targetId, string alertReason)
        {
            this.Id = id;
            this.TargetId = targetId;
            this.AlertReason = alertReason;
        }

        public RealThreats(int targetId, string alertReason)
        {
            this.TargetId = targetId;
            this.AlertReason = alertReason;
        }

        public void ShowRealThreats()
        {
            Console.WriteLine($"Report id : {this.Id} :\n" +
                              $"Target id : {this.TargetId} :\n" +
                              $"Text : {this.AlertReason} :\n");
        }
    }
}
