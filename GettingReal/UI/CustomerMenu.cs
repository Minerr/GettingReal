using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public class CustomerMenu : IMenu
    {
        private static CustomerMenu instance;
        private CustomerMenu() { }
        public static CustomerMenu Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CustomerMenu();
                }

                return instance;
            }
        }

        public void ShowMenu()
        {
            
        }

        public void HandleInput(string input)
        {

        }
    }
}
}
