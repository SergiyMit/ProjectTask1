using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture2.Models
{
    public partial class DiveMeasurement
    {
        public int IdMeasurement { get; set; }
        public int? MaxDiveDeep { get; set; }
        public int? DiveTime { get; set; }
        public decimal? WaterTemperature { get; set; }
        public DateTime? DateOfDive { get; set; }
        public int? IdDiver { get; set; }
        public virtual Diver IdDiverNavigation { get; set; }

        public DiveMeasurement(int maxdivedeep, int divetime, decimal watertemperature, DateTime date)
        {
            MaxDiveDeep = maxdivedeep;
            DiveTime = divetime;
            WaterTemperature = watertemperature;
            DateOfDive = date;
        }
      /*  public void ExceededDeep(Boolean exceedOrNo)
        {
            if (exceedOrNo)
            {
                Notification notification = new Notification("Deep excided", "You exceed your deep", this.Diver);
            }
        }*/

        public void GetInfo()
        {
            Console.WriteLine($"Max deep of dive: {this.MaxDiveDeep} \nDuration of dive: {this.DiveTime} \nTemperature of water: {this.WaterTemperature} \nDive date: {this.DateOfDive}");
        }
    }
}
