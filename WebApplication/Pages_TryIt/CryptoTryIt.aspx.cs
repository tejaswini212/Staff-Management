using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HashingLibrary;

namespace WebApplication.Pages_TryIt
{
    public partial class CryptoTryIt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //This function is used to hash the user entered password
        protected string hashePassword(string password)
        {
            string new_Password = "";
            string stringSalt = "7sEc?7urE!7";
            byte[] toBeHashedCode;
            UnicodeEncoding unicodeEncoding = new UnicodeEncoding(); 
            byte[] Bytes_Short = unicodeEncoding.GetBytes(password); 
            SHA1Managed sHA1Managed = new SHA1Managed(); 
            toBeHashedCode = sHA1Managed.ComputeHash(Bytes_Short);  
            foreach (byte b_ in toBeHashedCode)
            {
                new_Password += b_.ToString();
            }
            HashingFunction hashFunc = new HashingFunction();
            string res_Pass = hashFunc.HashingAlgorithm(new_Password, stringSalt);
            return res_Pass;
        }

        //This function is called whenever user clicks on the hash button
        protected void hashButton_OnClick(object sender, EventArgs e)
        {
            if (text_hashInput == null)
            {
                label_errorMsg.Text = "Invalid input! Please enter data!";
            }
            else
            {
                string output = hashePassword(text_hashInput.Text);
                label_userInput.Text = text_hashInput.Text;
                label_hashOutput.Text = output;
            }
        }
    }
}