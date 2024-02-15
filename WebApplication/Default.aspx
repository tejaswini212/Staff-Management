<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="returnButton" class="btn btn-default" href="/Default" runat="server" style="visibility:hidden" Text="Return"/>
    <div class="jumbotron">
        <h1>Tejaswini's App</h1>
        <p class="lead">This is a web application developed for ASU's CSE 445: Project 5.</p>
    </div>

    <div>
        <h2>Components in this Web Application</h2>
        <p>Below is a list of all the libraries, services and xml's along with various service descriptions.</p>
        <table>
            <thead>
                <tr>
                    <th colspan="4" style="text-align: center;background-color:#f8f8f8"><h3>Application and Components Summary Table</h3></th>
                </tr>
                <tr>
                    <th colspan="4">The application is deployed at: <a href="http://webstrar53.fulton.asu.edu/Page6/Default.aspx">http://webstrar53.fulton.asu/Page6/Default.aspx</a></th>
                </tr>
                <tr>
                    <th>Provider Name</th>
                    <th>Service name, with input and output types</th>
                    <th>Service Description</th>
                    <th>Actual resources used to implement the service</th>
                    <th>TryIt Link</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>Tejaswini Patil</td>
                    <td>Default page</td>
                    <td>This is the public page that includes summary table of all the resources and services in this project.</td>
                    <td><u>Resources</u>: This page uses a GUI design code and makes use of Default.aspx file in the application.
                        <br />
                        <u>Usage</u>: Default page for application.
                    </td>
                    <td> - </td>
                </tr>

                <tr>
                    <td>Tejaswini Patil</td>
                    <td>Member Dashboard Page</td>
                    <td>This page is designed to be used by members who have subscribed to the page. This page is also accessible by admins.</td>
                    <td><u>Resources</u>: This page uses a GUI design code and makes use of MemberDashboard.aspx file in the application's Member folder.<br />
                        <u>Usage</u>: Facilitates member page with different services for application.
                    </td>
                    <td> - </td>
                </tr>

                <tr>
                    <td>Tejaswini Patil</td>
                    <td>Staff Settings page</td>
                    <td>This page is designed to be used by administrative staff who already have access to the page. This page is accessible by admins of the service only.</td>
                    <td><u>Resources</u>: This page uses a GUI design code and makes use of Staff_Settings.aspx file in the application's Staff folder.<br />
                        <u>Usage</u>: Facilitates staff page with different services for application.
                    </td>
                    <td> - </td>
                </tr>
                
                <tr>
                    <td>Tejaswini Patil</td>
                    <td>Staff page 1</td>
                    <td>This is the authorization-required administrator staff page that can only be accessed by admin and admin1.</td>
                    <td><u>Resources</u>: This page uses a GUI design code and makes use of StaffPage1.aspx file in the application's Staff folder<br />
                        <u>Usage</u>: Staff page1 for application.
                    </td>
                    <td> - </td>
                </tr>

                <tr>
                    <td>Tejaswini Patil</td>
                    <td>Staff page 2</td>
                    <td>This is the authorization-required administrator staff page that can only be accessed by admin and admin2.</td>
                    <td><u>Resources</u>: This page uses a GUI design code and makes use of StaffPage1.aspx file in the application's Staff folder<br />
                        <u>Usage</u>: Staff page1 for application.
                    </td>
                    <td> - </td>
                </tr>

                <tr>
                    <td>Tejaswini Patil</td>
                    <td>Login page</td>
                    <td>This is the page facilitating log in and register functionality that utilizes forms-based security for the user control purposes.</td>
                    <td><u>Resources</u>: This page uses a GUI design code and makes use of Login.aspx page in the root folder.<br />
                        <u>Usage</u>: This page is used for the purposes of blocking unauthorized users from accessing the service.
                    </td>
                    <td> - </td>
                </tr>
                <!-- Local Component including dll component -->
                <tr>
                    <td>Tejaswini Patil</td>
                    <td>Global.asax file</td>
                    <td>This file utilizes a global event handler for displaying a welcome message and initializing the navbar according to user that is signed in.</td>
                    <td><u>Resources</u>: This page uses a GUI design code and makes use of Global.asax page in the root folder.<br />
                        <u>Usage</u>: This is used in Default.aspx i.e. main page of the application if a user is already signed in.
                    </td>
                    <td> - </td>
                </tr>
                <tr>
                    <td>Tejaswini Patil</td>
                    <td>HashingLibrary.dll file</td>
                    <td>
                        This file is a library that is used for the functionality of storing users' passwords securely via hashing.
                        <br />
                        <b>HashingAlgorithm(string password, string salt)</b><br />
                        <u>Input Parameters</u>: <samp>string</samp><br />Also makes use of a random key to ensure security<br />
                        <u>Output</u>:  <samp>string</samp> returns the hashed password
                    </td>
                    <td><u>Resources</u>: C# class and methods for creating Hashing library with HashingAlgorithm function<br />
                        <u>Usage</u>: This is used in the Login.aspx page mainly for securing and verifying user credentials.
                    </td>
                    <td><a class="btn btn-default" href="Pages_TryIt/CryptoTryIt">HashingTryIt</a></td>
                </tr>
                <!-- Data Management -->
                <tr>
                    <td>Tejaswini Patil</td>
                    <td>User profile cookie</td>
                    <td>This cookie contains the currently logged in user's information (username and password).</td>
                    <td><u>Resources</u>: None<br />
                        <u>Usage</u>: If a person doesn't sign out and tries to sign in within a time frame they may be given access to the pages depending on the timeout.
                    </td>
                    <td> Implicitly used in the web-based form used to authenticate users in Login.aspx </td>
                </tr>
                <tr>
                    <td>Tejaswini Patil</td>
                    <td>Students.xml file</td>
                    <td>This file contains list of all of the usernames and passwords of self-subscribed members/students that can use the application.</td>
                    <td><u>Resources</u>: A plain text file written in XML language. <br />
                        <u>Usage</u>: This file is linked to the MembersDashboard.aspx and Login.aspx page and the encrpytion/decryption function.
                    </td>
                    <td><asp:Button class="btn btn-default" OnClick="ViewStudentsXml" runat="server" Text="View"></asp:Button></td>
                </tr>
                <tr>
                    <td>Tejaswini Patil</td>
                    <td>Administrators.xml file</td>
                    <td>This file contains all of the usernames and passwords of pre-approved admins that can add the admins to the service.</td>
                    <td><u>Resources</u>: A plain text file written in XML language. <br />
                        <u>Usage</u>: This is linked to the Staff_Settings.aspx and Login.aspx page and the encrpytion/decryption function.
                    </td>
                    <td><asp:Button class="btn btn-default" OnClick="ViewAdminXml" runat="server" Text="View"></asp:Button></td>
                </tr>
            </tbody>
        </table>
    </div>
    <div>
        <h2>Services</h2>
        <p>The following table includes a list of our services as well as links to their respective TryIt pages.</p>
        <table>
            <thead>
                <tr>
                    <th colspan="5" style="text-align: center;background-color:#f8f8f8"><h3>Service Directory</h3></th>
                </tr>
                <tr>
                    <th>Provider Name</th>
                    <th>Service name, with input and output types</th>
                    <th>Service Description</th>
                    <th>Actual resources used to implement the service</th>
                    <th>TryIt Link</th>
                </tr>
            </thead>
            <tbody>
                <!-- Web Services -->                
                <tr>
                    <td>Tejaswini Patil</td>
                    <td>Web Downloading Service - accessible from Member Dashboard</td>
                    <td><u>Input Parameters</u>String of any web url that will possibly return smaller string withing 65536 characters<br />
                        <u>Output</u>: <samp>String</samp> of web data contained at the url
                    </td>
                    <td>This service returns the string data displayed on the web page.</td>
                    <td>-</td>
                </tr>

                <tr>
                    <td>Tejaswini Patil</td>
                    <td>Video Sharing Service - accessible from Member Dashboard</td>
                    <td><u>Input Parameters</u>: integer e.g. 5,10, etc. and then click on get video<br />
                        <u>Output</u>: Text label display of the data
                    </td>
                    <td>This service returns the number of people who have watched a particular video, and can get a count of likes and dislikes as well.</td>
                    <td>-</td>
                </tr>
                
            </tbody>
        </table>
    </div>

    <style>
        td { 
            border-bottom: 1px dotted #cccccc;
            padding: 10px;
        }

        th {
            padding: 10px;
            margin-top: 10px;
            margin-bottom: 10px;
        }

        .description {
            width: 35%;
        }
    </style>

</asp:Content>

