//Begining of program
//this is a test line
using System;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;
using Microsoft.Win32;
namespace Computer
    {
    class Program
        {
        static void Main(string[] args)
            {
                
                var name = System.Environment.MachineName;
                Console.WriteLine(name);
               Console.WriteLine( PingHost(name));

            string IpAddress = Dns.GetHostName();
            Console.WriteLine(IpAddress);

            string IP =Dns.GetHostEntry(IpAddress).AddressList[4].ToString();
            Console.WriteLine("IP Address is : " + IP);
            FindByDisplayName();
            
        }

        

        private static string FindByDisplayName(RegistryKey parentKey, string name)
        {
            string[] nameList = parentKey.GetSubKeyNames();
            for (int i = 0; i < nameList.Length; i++)
            {
                RegistryKey regKey = parentKey.OpenSubKey(nameList[i]);
                try
                {
                    if (regKey.GetValue("DisplayName").ToString() == name)
                    {
                        return regKey.GetValue("installLocation").ToString();
                    }
                }
                catch { }
            }
            return " ";
        }

        //public static string HostIP()
        //{
        //    var host = Dns.GetHostEntry(Dns.GetHostName());
        //    foreach (var ip in host.AddressList)
        //    {
        //        if(ip.AddressFamily == AddressFamily.InterNetwork)
        //    }
        //}

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