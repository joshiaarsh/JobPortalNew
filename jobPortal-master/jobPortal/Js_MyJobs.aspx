<%@ Page Title="" Language="C#" MasterPageFile="~/Js_userMaster.Master" AutoEventWireup="true" CodeBehind="Js_MyJobs.aspx.cs" Inherits="jobPortal.Js_MyJobs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
      
         <div class="box box-primary">
                <div class="box-header with-border">
        
        <asp:GridView  ID="GridView1" runat="server" AllowPaging="true"
                        CssClass="table table-bordered" >
                          
        </asp:GridView>
        <asp:SqlDataSource ID="Post" runat="server"></asp:SqlDataSource>
                    </div>
             </div>
    </form>
</asp:Content>
