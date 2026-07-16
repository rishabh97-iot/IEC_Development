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
                while (n < 50)
                {
                    // MmsValue value = con.ReadValue("IED_1234MEAS/MMXU1.Hz", FunctionalConstraint.MX);
                   // MmsValue value = con.ReadValue("IED_1234MEAS/MMXU1.PPV", FunctionalConstraint.MX);
                    MmsValue value = con.ReadValue("IED_1234MEAS/MMXU1.PPV", FunctionalConstraint.MX);

                    //Console.WriteLine(" Value-: "+value.ToString());
                    MmsValue mag = value.GetElement(0);

               // Console.WriteLine("mag type = " + mag.GetType());
               // Console.WriteLine("mag size = " + mag.Size());
                MmsValue ef = value.GetElement(0);
                    // Console.WriteLine(" IED_1234MEAS/MMXU1.PPV : " + ef);

                    for (int i = 0; i < mag.Size(); i++)
                    {
                        MmsValue e = mag.GetElement(i);

                        Console.WriteLine($"mag[{i}] Type={e.GetType()} Value={e}");
                    }

                    Thread.Sleep(500);
                    n++;
                }

                


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
