using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HashingLibrary;

namespace WebApplication.Staff
{
    public partial class Staff_Settings : Page
    {
        //this code is run when the page is loaded
        protected void Page_Load(object sender, EventArgs e)
        {
            //initially the text to be viewed for student is set to null
            text_studentsView.Text = null;
            //initially the text to be viewed for admin is set to null
            text_adminView.Text = null;
            //initially the text to for error message is set to null
            register_ErrorMessage.Text = null;
            //select the data to be viewed for students view
            string dest_Path = HttpContext.Current.Server.MapPath(@"~/App_Data/Students.xml");
            //If the file exists in the destined path open it and display the content
            if (System.IO.File.Exists(dest_Path))
            {
                //open the file and read the file stream
                System.IO.FileStream f_stream = new System.IO.FileStream(dest_Path, System.IO.FileMode.Open);
                System.Xml.XmlDocument xml_doc = new System.Xml.XmlDocument();
                xml_doc.Load(f_stream);
                System.Xml.XmlNode root_node = xml_doc;
                System.Xml.XmlNodeList child_document = root_node.ChildNodes;
                System.Xml.XmlNodeList child_students = child_document[1].ChildNodes;
                foreach (System.Xml.XmlNode child_student in child_students)
                {
                    System.Xml.XmlNodeList credens = child_student.ChildNodes;

                    text_studentsView.Text += credens[0].InnerText + "\n";
                }
                f_stream.Close();
            }
            //select the data to be viewed for admins view
            dest_Path = HttpContext.Current.Server.MapPath(@"~/App_Data/Administrators.xml");
            //If the file exists in the destined path open it and display the content
            if (System.IO.File.Exists(dest_Path))
            {
                //open the file and read the file stream
                System.IO.FileStream f_stream = new System.IO.FileStream(dest_Path, System.IO.FileMode.Open);
                System.Xml.XmlDocument xml_doc = new System.Xml.XmlDocument();
                xml_doc.Load(f_stream);
                System.Xml.XmlNode root_node = xml_doc;
                System.Xml.XmlNodeList child_document = root_node.ChildNodes;
                System.Xml.XmlNodeList child_admins = child_document[1].ChildNodes;
                foreach (System.Xml.XmlNode child_admin in child_admins)
                {
                    System.Xml.XmlNodeList credens = child_admin.ChildNodes;

                    text_adminView.Text += credens[0].InnerText + "\n";
                }
                f_stream.Close();
            }
        }

        //Below function is used to validate if the data entered by the user is correct for creating new admins
        protected void field_Validation(Object sender, EventArgs e)
        {
            if (text_registerUser.Text.Equals("") || text_registerConfirmPass.Text.Equals("") || text_registerPass.Text.Equals(""))
            {
                register_ErrorMessage.Text = "Please try again! All fields are required.";
                if (text_registerUser.Text.Equals(""))
                {
                    text_registerUser.BackColor = System.Drawing.Color.FromArgb(252, 199, 187);
                }
                if (text_registerPass.Text.Equals(""))
                {
                    text_registerPass.BackColor = System.Drawing.Color.FromArgb(252, 199, 187);
                }
                if (text_registerConfirmPass.Text.Equals(""))
                {
                    text_registerConfirmPass.BackColor = System.Drawing.Color.FromArgb(252, 199, 187);
                }
            }
            else
            {
                if (text_registerPass.Text.Equals(text_registerConfirmPass.Text))
                {

                    if (originalUserName(text_registerUser.Text, "Administrator"))
                    {
                        addUser(text_registerUser.Text, text_registerPass.Text, "Administrator");
                        register_ErrorMessage.Text = "New Admin has been created!!";
                        Page.Response.Redirect(Page.Request.Url.ToString(), true);
                    }
                    else
                    {
                        register_ErrorMessage.Text = "User already exists in the registry!";
                    }
                }
                else
                {
                    register_ErrorMessage.Text = "Please try again! Passwords must match.";
                }
            }

        }

        //Below function is called to adduser with the user type to the respective files
        protected void addUser(string user_name, string _password, string userType)
        {
            string dest_Path = HttpContext.Current.Server.MapPath(@"~/App_Data/" + userType + "s.xml");
            //The password is hashed before storing it into the xml
            string password_hashed = hashePassword(_password);
            //if file exists open the file and save the data into an xml already existing
            if (System.IO.File.Exists(dest_Path))
            {
                System.IO.FileStream f_stream = new System.IO.FileStream(dest_Path, System.IO.FileMode.Open);
                System.Xml.XmlDocument xml_doc = new System.Xml.XmlDocument();
                xml_doc.Load(f_stream);
                System.Xml.XmlNode xml_addUser = xml_doc.CreateElement("element", userType, "");
                System.Xml.XmlNode xml_userName = xml_doc.CreateElement("Username");
                xml_userName.InnerText = user_name;
                System.Xml.XmlNode xml_passWord = xml_doc.CreateElement("Password");
                xml_passWord.InnerText = password_hashed;
                xml_addUser.AppendChild(xml_userName);
                xml_addUser.AppendChild(xml_passWord);
                System.Xml.XmlElement root_node = xml_doc.DocumentElement;
                root_node.AppendChild(xml_addUser);
                f_stream.Position = 0;
                xml_doc.Save(f_stream);
                
                //if the user is admin then allow it into the web.config so that it can access admin pages
                if (userType.Equals("Administrator"))
                {
                    dest_Path = HttpContext.Current.Server.MapPath(@"~/Staff/Web.config");
                    if (System.IO.File.Exists(dest_Path))
                    {
                        System.IO.FileStream fs_admin = new System.IO.FileStream(dest_Path, System.IO.FileMode.Open);
                        System.Xml.XmlDocument xd_admin = new System.Xml.XmlDocument();
                        xd_admin.Load(fs_admin);
                        System.Xml.XmlNodeList rootA = xd_admin.GetElementsByTagName("allow");
                        String prevList;
                        foreach (System.Xml.XmlNode node in rootA)
                        {
                            prevList = node.Attributes["users"].Value;
                            node.Attributes["users"].Value = prevList + "," + user_name;
                        }
                        fs_admin.Position = 0;
                        xd_admin.Save(fs_admin);
                        fs_admin.Close();
                    }
                }
                f_stream.Close();

            }
        }
        //below function uses hash functionality for password with student developed .dll library called HashingLibrary
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

        //This function is called to verify if the user already exists in the xml file based on the file's user type
        //If the user already exists then false is returned and true otherwise
        Boolean originalUserName(string user_name, string file)
        {
            Boolean _result = true;
            string dest_Path = HttpContext.Current.Server.MapPath(@"~/App_Data/" + file + "s.xml");

            if (System.IO.File.Exists(dest_Path))
            {
                System.IO.FileStream f_stream = new System.IO.FileStream(dest_Path, System.IO.FileMode.Open);
                System.Xml.XmlDocument xml_doc = new System.Xml.XmlDocument();
                xml_doc.Load(f_stream);
                System.Xml.XmlNode root_node = xml_doc;
                System.Xml.XmlNodeList child_document = root_node.ChildNodes;
                System.Xml.XmlNodeList user_List = child_document[1].ChildNodes;
                foreach (System.Xml.XmlNode _user in user_List)
                {
                    System.Xml.XmlNodeList credens = _user.ChildNodes;

                    if (credens[0].InnerText == user_name)
                    {
                        _result = false;
                        break;
                    }
                }
                f_stream.Close();
            }

            return _result;
        }
    }
}