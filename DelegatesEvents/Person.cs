using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEvents
{
    class Person
    {
        public event EventHandler ToGoSleeping;
        public event EventHandler ToGoWorking;

        public string Name { get; set; }
        
        public void TakeTime(DateTime now)
        {
            if (now.Hour < 8 && now.Hour > 23)
            {
                ToGoSleeping?.Invoke(this, null);
            }
            else
            {
                ToGoWorking?.Invoke(this, null);
            }
        }
    }
}
