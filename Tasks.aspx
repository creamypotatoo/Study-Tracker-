<%@ Page Title="My Tasks" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tasks.aspx.cs" Inherits="study_tracker.Tasks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="page-header">
        <h2 class="mb-0">📋 My Tasks</h2>
        <a runat="server" href="~/AddTask.aspx" class="btn btn-success">➕ Add Task</a>
    </div>

    <div class="mb-3">
        <label>Show:</label>
        <asp:DropDownList ID="ddlFilter" runat="server" CssClass="input inline-select"
            AutoPostBack="true" OnSelectedIndexChanged="ddlFilter_SelectedIndexChanged">
            <asp:ListItem Value="All">All Tasks</asp:ListItem>
            <asp:ListItem Value="Pending">Pending Only</asp:ListItem>
            <asp:ListItem Value="Completed">Completed Only</asp:ListItem>
        </asp:DropDownList>
    </div>

    <asp:GridView ID="gvTasks" runat="server" AutoGenerateColumns="false" DataKeyNames="TaskId"
        CssClass="table"
        AllowPaging="true" PageSize="8" GridLines="None"
        OnRowCommand="gvTasks_RowCommand" OnPageIndexChanging="gvTasks_PageIndexChanging">
        <HeaderStyle CssClass="table-light" />
        <Columns>
            <asp:BoundField DataField="Title" HeaderText="Title" />
            <asp:BoundField DataField="Subject" HeaderText="Subject" />
            <asp:BoundField DataField="Priority" HeaderText="Priority" />
            <asp:BoundField DataField="DueDate" HeaderText="Due Date" DataFormatString="{0:dd MMM yyyy}" />
            <asp:BoundField DataField="Status" HeaderText="Status" />
            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:LinkButton runat="server" CommandName="MarkComplete" CommandArgument='<%# Eval("TaskId") %>'
                        CssClass="btn btn-sm btn-outline-success" ToolTip="Mark as completed"
                        Visible='<%# (string)Eval("Status") == "Pending" %>'>✔️</asp:LinkButton>
                    <a href='<%# "AddTask.aspx?id=" + Eval("TaskId") %>' class="btn btn-sm btn-outline-primary" title="Edit">✏️</a>
                    <asp:LinkButton runat="server" CommandName="DeleteTask" CommandArgument='<%# Eval("TaskId") %>'
                        CssClass="btn btn-sm btn-outline-danger" ToolTip="Delete"
                        OnClientClick="return confirm('Are you sure you want to delete this task?');">🗑️</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <PagerStyle CssClass="mt-2" />
        <EmptyDataTemplate>
            <div class="empty-msg">
                <div style="font-size: 2rem;">📥</div>
                <p class="mb-0 mt-2">No tasks found. Click "Add Task" to create one.</p>
            </div>
        </EmptyDataTemplate>
    </asp:GridView>

</asp:Content>
