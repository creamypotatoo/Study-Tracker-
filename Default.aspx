<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="study_tracker._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="hero-section">
        <h1>🎓 Study Planner &amp; Productivity Tracker</h1>
        <p class="hero-lead">
            Plan your study tasks, track what you finish, and watch your productivity grow.
            A simple tool to keep your whole semester organised.
        </p>
        <div class="hero-actions">
            <a runat="server" href="~/Register.aspx" class="btn btn-light btn-lg">📝 Get Started</a>
            <a runat="server" href="~/Login.aspx" class="btn btn-outline-light btn-lg">🔑 Login</a>
        </div>
    </div>

    <div class="feature-grid">
        <div class="card feature-card">
            <div class="card-body">
                <div class="feature-icon">📋</div>
                <h3 class="mt-3">Manage Tasks</h3>
                <p class="text-muted">Add, edit and organise your study tasks by subject, priority and due date.</p>
            </div>
        </div>
        <div class="card feature-card">
            <div class="card-body">
                <div class="feature-icon">📈</div>
                <h3 class="mt-3">Track Progress</h3>
                <p class="text-muted">See your total, completed and pending tasks at a glance on your dashboard.</p>
            </div>
        </div>
        <div class="card feature-card">
            <div class="card-body">
                <div class="feature-icon">🏆</div>
                <h3 class="mt-3">Stay Productive</h3>
                <p class="text-muted">A live productivity percentage keeps you motivated to finish your work.</p>
            </div>
        </div>
    </div>

</asp:Content>
