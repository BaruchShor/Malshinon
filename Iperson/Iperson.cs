using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    internal interface Iperson
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        bool IsExsist();
        void ShowPeopleList();
        void UpdateTypePerson();
    }
}
