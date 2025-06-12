using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    internal class Login
    {
        private int Password { get; set; }
        public MenuSystem Menu { get; set; }

        public void LogIn()
        {
            this.Password = Convert.ToInt32(Console.ReadLine());
            Menu = new MenuSystem(this.Password);
            Menu.ControlMenu();
        }


    }
}
