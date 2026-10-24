<%@ Page Title="Add Task" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddTask.aspx.cs" Inherits="study_tracker.AddTask" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-wrap-lg">
        <div class="card form-card">
            <div class="card-body pad-lg">
                <h3 class="mb-4">📝 <asp:Label ID="lblHeading" runat="server"></asp:Label></h3>

                <div class="field">
                    <label class="field-label">Title</label>
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="input" placeholder="What do you need to study?"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="txtTitle"
                        ErrorMessage="Title is required." CssClass="text-danger small" Display="Dynamic" ValidationGroup="task"></asp:RequiredFieldValidator>
                </div>

                <div class="form-row">
                    <div class="field">
                        <label class="field-label">Subject</label>
                        <asp:TextBox ID="txtSubject" runat="server" CssClass="input" placeholder="e.g. Database"></asp:TextBox>
                    </div>
                    <div class="field">
                        <label class="field-label">Priority</label>
                        <asp:DropDownList ID="ddlPriority" runat="server" CssClass="input">
                            <asp:ListItem>High</asp:ListItem>
                            <asp:ListItem Selected="True">Medium</asp:ListItem>
                            <asp:ListItem>Low</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="form-row">
                    <div class="field">
                        <label class="field-label">Due Date</label>
                        <asp:TextBox ID="txtDueDate" runat="server" CssClass="input" TextMode="Date"></asp:TextBox>
                    </div>
                    <div class="field">
                        <label class="field-label">Status</label>
                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="input">
                            <asp:ListItem>Pending</asp:ListItem>
                            <asp:ListItem>Completed</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="field">
                    <label class="field-label">Description</label>
                    <asp:TextBox ID="txtDescription" runat="server" CssClass="input" TextMode="MultiLine" Rows="3"
                        placeholder="Optional notes about this task"></asp:TextBox>
                </div>

                <asp:Button ID="btnSave" runat="server" Text="Save Task" CssClass="btn btn-primary" OnClick="btnSave_Click" ValidationGroup="task" />
                <a runat="server" href="~/Tasks.aspx" class="btn btn-secondary">Cancel</a>
            </div>
        </div>
    </div>

</asp:Content>
