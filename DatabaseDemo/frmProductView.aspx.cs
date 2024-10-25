using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

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
        private void UpdateProduct(int productId, string name, int qty, double rate, int categoryId, bool isActive)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            //sqlConnection.ConnectionString = connectionString;
            SqlCommand sqlCommand = new SqlCommand("spSetProduct", sqlConnection);
            sqlCommand.Parameters.Add("@flag", SqlDbType.Int).Value = 1;
            sqlCommand.Parameters.Add("@ProductId", SqlDbType.Int).Value = productId;
            sqlCommand.Parameters.Add("@Name", SqlDbType.VarChar,50).Value = name;
            sqlCommand.Parameters.Add("@Qty", SqlDbType.Int).Value = qty;
            sqlCommand.Parameters.Add("@Rate", SqlDbType.Float).Value = rate;
            sqlCommand.Parameters.Add("@CategoryId", SqlDbType.Int).Value = categoryId;
            sqlCommand.Parameters.Add("@IsActive", SqlDbType.Bit).Value = isActive;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Dispose();
            sqlConnection.Close();
            sqlCommand.Dispose();
        }
        protected void fvProduct_ItemUpdating(object sender, FormViewUpdateEventArgs e)
        {
            if (Page.IsValid)
            {
                int productId = Convert.ToInt32(fvProduct.DataKey.Value);
                string name = Convert.ToString(e.NewValues["Name"]);
                int qty = Convert.ToInt32(e.NewValues["Qty"]);
                Double rate = Convert.ToDouble(e.NewValues["Rate"]);
                DropDownList ddlCategory = (DropDownList)fvProduct.FindControl("ddlCategory");
                int categoryId = Convert.ToInt32(ddlCategory.SelectedValue);
                CheckBox chkIsActive = (CheckBox)fvProduct.FindControl("chkIsActive");
                UpdateProduct(productId, name, qty, rate, categoryId, true);
                fvProduct.ChangeMode(FormViewMode.ReadOnly);
                BindFormView(productId);
            }
        }
        private void DeleteProduct (int productId)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            //sqlConnection.ConnectionString = connectionString;
            SqlCommand sqlCommand = new SqlCommand("spSetProduct", sqlConnection);
            sqlCommand.Parameters.Add("@flag", SqlDbType.Int).Value = 3;
            sqlCommand.Parameters.Add("@ProductId", SqlDbType.Int).Value = productId;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Dispose();
            sqlConnection.Close();
            sqlCommand.Dispose();
        }
        protected void fvProduct_ItemDeleting(object sender, FormViewDeleteEventArgs e)
        {
            int productId = Convert.ToInt32(fvProduct.DataKey.Value);
            DeleteProduct(productId);
            fvProduct.ChangeMode(FormViewMode.ReadOnly);
            Response.Redirect("frmProduct.aspx");
        }
    }
}