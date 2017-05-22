using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Configuration;
using System.ServiceModel.Configuration;
using System.Net;
using System.ServiceModel;

namespace ChatServer
{
    static class Server
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //string strHostName = System.Net.Dns.GetHostName();
            //string IPAddress;
            //IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);

            //foreach (IPAddress ipAddress in ipEntry.AddressList)
            //{
            //    if (ipAddress.AddressFamily.ToString() == "InterNetwork")
            //    {
            //        IPAddress = ipAddress.ToString();
            //    }
            //}

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ChatServer());
        }
    }
}