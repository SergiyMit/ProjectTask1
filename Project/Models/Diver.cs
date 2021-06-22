using Project.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture2.Models
{
    public partial class Diver : User, IInfo, IUser
    {
        public Diver()
        {
            DiveCertificates = new HashSet<DiveCertificate>();
            DiveMeasurements = new HashSet<DiveMeasurement>();
        }

        public int IdDiver { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Age { get; set; }
        public string Email { get; set; }
        public int? TelNumber { get; set; }
        public int? DeviceNumber { get; set; }
        public int? IdUser { get; set; }

        public virtual User IdUserNavigation { get; set; }
        public virtual ICollection<DiveCertificate> DiveCertificates { get; set; }
        public virtual ICollection<DiveMeasurement> DiveMeasurements { get; set; }
        public Diver(string name, string surname, int age, string email, int telnumber, int devicenumber, string login, string password) : base(login, password, 1)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Email = email;
            TelNumber = telnumber;
            DeviceNumber = devicenumber;
        }
        public override void GetInfo()
        {
            Console.WriteLine($"Name: {this.Name}| Surname: {this.Surname}| Age {this.Age}");
        }
    }
}
