using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture2.Models
{
    public class DiveCertificate
    {
        private int IdCertificate;
        public string CertNumber { get; set; }
        public DateTime DateOfIssuance { get; set; }
        public Diver Diver { get; set; }
        public CertificateLevel CertificateLevel { get; set; }
        public DiveCertificate(string certnumber, DateTime dateofissuance, Diver diver, CertificateLevel certificatelevel)
        {
            CertNumber = certnumber;
            DateOfIssuance = dateofissuance;
            Diver = diver;
            CertificateLevel = certificatelevel;
        }
    }
}
