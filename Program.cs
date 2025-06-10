using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IntelReport report = new IntelReport(1, 1, "moshe is not normal");
            ReportsDAL reportDAL = new ReportsDAL();
            reportDAL.InsertIntelReport(report);
            //Person person = new Person("Baruch", "Shor", "reporter", 1, 2);
            //PersonDAL personDAL = new PersonDAL();
            //personDAL.InsertNewPerson(person);

        }
    }
}
