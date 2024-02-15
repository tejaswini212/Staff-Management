<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MemberDashboard.aspx.cs" Inherits="WebApplication.Member.MemberDashboard" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- This is the member's only page that contains access to the below services. -->
    <h2>Member Dashboard - Tejaswini's App</h2>
    <p>This is the member's only page that contains access to the below services.</p>
    <table>
        <tr>
            <td><a href="http://webstrar53.fulton.asu.edu/page2/WebForm1.aspx">Video Sharing Service</a></td>
        </tr>
        <tr><td>
            <a href="http://webstrar53.fulton.asu.edu/page4/Default.aspx"> Web Downloading Service</a>
        </td></tr>
    </table>
</asp:Content>
