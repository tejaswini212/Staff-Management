using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using HashingLibrary;

namespace WebApplication
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //This function authenticates user's login against existing xml and returns user type
        //If the user is a normal member then student is returned
        //If the user is an admin then admin is returned
        protected string authenticate_logIn(string user_name, string _password)
        {
            string login_userType = "";
            string password_hashed = hashePassword(_password);
            string path_destination = HttpContext.Current.Server.MapPath(@"~/App_Data/Students.xml");

            if (System.IO.File.Exists(path_destination))
            {
                System.IO.FileStream f_stream = new System.IO.FileStream(path_destination, System.IO.FileMode.Open);
                System.Xml.XmlDocument xml_doc = new System.Xml.XmlDocument();
                xml_doc.Load(f_stream);
                System.Xml.XmlNode node_root = xml_doc;
                System.Xml.XmlNodeList child_document = node_root.ChildNodes;
                System.Xml.XmlNodeList child_students = child_document[1].ChildNodes;
                if (child_students == null)
                {
                    label_logInErrorMessage.Text = "Please try again! Invalid username or password.";
                }
                else
                {
                    foreach (System.Xml.XmlNode child_student in child_students)
                    {
                        System.Xml.XmlNodeList credens = child_student.ChildNodes;

                        if (credens[0] == null)
                        {
                            break;
                        }
                        else if (credens[0].InnerText == user_name && credens[1].InnerText == password_hashed)
                        {
                            login_userType = "student";
                            break;
                        }
                    }
                }
                f_stream.Close();
            }

            path_destination = HttpContext.Current.Server.MapPath(@"~/App_Data/Administrators.xml");

            if (System.IO.File.Exists(path_destination))
            {
                System.IO.FileStream f_stream = new System.IO.FileStream(path_destination, System.IO.FileMode.Open);
                System.Xml.XmlDocument xml_doc = new System.Xml.XmlDocument();
                xml_doc.Load(f_stream);
                System.Xml.XmlNode root = xml_doc;
                System.Xml.XmlNodeList child_document = root.ChildNodes;
                System.Xml.XmlNodeList child_students = child_document[1].ChildNodes;
                if (child_students == null)
                {
                    label_logInErrorMessage.Text = "Please try again! Invalid username or password.";
                }
                else
                {
                    foreach (System.Xml.XmlNode child_student in child_students)
                    {
                        System.Xml.XmlNodeList credens = child_student.ChildNodes;

                        if (credens[0] == null)
                        {
                            break;
                        }
                        else if (credens[0].InnerText == user_name && credens[1].InnerText == password_hashed)
                        {
                            login_userType = "admin";
                            break;
                        }
                    }
                }
                f_stream.Close();
            }

            return login_userType;
        }

        //This function call is made to check if the fields are properly filled
        protected void fields_Validation(Object sender, EventArgs e)
        {
            if (text_registerUsername.Text.Equals("") || text_registerConfirmPassword.Text.Equals("") || text_registerPassword.Text.Equals("") || accountType_RadioButtons.SelectedItem == null)
            {
                register_ErrorMessage.Text = "Please try again! All fields required.";
                if (text_registerUsername.Text.Equals(""))
                {
                    text_registerUsername.BackColor = System.Drawing.Color.FromArgb(252, 199, 187);
                }
                if (text_registerPassword.Text.Equals(""))
                {
                    text_registerPassword.BackColor = System.Drawing.Color.FromArgb(252, 199, 187);
                }
                if (text_registerConfirmPassword.Text.Equals(""))
                {
                    text_registerConfirmPassword.BackColor = System.Drawing.Color.FromArgb(252, 199, 187);
                }
            }
            else
            {
                if (text_registerPassword.Text.Equals(text_registerConfirmPassword.Text))
                {
                    if (originalUserName(text_registerUsername.Text, accountType_RadioButtons.SelectedValue))
                    {
                        string userType = accountType_RadioButtons.SelectedValue;
                        string pass = hashePassword(text_registerPassword.Text);
                        xml_addUser(text_registerUsername.Text, pass, userType);
                        FormsAuthentication.RedirectFromLoginPage(text_registerUsername.Text, CheckBox_rememberMe.Checked);
                    }
                    else
                    {
                        register_ErrorMessage.Text = "User already exists!";
                    }

                }
                else
                {
                    register_ErrorMessage.Text = "Passwords do not match.";
                }
            }

        }

        //This function hashes the password entered by user
        protected string hashePassword(string password)
        {
            string newPass = "";
            string salt = "KW?OEfw9";
            byte[] hashCode;
            UnicodeEncoding Uce = new UnicodeEncoding(); // UnicodeEncoding object
            byte[] BytesShort = Uce.GetBytes(password); // convert to byte array
            SHA1Managed SHhash = new SHA1Managed(); //Create a SHA1 object
            hashCode = SHhash.ComputeHash(BytesShort); // Hashing 
            foreach (byte b in hashCode)
            {
                newPass += b.ToString();
            }
            HashingFunction newHashAction = new HashingFunction();
            string endPass = newHashAction.HashingAlgorithm(newPass, salt);
            return endPass;
        }

        //This function is used to add the user along with hashed password to the xml of appropriate user type
        protected void xml_addUser(string user_name, string _password, string user_Type)
        {
            string dest_Path = HttpContext.Current.Server.MapPath(@"~/App_Data/" + user_Type + "s.xml");

            if (System.IO.File.Exists(dest_Path))
            {
                System.IO.FileStream f_stream = new System.IO.FileStream(dest_Path, System.IO.FileMode.Open);
                System.Xml.XmlDocument xml_doc = new System.Xml.XmlDocument();
                xml_doc.Load(f_stream);

                System.Xml.XmlNode add_User = xml_doc.CreateElement("element", user_Type, "");
                System.Xml.XmlNode xml_userName = xml_doc.CreateElement("Username");
                xml_userName.InnerText = user_name;
                System.Xml.XmlNode xml_passWord = xml_doc.CreateElement("Password");
                xml_passWord.InnerText = _password;
                add_User.AppendChild(xml_userName);
                add_User.AppendChild(xml_passWord);
                System.Xml.XmlElement xml_root = xml_doc.DocumentElement;
                xml_root.AppendChild(add_User);
                f_stream.Position = 0;
                xml_doc.Save(f_stream);


                if (user_Type.Equals("Administrator"))
                {
                    dest_Path = HttpContext.Current.Server.MapPath(@"~/Staff/Web.config");
                    if (System.IO.File.Exists(dest_Path))
                    {
                        System.IO.FileStream fs_admin = new System.IO.FileStream(dest_Path, System.IO.FileMode.Open);
                        System.Xml.XmlDocument xd_admin = new System.Xml.XmlDocument();
                        xd_admin.Load(fs_admin);
                        System.Xml.XmlNodeList root_admin = xd_admin.GetElementsByTagName("allow");
                        String prev_List;
                        foreach (System.Xml.XmlNode node in root_admin)
                        {
                            prev_List = node.Attributes["users"].Value;
                            node.Attributes["users"].Value = prev_List + "," + user_name;
                        }
                        fs_admin.Position = 0;
                        xd_admin.Save(fs_admin);
                        fs_admin.Close();
                    }
                }
                f_stream.Close();

            }
        }

        //This function checks if the user name is already existant in the file
        protected Boolean originalUserName(string user_name, string file)
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
                if (user_List == null)
                {
                    return _result;
                }
                else
                {
                    foreach (System.Xml.XmlNode user in user_List)
                    {
                        System.Xml.XmlNodeList credens = user.ChildNodes;

                        if (credens[0] == null)
                        {
                            break;
                        }
                        else if (credens[0].InnerText == user_name)
                        {
                            _result = false;
                            break;
                        }
                    }
                }
                f_stream.Close();
            }

            return _result;
        }

        //This fucntion is called when the user clicks on the login button
        protected void logIn_OnClick(object sender, EventArgs e)
        {
            if (authenticate_logIn(text_loginUsername.Text, text_loginPassword.Text) != "")
            {
                FormsAuthentication.RedirectFromLoginPage(text_loginUsername.Text, CheckBox_rememberMe.Checked);
                label_logInErrorMessage.Text = "";
            }
            else
            {
                label_logInErrorMessage.Text = "Please try again! Invalid username or password.";
            }
        }
    }
}