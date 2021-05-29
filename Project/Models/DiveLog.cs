using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture2.Models
{
    public class DiveLog 
    {
        private int IdDive;
        public int WeightsAmount { get; set; }
        public string WetsuitType { get; set; }
        public decimal OxygenAtStart { get; set; }
        public decimal OxygenAtEnd { get; set; }
        public string DiveSite { get; set; }
        DiveMeasurement diveMeasurement;

        public DiveLog(int weightsamout, string wetsuittype, decimal oxygenatstart, decimal oxygenatend, string divesite, DiveMeasurement diveMeasurement)
        {
            WeightsAmount = weightsamout;
            WetsuitType = wetsuittype;
            OxygenAtStart = oxygenatstart;
            OxygenAtEnd = oxygenatend;
            DiveSite = divesite;
            this.diveMeasurement = diveMeasurement;
        }
        public DiveLog(int weightsamout, string wetsuittype, decimal oxygenatstart, decimal oxygenatend, string divesite)
        {
            WeightsAmount = weightsamout;
            WetsuitType = wetsuittype;
            OxygenAtStart = oxygenatstart;
            OxygenAtEnd = oxygenatend;
            DiveSite = divesite;
        }
        public decimal CalculateOxygenUsage()
        {
            decimal OxygenUsage = this.OxygenAtStart - this.OxygenAtEnd;
            return OxygenUsage;
        }
        public void GetInfo()
        {
            if (this.diveMeasurement != null)
            {
                Console.WriteLine($"Weights Amount: {this.WeightsAmount} \nType of Wetsuit: {this.WetsuitType} \nDive Site: {this.DiveSite} \nUsed Oxygen: {this.CalculateOxygenUsage()} \nTime of dive: {this.diveMeasurement.DiveTime}");
            }
            Console.WriteLine($"Weights Amount: {this.WeightsAmount} \nType of Wetsuit: {this.WetsuitType} \nDive Site: {this.DiveSite} \nUsed Oxygen: {this.CalculateOxygenUsage()}");
        }
    }
}
