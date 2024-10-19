using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace DatabaseDemo
{
    public partial class frmProduct : System.Web.UI.Page
    {
        string connectionstring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\USERS\\INSPI\\DOWNLOADS\\DATABASEDEMO\\DATABASEDEMO\\DATABASEDEMO\\APP_DATA\\MYCOMPANY.MDF";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindCategory();
                BindDataList(1);
            }
        }
        private void BindCategory()
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString= connectionstring;
            SqlCommand sqlCommand = new SqlCommand("spGetCategory", sqlConnection);
            sqlCommand.Parameters.Add("@flag",SqlDbType.Int).Value = 1;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            ddlcategory.DataSource = ds.Tables[0];
            ddlcategory.DataTextField = "Name";
            ddlcategory.DataValueField = "CategoryId";
            ddlcategory.DataBind();
            ddlcategory.Items.Insert(0, new ListItem() { Value = "0", Text = "All" });

        }
        private void BindDataList(int flag,int categoryId=0)
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = connectionstring;
            SqlCommand sqlCommand = new SqlCommand("spGetProduct", sqlConnection);
            sqlCommand.Parameters.Add("@flag", SqlDbType.Int).Value = flag;
            sqlCommand.Parameters.Add("@CategoryId", SqlDbType.Int).Value = categoryId;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dlProduct.DataSource = ds.Tables[0];
            dlProduct.DataBind();
        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            int categoryId = Convert.ToInt32(ddlcategory.SelectedValue);
            if (categoryId == 0)
            {
                BindDataList(1);
            }
            else
            {
                BindDataList(2, categoryId);
            }

        }
    }
}