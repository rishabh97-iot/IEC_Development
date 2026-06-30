using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEC.Shared.Models
{
    public class RegisterConfig
    {
        public string ParameterName { get; set; }

        public ushort RegisterAddress { get; set; }

        public bool IsEnabled { get; set; } = true;

        public string Unit { get; set; }

        public float ScaleFactor { get; set; } = 1;

        public int Length { get; set; } = 2;

        public string DataType { get; set; } = "Float";
    }
}
