using Project.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture2.Models
{
    class OxygenCalc : IOxygenCalculation
    {
        public int TimeOxygen { get; set; }
        public int DeepOxygen { get; set; }
        public int TankOxygen { get; set; }
        public int TankPreassure { get; set; }
        public OxygenCalc()
        {
        }
        public decimal CalculateDiveTime ()
        {
            if ((this.TankOxygen == null)||(this.TankPreassure == null) || (this.DeepOxygen == null))
            {
                throw new ArgumentNullException("TankOxygen, TankPreassure, DeepOxygen");
            }
            decimal result = (this.TankOxygen * this.TankPreassure) / (25 * (1 + (this.DeepOxygen/10)));
            return result;
        }
        public decimal CalculateDiveOxygen()
        {
            if ((this.TankOxygen == null) || (this.TimeOxygen == null) || (this.DeepOxygen == null))
            {
                throw new ArgumentNullException("TankOxygen, TimeOxygen, DeepOxygen");
            }
            decimal result = 50 + ((25 * this.TimeOxygen * (1 + (this.DeepOxygen / 10))) / this.TankOxygen);
            return result;
        }
    }
}
