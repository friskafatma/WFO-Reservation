using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using WFHReserveAPI.Models;

namespace WFHReserveAPI.ViewModel
{
    public class ClsLogin
    {
        DB_WFHReserveDataContext db = new DB_WFHReserveDataContext();

        public string nrp { get; set; }
        public string password { get; set; }

        public bool Login()
        {
            bool status = false;

            var cek = db.TBL_USERs.Where(x => x.nrp == nrp).SingleOrDefault();
            if (cek != null)
            {
                bool isMatch = VerifyMD5Hash(password, cek.password);


                if (isMatch)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
                    
                
            }
            else
            {
                status = false;
            }

            return status;

        }

        static string GenerateMD5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2")); // Format heksadesimal
                }

                return sb.ToString();
            }
        }

        static bool VerifyMD5Hash(string input, string hash)
        {
            string inputHash = GenerateMD5Hash(input);
            return string.Equals(inputHash, hash, StringComparison.OrdinalIgnoreCase);
        }


    }
}