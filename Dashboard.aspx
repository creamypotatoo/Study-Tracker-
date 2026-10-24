<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="study_tracker.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2 class="mb-2"><asp:Label ID="lblWelcome" runat="server"></asp:Label></h2>
    <p class="text-muted">Here is a quick look at your study progress.</p>

    <!-- ===== Stat cards ===== -->
    <div class="stat-grid mb-4">
        <div class="card stat-card stat-total">
            <div class="card-body text-center">
                <div class="stat-ico"></div>
                <h3><asp:Label ID="lblTotal" runat="server" Text="0"></asp:Label></h3>
                <span>Total Tasks</span>
            </div>
        </div>
        <div class="card stat-card stat-completed">
            <div class="card-body text-center">
                <div class="stat-ico"></div>
                <h3><asp:Label ID="lblCompleted" runat="server" Text="0"></asp:Label></h3>
                <span>Completed</span>
            </div>
        </div>
        <div class="card stat-card stat-pending">
            <div class="card-body text-center">
                <div class="stat-ico"></div>
                <h3><asp:Label ID="lblPending" runat="server" Text="0"></asp:Label></h3>
                <span>Pending</span>
            </div>
        </div>
        <div class="card stat-card stat-productivity">
            <div class="card-body text-center">
                <div class="stat-ico"></div>
                <h3><asp:Label ID="lblProductivity" runat="server" Text="0%"></asp:Label></h3>
                <span>Productivity</span>
            </div>
        </div>
    </div>

    <!-- ===== Productivity progress bar ===== -->
    <div class="card mb-4">
        <div class="card-body">
            <h6 class="mb-2">Overall Productivity</h6>
            <div class="progress" style="height: 22px;">
                <div runat="server" id="pbProductivity" class="progress-bar" style="width: 0%;">0%</div>
            </div>
        </div>
    </div>

    <!-- ===== Upcoming tasks (Repeater) ===== -->
    <div class="page-header">
        <h4 class="mb-0">Upcoming Tasks</h4>
        <a runat="server" href="~/AddTask.aspx" class="btn btn-success btn-sm">Add Task</a>
    </div>

    <asp:Repeater ID="rptUpcoming" runat="server">
        <HeaderTemplate>
            <div class="task-list">
        </HeaderTemplate>
        <ItemTemplate>
            <div class="task-item">
                <div>
                    <strong><%# Eval("Title") %></strong>
                    <span class="badge badge-secondary"><%# Eval("Subject") %></span>
                    <br />
                    <small class="text-muted">Due: <%# Eval("DueDate", "{0:dd MMM yyyy}") %></small>
                </div>
                <span class="badge badge-warning"><%# Eval("Priority") %></span>
            </div>
        </ItemTemplate>
        <FooterTemplate>
            </div>
        </FooterTemplate>
    </asp:Repeater>

    <asp:Panel ID="pnlNoTasks" runat="server" Visible="false" CssClass="alert alert-info">
        You have no pending tasks right now. Great job! &#127881;
    </asp:Panel>

</asp:Content>
