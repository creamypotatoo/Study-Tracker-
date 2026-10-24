<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="study_tracker.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-wrap">
        <div class="card form-card">
            <div class="card-body pad-lg">
                <h3 class="text-center mb-4">🔑 Login</h3>

                <asp:Label ID="lblMessage" runat="server" CssClass="d-none"></asp:Label>

                <div class="field">
                    <label class="field-label">Email</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="input" TextMode="Email"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                        ErrorMessage="Please enter your email." CssClass="text-danger small" Display="Dynamic" ValidationGroup="login"></asp:RequiredFieldValidator>
                </div>

                <div class="field">
                    <label class="field-label">Password</label>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="input" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                        ErrorMessage="Please enter your password." CssClass="text-danger small" Display="Dynamic" ValidationGroup="login"></asp:RequiredFieldValidator>
                </div>

                <div class="field">
                    <asp:CheckBox ID="chkRemember" runat="server" Text=" Remember Me" />
                </div>

                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary btn-full" OnClick="btnLogin_Click" ValidationGroup="login" />

                <p class="text-center mt-3 mb-0">New here? <a runat="server" href="~/Register.aspx">Create an account</a></p>
                <p class="text-center mt-2 mb-0 small text-muted">Demo admin &rarr; admin@study.com / admin123</p>
            </div>
        </div>
    </div>

</asp:Content>
