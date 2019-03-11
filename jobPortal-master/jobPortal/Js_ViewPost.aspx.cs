using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace jobPortal
{
    public partial class Js_ViewPost : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["JobPortalConnectionString"].ConnectionString);
        //SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=JobPortal;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["JsUser"] == null)
            {
                Response.Redirect("Js_Login.aspx");
            }
            else
            {
                lblId.Text = Request.QueryString["id"];
                lblId.Visible = false;
                if (!IsPostBack)
                {
                    string str = "select * from JobPost where PostId=" + Convert.ToInt16(lblId.Text);
                    SqlDataAdapter da = new SqlDataAdapter(str, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        lblPostId.Text = dt.Rows[0]["PostId"].ToString();
                        lblHeader.Text = dt.Rows[0]["PostHead"].ToString();
                        lblDesc.Text = dt.Rows[0]["Descr"].ToString();
                        lblLoc.Text = dt.Rows[0]["Loc"].ToString();
                        lblSal.Text = dt.Rows[0]["Salary"].ToString();
                        lblType.Text = dt.Rows[0]["JobType"].ToString();
                        lblField.Text = dt.Rows[0]["JobField"].ToString();
                    }
                }
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Js_Post.aspx");
            btnApply.Visible = true;
        }

        protected void btnApply_Click(object sender, EventArgs e)
        {
            //Response.Redirect("Js_Apply.aspx?id=" + Convert.ToInt16(lblId.Text));
            //  Response.Redirect("Js_Apply.aspx?id=" + Convert.ToInt16(Label1.Text));
            con.Open();
            string PostId = lblPostId.Text.Trim().ToString();
            string id = Session["JsUser"].ToString();
            //string Status1 = "1";
            DataTable datatableUserMaster = new DataTable();
            string s = "insert into Applicant (PostId,JsId) VALUES (" + PostId + "," + id + ")";
            SqlCommand cmd = new SqlCommand(s, con);
            //    SqlCommand cmd = new SqlCommand("insert into appjb values('" + id + "','" + PostId + "','" + Status1 + "')", con);
            cmd.ExecuteNonQuery();
            //Label2.Text = "you have applied suceessfully";
            con.Close();
            //  btnApply.Visible = false;
            btnApply.Text = "Applied";
            btnApply.Enabled = false;



            // Response.Redirect("Js_MyJobs.aspx");// Response.Redirect("Js_Apply.aspx?id=" + Convert.ToInt16(lblId.Text));
        }
    }
}