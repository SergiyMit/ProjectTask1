using Lecture2.Models;
using System;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
           Diver diver = new Diver("DiverName1","DiverSurname1",20,"diver1@gmail.com",123321,1,"Diver1", "123qwe");
           Admin admin = new Admin("AdminName1", "AdminSurname1", 13312321, "Admin1", "123qwe");
            diver.DisplayInfo();
            admin.DisplayInfo();

            CertificateLevel OpenWater = new CertificateLevel("Open Water Diver", 15,20, "");
            CertificateLevel AdvancedOpenWater = new CertificateLevel("Advanced Open Water Diver", 30, 45, "");
            DiveCertificate diverCertificate1 = new DiveCertificate("UA123456", DateTime.Now, diver, OpenWater);
            OxygenCalc neededOxygen = new OxygenCalc();
            neededOxygen.TimeOxygen = 2;
            neededOxygen.DeepOxygen = 25;
            neededOxygen.TankOxygen = 30;
            Console.WriteLine(neededOxygen.CalculateDiveOxygen());

            OxygenCalc diveTime = new OxygenCalc();
            diveTime.TankPreassure = 4;
            diveTime.DeepOxygen = 25;
            diveTime.TankOxygen = 30;
            Console.WriteLine(diveTime.CalculateDiveTime());

            DiveMeasurement diveMeasurement = new DiveMeasurement(23,35,14, diver, DateTime.Now);
            diveMeasurement.GetInfo();

            DiveLog diveLog = new DiveLog(3, "Warm", 123, 23, "Maldives", diveMeasurement);
            DiveLog diveLogWithOutMeasurement = new DiveLog(2, "Cold", 54, 12, "UAE");
            diveLog.GetInfo();
            diveLogWithOutMeasurement.GetInfo();

        }
    }
}
