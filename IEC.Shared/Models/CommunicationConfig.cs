using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEC.Shared.Models
{
    public class CommunicationConfig
    {
        public string ComPort { get; set; } = "COM1";

        public int BaudRate { get; set; } = 9600;

        public string Parity { get; set; } = "None";

        public int DataBits { get; set; } = 8;

        public int StopBits { get; set; } = 1;

        public byte SlaveId { get; set; } = 1;
    }
}
