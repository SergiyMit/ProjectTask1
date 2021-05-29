using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture2.Models
{
    class OxygenCalc
    {
        public int TimeOxygen {  get; set; }
        public int DeepOxygen {  get; set; }
        public int TankOxygen { get; set; }
        public int TankPreassure { get; set; }

        public OxygenCalc()
        {
        }
        public decimal CalculateDiveTime ()
        {
            decimal result = (this.TankOxygen * this.TankPreassure) / (25 * (1 + (this.DeepOxygen/10)));
            return result;
        }
        public decimal CalculateDiveOxygen()
        {
            decimal result = 50 + ((25 * this.TimeOxygen * (1 + (this.DeepOxygen / 10))) / this.TankOxygen);
            return result;
        }
    }
}
