using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    internal class RealThreatsManagercs : RealThreatsDAL
    {
        public void ShowRealThreats()
        {
            foreach (RealThreats realThreats in this.realThreatsList)
            {
                realThreats.ShowRealThreats();
            }
        }
    }
}
