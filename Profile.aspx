<%@ Page Title="My Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="study_tracker.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-wrap">
        <div class="card form-card">
            <div class="card-body pad-lg">
                <h3 class="mb-4">👤 My Profile</h3>

                <asp:Label ID="lblMessage" runat="server" CssClass="d-none"></asp:Label>

                <div class="field">
                    <label class="field-label">Full Name</label>
                    <asp:TextBox ID="txtFullName" runat="server" CssClass="input"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtFullName"
                        ErrorMessage="Name cannot be empty." CssClass="text-danger small" Display="Dynamic" ValidationGroup="profile"></asp:RequiredFieldValidator>
                </div>

                <div class="field">
                    <label class="field-label">Email (cannot be changed)</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="input" ReadOnly="true"></asp:TextBox>
                </div>

                <div class="field">
                    <label class="field-label">Member Since</label>
                    <p class="plaintext"><asp:Label ID="lblMemberSince" runat="server"></asp:Label></p>
                </div>

                <hr />
                <p class="text-muted small">Leave the password fields blank if you do not want to change your password.</p>

                <div class="field">
                    <label class="field-label">New Password</label>
                    <asp:TextBox ID="txtNewPassword" runat="server" CssClass="input" TextMode="Password"></asp:TextBox>
                </div>

                <div class="field">
                    <label class="field-label">Confirm New Password</label>
                    <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="input" TextMode="Password"></asp:TextBox>
                    <asp:CompareValidator ID="cvPassword" runat="server" ControlToValidate="txtConfirmPassword" ControlToCompare="txtNewPassword"
                        Operator="Equal" Type="String" ErrorMessage="Passwords do not match." CssClass="text-danger small d-block" Display="Dynamic" ValidationGroup="profile"></asp:CompareValidator>
                </div>

                <asp:Button ID="btnUpdate" runat="server" Text="Update Profile" CssClass="btn btn-primary" OnClick="btnUpdate_Click" ValidationGroup="profile" />
            </div>
        </div>
    </div>

</asp:Content>
