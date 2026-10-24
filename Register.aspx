<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="study_tracker.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-wrap">
        <div class="card form-card">
            <div class="card-body pad-lg">
                <h3 class="text-center mb-4">📝 Create Account</h3>

                <asp:Label ID="lblMessage" runat="server" CssClass="d-none"></asp:Label>

                <div class="field">
                    <label class="field-label">Full Name</label>
                    <asp:TextBox ID="txtFullName" runat="server" CssClass="input" placeholder="e.g. John Doe"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtFullName"
                        ErrorMessage="Please enter your name." CssClass="text-danger small" Display="Dynamic" ValidationGroup="reg"></asp:RequiredFieldValidator>
                </div>

                <div class="field">
                    <label class="field-label">Email</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="input" TextMode="Email" placeholder="name@example.com"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                        ErrorMessage="Please enter your email." CssClass="text-danger small" Display="Dynamic" ValidationGroup="reg"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        ErrorMessage="Please enter a valid email address." CssClass="text-danger small d-block" Display="Dynamic" ValidationGroup="reg"></asp:RegularExpressionValidator>
                </div>

                <div class="field">
                    <label class="field-label">Password</label>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="input" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                        ErrorMessage="Please enter a password." CssClass="text-danger small" Display="Dynamic" ValidationGroup="reg"></asp:RequiredFieldValidator>
                </div>

                <div class="field">
                    <label class="field-label">Confirm Password</label>
                    <asp:TextBox ID="txtConfirm" runat="server" CssClass="input" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvConfirm" runat="server" ControlToValidate="txtConfirm"
                        ErrorMessage="Please confirm your password." CssClass="text-danger small" Display="Dynamic" ValidationGroup="reg"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvPassword" runat="server" ControlToValidate="txtConfirm" ControlToCompare="txtPassword"
                        Operator="Equal" Type="String" ErrorMessage="Passwords do not match." CssClass="text-danger small d-block" Display="Dynamic" ValidationGroup="reg"></asp:CompareValidator>
                </div>

                <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn btn-primary btn-full" OnClick="btnRegister_Click" ValidationGroup="reg" />

                <p class="text-center mt-3 mb-0">Already have an account? <a runat="server" href="~/Login.aspx">Login here</a></p>
            </div>
        </div>
    </div>

</asp:Content>
