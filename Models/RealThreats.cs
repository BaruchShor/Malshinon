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
        public string TargetFirstName { get; set; }
        public string TargetLastName { get; set; }
        public string AlertReason { get; set; }

        public RealThreats(int id, int targetId, string firstName, string lastName, string alertReason)
        {
            this.Id = id;
            this.TargetId = targetId;
            this.TargetFirstName = firstName;
            this.TargetLastName = lastName;
            this.AlertReason = alertReason;
        }

        public RealThreats(int targetId, string alertReason)
        {
            this.TargetId = targetId;
            this.AlertReason = alertReason;
        }

        public void ShowRealThreats()
        {
            Console.WriteLine($"Report Real Threats id : {this.Id} :\n" +
                              $"Target id : {this.TargetId} :\n" +
                              $"Target full name : {this.TargetFirstName} + {this.TargetLastName}" +
                              $"Alert reason : {this.AlertReason} :\n");
        }
    }
}
