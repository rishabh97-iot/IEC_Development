using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEC.Shared.IECModels
{
    public class RelayReadingModel
    {
        public bool IsOnline { get; set; }
        public string ErrorMessage { get; set; }
        public int RelayId { get; set; }
        public string RelayName { get; set; }

        // Config-driven values — ParameterName → Value
        // eg: "Hz" → 50.07, "PhV_A" → 7.5
        public Dictionary<string, float> Values { get; set; } = new();

        // Convenience properties (backward compatible)
        public float Hz => Values.GetValueOrDefault("Hz");
        public float PhV_A => Values.GetValueOrDefault("PhV_A");
        public float PhV_B => Values.GetValueOrDefault("PhV_B");
        public float PhV_C => Values.GetValueOrDefault("PhV_C");
        public float PPV_AB => Values.GetValueOrDefault("PPV_AB");
        public float PPV_BC => Values.GetValueOrDefault("PPV_BC");
        public float PPV_CA => Values.GetValueOrDefault("PPV_CA");
        public float A_PhsA => Values.GetValueOrDefault("A_PhsA");
        public float A_PhsB => Values.GetValueOrDefault("A_PhsB");
        public float A_PhsC => Values.GetValueOrDefault("A_PhsC");
        public float TotW => Values.GetValueOrDefault("TotW");
        public float TotVA => Values.GetValueOrDefault("TotVA");
        public float TotVAr => Values.GetValueOrDefault("TotVAr");
        public float TotPF => Values.GetValueOrDefault("TotPF");
    }

}
