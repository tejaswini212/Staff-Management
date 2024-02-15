<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CryptoTryIt.aspx.cs" Inherits="WebApplication.Pages_TryIt.CryptoTryIt" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<div class="row">
        <div>
            <h2>
                Hashing Try It Page</h2>
            <p>This service uses local component a built in HashingLibrary and uses <samp>HashingAlgorithm(string password, string salt)</samp> to take input text, typically a password, and hash the text to provide a layer of security when storing passwords and user information.</p>
        </div>
    <h3>Input text to be hashed.</h3>
                 <table>
                        <tr>
                            <td><b>Input: </b></td>
                            <td><asp:TextBox ID="text_hashInput" runat="server" TextMode="SingleLine"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><asp:Button ID="button_hash" runat="server" Text="Click to hash" OnClick="hashButton_OnClick" /></td>
                        </tr>
                 </table>
                               
                <br />
                <div style="text-align:center;">
                <asp:Label ID="label_errorMsg" runat="server" Text="" CssClass="text-danger"></asp:Label>
                    <hr />
                    <table">
                        <tr>
                            <td><b>User Input: </b></td>
                            <td><asp:Label ID="label_userInput" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td><b>Hashed User Input: </b></td>
                            <td><asp:Label ID="label_hashOutput" runat="server"></asp:Label></td>
                        </tr>
                 </table>
                </div>
    </div>

</asp:Content>
