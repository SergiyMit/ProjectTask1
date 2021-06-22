using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture2.Models
{
    public partial class CertificateLevel
    {
        public CertificateLevel()
        {
            DiveCertificates = new HashSet<DiveCertificate>();
        }

        public int IdLevel { get; set; }
        public string LevelName { get; set; }
        public int? MaxAllowedDeep { get; set; }
        public int? RequiredDives { get; set; }
        public string AdditionalInfo { get; set; }

        public virtual ICollection<DiveCertificate> DiveCertificates { get; set; }

        public CertificateLevel(string levelname, int maxalloweddeep, int requireddives, string additionalinfo)
        {
            LevelName = levelname;
            MaxAllowedDeep = maxalloweddeep;
            RequiredDives = requireddives;
            AdditionalInfo = additionalinfo;
        }

        public void ChangeLevel(int maxalloweddeep)
        {
            this.MaxAllowedDeep = maxalloweddeep;
        }
        public void ChangeLevel ( int requireddives, string additionalinfo)
        {
            this.RequiredDives = requireddives;
            this.AdditionalInfo = additionalinfo;
        }
        public Boolean IsDeepExceed(int deep)
        {
            if (deep > MaxAllowedDeep)
            {
                return true;
            }
            return false;
        }
        
    }
}
