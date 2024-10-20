using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DatabaseDemo
{
    public partial class frmProductView : System.Web.UI.Page
    {
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\C#\\DatabaseDemo\\DatabaseDemo\\App_Data\\Mycompany.mdf;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["ProductId"] != null)
                {
                    int productId = Convert.ToInt32(Session["ProductId"]);
                    BindFormView(productId);
                }
                else
                {
                    Response.Redirect("frmProduct.aspx");
                }
            }
        }
        private void BindFormView(int productId)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            //sqlConnection.ConnectionString = connectionString;
            SqlCommand sqlCommand = new SqlCommand("spGetProduct", sqlConnection);
            sqlCommand.Parameters.Add("@flag", SqlDbType.Int).Value = 3;
            sqlCommand.Parameters.Add("@ProductId", SqlDbType.Int).Value = productId;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            fvProduct.DataSource = ds.Tables[0];
            fvProduct.DataBind();
            Session["CategoryId"] = Convert.ToInt32(ds.Tables[0].Rows[0]["CategoryId"]);
        }
        private void BindCategory(DropDownList ddlCategory, int categoryId)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            //sqlConnection.ConnectionString= connectionstring;
            SqlCommand sqlCommand = new SqlCommand("spGetCategory", sqlConnection);
            sqlCommand.Parameters.Add("@flag", SqlDbType.Int).Value = 1;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            ddlCategory.DataSource = ds.Tables[0];
            ddlCategory.DataTextField = "Name";
            ddlCategory.DataValueField = "CategoryId";
            ddlCategory.DataBind();
            ddlCategory.SelectedValue = categoryId.ToString();


        }
        protected void fvProduct_ModeChanging(object sender, FormViewModeEventArgs e)
        {
            fvProduct.ChangeMode(e.NewMode);
            int productId = Convert.ToInt32(fvProduct.SelectedValue);
            BindFormView(productId);
            if(e.NewMode == FormViewMode.Edit)
            {
                DropDownList ddlCategory = (DropDownList)fvProduct.FindControl("ddlCategory");
                int categoryId = Convert.ToInt32(Session["CategoryId"]);
                //BindCategory((DropDownList)fvProduct.FindControl("ddlCategory"), Convert.ToInt32(Session["CategoryId"]));
                BindCategory(ddlCategory, categoryId);
            }
        }

        protected void fvProduct_ItemUpdating(object sender, FormViewUpdateEventArgs e)
        {

        }

        protected void fvProduct_ItemDeleting(object sender, FormViewDeleteEventArgs e)
        {

        }
    }
}