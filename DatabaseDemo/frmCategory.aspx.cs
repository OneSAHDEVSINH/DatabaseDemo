using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Collections;

namespace DatabaseDemo
{
    public partial class frmCategory : System.Web.UI.Page
    {
        SqlConnection connection = new SqlConnection();
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\USERS\\INSPI\\DOWNLOADS\\DATABASEDEMO\\DATABASEDEMO\\DATABASEDEMO\\APP_DATA\\MYCOMPANY.MDF";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        private void BindGridView()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            // string query = "select * from Category where IsActive = @IsActive";
            string query = "select * from Category";
            SqlCommand sqlCommand = new SqlCommand(query,connection);
            //sqlCommand.Connection = connection;
            //sqlCommand.Parameters.Add("@IsActive", SqlDbType.Bit).Value = 1;
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            //adapter.SelectCommand=connection;
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            gvCategory.DataSource = ds.Tables[0];
            gvCategory.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            String id = Session["Cid"].ToString();
            String CName =txtCategoryName.Text;
            bool isActive=chkIsActive.Checked;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            String Query;
            if (id == "0")
            {
                 Query = "insert into Category values(@name,@isActive)";
            }
            else {
                 Query = "update Category set Name=@name,IsActive=@isActive where CategoryId=@cid";
                sqlCommand.Parameters.Add("@cid", SqlDbType.Int).Value = Session["Cid"].ToString();
            }
            
            sqlCommand.CommandText = Query;
            sqlCommand.Parameters.Add("@name", SqlDbType.VarChar, 20).Value = CName;
            sqlCommand.Parameters.Add("@isActive", SqlDbType.Bit).Value = isActive;
            connection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Dispose();
            connection.Close();
            connection.Dispose();
            BindGridView();
            pnlCategory.Visible = false;
            Session["Cid"] = 0;
            clear();                                                                                        




        }

        protected void btnReset_Click(object sender, EventArgs e)
        {

        }

        protected void lnlbtnNewCategory_Click(object sender, EventArgs e)
        {
            pnlCategory.Visible = true;
            Session["Cid"] = 0;
            clear();
        }
        private void clear() { 
           txtCategoryName.Text= string.Empty;
            chkIsActive.Checked = true; 
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            pnlCategory.Visible= false;
            clear();
            Session["Cid"] = 0;


        }

     

    
     

        protected void gvCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCategory.PageIndex = e.NewPageIndex; 
            BindGridView();

        }

        protected void gvCategory_SelectedIndexChanged1(object sender, EventArgs e)
        {
            int cid = Convert.ToInt32(gvCategory.SelectedDataKey.Value);
            String CName = gvCategory.SelectedRow.Cells[0].Text;
            Boolean isActive = Convert.ToBoolean(gvCategory.SelectedRow.Cells[1].Text);

            Session["Cid"] = cid;
            txtCategoryName.Text = CName;
            chkIsActive.Checked = isActive;
            pnlCategory.Visible = true;

        }
    }
}