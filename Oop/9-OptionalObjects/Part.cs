
using System;

namespace Oop._9_OptionalObjects
{
    class Part
    {
        public DateTime InstallmentDate { get;  }
        public DateTime DefectDetectedOn { get; set; }

        public Part(DateTime installmentDate)
        {
            InstallmentDate = installmentDate;
        }

        public void MarkAsDefective(DateTime withDate)
        {
            DefectDetectedOn = withDate;
        }
    }
}
