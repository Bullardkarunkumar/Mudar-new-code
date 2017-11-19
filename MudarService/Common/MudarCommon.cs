using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MudarService.Common
{
    public class MudarRoles
    {
        public static string SuperAdmin = "SuperAdmin";
        public static string Branch = "Branch";
        public static string ICS = "ICS";
        public static string ICSSupplier = "ICSSupplier";
        public static string Buyer = "Buyer";
        public static string Supplier = "Supplier";
    }

    public class MudarCommon
    {
        public static string GenerateULogin(string Name)
        {
            string[] str_Split = Name.Split(' ');
            string uid = ConfigurationSettings.AppSettings["Prefix_ULogin"].ToString();
            string t1 = string.Empty;
            foreach (string t in str_Split)
            {
                t1 = t.Trim();
                if (t1.Length > 2)
                {
                    uid += t1.Substring((t1.Length - 2), 2);
                }
            }
            Random rd = new Random();

            return uid + rd.Next(1000).ToString();
        }

        public static string GeneratePassword(string password)
        {
            string[] str_Split = password.Split(' ');
            string[] newid = (Guid.NewGuid().ToString()).Split('-');
            string pwd = string.Empty, t1 = string.Empty;
            Random rmd = new Random();
            for (int count = 0; count < str_Split.Length; count++)
            {
                t1 = str_Split[count].Trim();
                if (count == 0)
                {
                    pwd += t1.Substring(0, 1);
                    pwd += newid[0].Substring(0, 4);
                    pwd += rmd.Next(10).ToString();
                }
                if (count == 1)
                {
                    pwd += t1.Substring(0, 1);
                    pwd += "$" + rmd.Next(10);
                }
            }
            return pwd;
        }
    }
}