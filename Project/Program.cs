using Lecture2.Models;
using System;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System.Linq;

namespace Project
{
    class Program
    {

        static void Main(string[] args)
        {
            Diver diver1 = new Diver("DiverName1", "DiverSurname1", 20, "diver1@gmail.com", 123321, 1, "Diver1", "123qwe");
            Diver diver2 = new Diver("DiverName2", "DiverSurname2", 321, "diver2gmail.com", 123321, 1, "Diver2", "123q31we");
            List<Diver> divers = new List<Diver>();
            divers.Add(diver1);
            divers.Add(diver2);
            AsynSaveDiverInfo(divers);
            AsyncLoadDiverInfo();
            Console.WriteLine("------------------");
            Console.ReadLine();



            Diver diver = new Diver("DiverName1", "DiverSurname1", 20, "diver1@gmail.com", 123321, 1, "Diver1", "123qwe");
            Admin admin = new Admin("AdminName1", "AdminSurname1", 13312321, "Admin1", "123qwe");
            admin.GetInfo();

            CertificateLevel OpenWater = new CertificateLevel("Open Water Diver", 15, 20, "");
            CertificateLevel AdvancedOpenWater = new CertificateLevel("Advanced Open Water Diver", 30, 45, "");
            try
            {
                OxygenCalc neededOxygen = new OxygenCalc();
                neededOxygen.TimeOxygen = 2;
                neededOxygen.DeepOxygen = 25;
                neededOxygen.TankOxygen = 30;
                Console.WriteLine(neededOxygen.CalculateDiveOxygen());
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Wrong data");
            }
            try
            {
                OxygenCalc diveTime = new OxygenCalc();
                diveTime.TankPreassure = 4;
                diveTime.DeepOxygen = 25;
                diveTime.TankOxygen = 30;
                Console.WriteLine(diveTime.CalculateDiveTime());
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Wrong data");
            }


            DiveLog diveLogWithOutMeasurement = new DiveLog(2, "Cold", 54, 12, "UAE");
            diveLogWithOutMeasurement.GetInfo();

        }
        public static void SaveDiverInfo(List<Diver> divers)
        {
            string json = JsonConvert.SerializeObject(divers);
            Thread.Sleep(3000);
            using (FileStream fs = new FileStream("diver.json", FileMode.OpenOrCreate)) ;
            using (StreamWriter writer = new StreamWriter("diver.json"))
            {
                writer.WriteLine(json);
            }

        }
        public async static Task AsynSaveDiverInfo(List<Diver> divers)
        {
            Task.Run(() => SaveDiverInfo(divers));
        }
        public static List<Diver> LoadDiverInfo()
        {
            string json;
            using (StreamReader reader = new StreamReader("diver.json"))
            {
                json = reader.ReadToEnd();
                var divers = JsonConvert.DeserializeObject<List<Diver>>(json);
                foreach (Diver diver in divers)
                {
                    string regex = @"(\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)";
                    if (Regex.IsMatch(diver.Email, regex))
                    {
                        Console.WriteLine($"Name: {diver.Name} | Surname: {diver.Surname}");
                    }
                }
                return divers;
            }

        }
        public async static Task<List<Diver>> AsyncLoadDiverInfo()
        {
            return await Task.Run(() => LoadDiverInfo());
        }

        ////////Database Functions/////////////////

        public static IEnumerable<Diver> GetDiverFromDB()
        {
            NixDatabaseContext context = new NixDatabaseContext();
            var result = from divers in context.Divers select divers;
            return result;
        }

        public static IEnumerable<DiveCertificate> GetCertificateByDiverEmail(string email)
        {
            NixDatabaseContext context = new NixDatabaseContext();
            var result = context.DiveCertificates.Where(x => x.IdDiver == (context.Divers.Where(x => x.Email == email).Select(x => x.IdDiver).FirstOrDefault()));
            return result;
        }

        public static string DeleteUserWithId(int Id)
        {
            try
            {
                NixDatabaseContext context = new NixDatabaseContext();
                string diverName = context.Divers.Where(d => d.IdDiver == Id).Select(d => d.Name).First();
                string diverSurname = context.Divers.Where(d => d.IdDiver == Id).Select(d => d.Surname).First();
                var measurement = (from Measurements in context.DiveMeasurements where Measurements.IdDiver == Id select Measurements).ToList();
                var certificate = context.DiveCertificates.Where(c => c.IdDiver == Id).Select(c => c).ToList();
                var IdUser = (from Divers in context.Divers where Divers.IdDiver == Id select Divers.IdUser).First();
                var users = (from Users in context.Users where Users.IdUser == IdUser select Users).ToList();
                var divers = (from Divers in context.Divers where Divers.IdDiver == Id select Divers).ToList();
                context.DiveMeasurements.RemoveRange(measurement);
                context.DiveCertificates.RemoveRange(certificate);
                context.Divers.RemoveRange(divers);
                context.Users.RemoveRange(users);
                context.SaveChanges();
                return $"Diver with Name: {diverName} and Surname: {diverSurname} succesfully deleted";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public static string UpdateDiver(Diver diverForUpdate)
        {
            NixDatabaseContext context = new NixDatabaseContext();
            var diver = context.Divers.Where(d => d.IdDiver == diverForUpdate.IdDiver).Select(d => d).First();
            diver.Name = diverForUpdate.Name;
            diver.Surname = diverForUpdate.Surname;
            diver.TelNumber = diverForUpdate.TelNumber;
            diver.Email = diverForUpdate.Email;
            diver.Age = diverForUpdate.Age;
            context.Update(diver);
            context.SaveChanges();
            return "Succesfully updated";
        }

    }
}
