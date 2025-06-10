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
            PersonDAL personDAL = new PersonDAL();
            personDAL.GetPersonByName("ppp");
            Console.WriteLine(personDAL.peopleList.Count());
            personDAL.GetPersonBySecretCode("dddd");

        }
    }
}
