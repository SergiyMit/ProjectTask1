using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture2.Models
{
    public class DiveMeasurement
    {
        private int IdMeasurement;
        public Diver Diver { get; set; }
        public int MaxDiveDeep { get; set; }
        public int DiveTime { get; set; }
        public decimal WaterTemperature { get; set; }
        public DateTime DateOfDive { get; set; }
        public DiveMeasurement(int maxdivedeep, int divetime, decimal watertemperature, Diver diver, DateTime date)
        {
            Diver = diver;
            MaxDiveDeep = maxdivedeep;
            DiveTime = divetime;
            WaterTemperature = watertemperature;
            DateOfDive = date;
        }
        public void ExceededDeep(Boolean exceedOrNo)
        {
            if (exceedOrNo)
            {
                Notification notification = new Notification("Deep excided", "You exceed your deep", this.Diver);
            }
        }

        public void GetInfo()
        {
            Console.WriteLine($"Max deep of dive: {this.MaxDiveDeep} \nDuration of dive: {this.DiveTime} \nTemperature of water: {this.WaterTemperature} \nDive date: {this.DateOfDive}");
        }
    }
}
