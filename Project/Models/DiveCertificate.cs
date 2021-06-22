using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture2.Models
{
    public partial class DiveCertificate
    {
        public int IdCertificate { get; set; }
        public string CertNumber { get; set; }
        public DateTime? DateOfIssuance { get; set; }
        public int? IdLevel { get; set; }
        public int? IdDiver { get; set; }

        public virtual Diver IdDiverNavigation { get; set; }
        public virtual CertificateLevel IdLevelNavigation { get; set; }
        public DiveCertificate(string certnumber, DateTime dateofissuance)
        {
            CertNumber = certnumber;
            DateOfIssuance = dateofissuance;

        }
    }
}
