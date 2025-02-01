//Begining of program
//this is a test line
using System;
using System.Net.NetworkInformation;
namespace Computer
    {
    class Program
        {
        static void Main(string[] args)
            {
                //int IpAdress;
                var name = System.Environment.MachineName;
                Console.WriteLine(name);
               Console.WriteLine( PingHost(name));

            }

        public static bool PingHost(string name)
            {
            try
                {
                    using (Ping pinger = new Ping())
                    {
                    PingReply reply = pinger.Send(name);
                    return reply.Status == IPStatus.Success;   
                    }
                }
            catch (PingException)
            {
                return false;
            }
            }










        }

    }