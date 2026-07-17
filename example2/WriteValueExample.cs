using System;
using System.Collections.Generic;
using IEC61850.Client;
using IEC61850.Common;
using System.Threading;

namespace example2
{
    class WriteValueExample
    {
        public static void Main (string[] args)
        {
            IedConnection con = new IedConnection ();

            string hostname;

            if (args.Length > 0)
                hostname = args[0];
            else
                hostname = "172.168.1.2";

            Console.WriteLine("Connect to " + hostname);

            try
            {
                con.Connect(hostname, 102);
                //MmsVariableSpecification specification = con.GetVariableSpecification("IED_1234MEAS/MMXU1.A.phsA", FunctionalConstraint.MX);

                //Console.WriteLine(specification);
                int n = 0;
                while (n < 100)
                {
                    // MmsValue value = con.ReadValue("IED_1234MEAS/MMXU1.Hz", FunctionalConstraint.MX);
                    // MmsValue value = con.ReadValue("IED_1234MEAS/MMXU1.PPV", FunctionalConstraint.MX);
                    MmsValue PPV = con.ReadValue("IED_1234MEAS/MMXU1.PPV", FunctionalConstraint.MX);
                   // MmsValue A = con.ReadValue("IED_1234MEAS/MMXU1.A", FunctionalConstraint.MX);
                    //MmsValue PhV = con.ReadValue("IED_1234MEAS/MMXU1.PhV", FunctionalConstraint.MX);
                    Console.WriteLine("\n");
                    foreach (MmsValue v in PPV)
                    {                     
                        foreach(MmsValue v2 in v.GetElement(0)) 
                        {
                            Console.WriteLine($"{v2}");
                            
                        }
                    }
                    Thread.Sleep(500);
                    n++;
                }

                //Value -: { PPV}
                //{ { { 0} }, { { 0} }, 0000000000000, 7 / 16 / 2026 11:56:51 AM + 00:00},
                //{ { { 0} }, { { 0} }, 0000000000000, 7 / 16 / 2026 11:56:51 AM + 00:00},
                //{ { { 0} }, { { 0} }, 0000000000000, 7 / 16 / 2026 11:56:51 AM + 00:00}


                //Value -: { A}

                //{ { { 0} }, { { 0} }, 0000000000000, 7 / 16 / 2026 11:56:51 AM + 00:00},
                //{ { { 0} }, { { 0} }, 0000000000000, 7 / 16 / 2026 11:56:51 AM + 00:00},
                //{ { { 0} }, { { 0} }, 0000000000000, 7 / 16 / 2026 11:56:51 AM + 00:00},
                //{ { { 0} }, { { 0} }, 0000000000000, 7 / 16 / 2026 11:56:51 AM + 00:00}

                //Value -: { PhV }
                //{ { { 0} }, { { 0} }, 0000000000000, 7 / 16 / 2026 11:56:51 AM + 00:00},
                //{ { { 0} }, { { 0} }, 0000000000000, 7 / 16 / 2026 11:56:51 AM + 00:00},
                //{ { { 0} }, { { 0} }, 0000000000000, 7 / 16 / 2026 11:56:51 AM + 00:00},
                //{ { { 0} }, { { 0} }, 0000000000000, 7 / 16 / 2026 11:56:51 AM + 00:00}

                //Value -: {Hz}
                //{ NaN}, { NaN}, 0100001000000, 7 / 16 / 2026 11:56:51 AM + 00:00

                //Value -: {TotPF}
                //{ NaN}, { NaN}, 0100001000000, 7 / 16 / 2026 11:56:51 AM + 00:00

                //Value -: {TotVA}
                //{ 0}, { 0}, 0000000000000, 7 / 16 / 2026 11:56:51 AM + 00:00

                //Value -: {TotVAr}
                //{ 0}, { 0}, 0000000000000, 7 / 16 / 2026 11:56:51 AM + 00:00

                //Value -: {TotW}
                //{ 0}, { 0}, 0000000000000, 7 / 16 / 2026 11:56:51 AM + 00:00


                //Value -: { urcbA01 }
                //{, False, False, , 1, 0000000000, 0, 0, 000001, 0, False}

                //Value -: { urcbB01}
                //{ , False, False, , 1, 0000000000, 0, 0, 000001, 0, False}

                //Value -: { NamPlt}

                //{ SIEMENS, 04.43.16, , 160304190901000}\

                //Value -: { Beh}

                //{ 1, 0000000000000, 7 / 16 / 2026 11:56:51 AM + 00:00}

                //Value -: { Health}

                //{ 1, 0000000000000, 7 / 16 / 2026 11:56:51 AM + 00:00}


                con.Abort();
            }
            catch (IedConnectionException e)
            {
                Console.WriteLine("IED connection exception: " + e.Message + " err: " + e.GetIedClientError().ToString());
            }

			// release all resources - do NOT use the object after this call!!
			con.Dispose ();
        }
    }
}
