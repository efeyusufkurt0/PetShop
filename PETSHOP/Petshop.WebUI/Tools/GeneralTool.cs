﻿using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;

namespace Petshop.WebUI.Tools
{
    public class GeneralTool
    {
        public static string getMD5(string _text)
        {

            using (MD5 md5 = MD5.Create())
            {

                Byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(_text));
                return BitConverter.ToString(hash).Replace("-", "");

            }
                    
                    
         }
    
    
        public static string URLConvert(string _text)
        {
            return _text.ToLower().Replace(" ", "-").Replace("ş","s").Replace("ö", "o").Replace("ü", "u").Replace("ğ", "g").Replace("ç", "c").Replace("ı", "i");

        }
    
      
    
    
    }
}
