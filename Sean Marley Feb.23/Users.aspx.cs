using database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class WebPages_Users : System.Web.UI.Page
{
    public string LastUpdatedBy = "Sean Marley";
    public static string year = DateTime.Now.ToString("yyyy");
    public static string month = DateTime.Now.Month.ToString("d2");
    public static string day = DateTime.Now.ToString("dd");
    public static string LastUpdate = year + "-" + month + "-" + day;
    public NewUser currentUser;
    SqlConnection conn = ProjectDB.connectToDB();

    //string cs = ConfigurationManager.ConnectionStrings["TestThis"].ConnectionString;
    SqlConnection con;
    SqlDataAdapter adapt;
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ShowData();
        }
    }

    protected void Submit_Click(object sender, EventArgs e)
    {



        //------------------------------------INSERT INTO EMPLOYEELOGIN------------------------------------------------------------------------------------
        try
        {
            SqlConnection conn = ProjectDB.connectToDB();
            try
            {


                System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
                insert.Connection = conn;

                //-----------------------------GETS MAX EMPLOYEELOGINID--------------------------------------------------------------------------------------
                System.Data.SqlClient.SqlCommand select = new System.Data.SqlClient.SqlCommand();
                select.Connection = conn;
                select.CommandText = "(select max(([EmpLoginID]) +1) from[dbo].[EmployeeLogin])";
                var temp = select.ExecuteScalar();
                string maxID = temp.ToString();
                currentUser = new NewUser(FirstNameText.Text, LastNameText.Text, MiddleText.Text, EmailText.Text, maxID, LastUpdatedBy, LastUpdate);
                //-----------------------------GETS MAX EMPLOYEELOGINID--------------------------------------------------------------------------------------

                string username = (currentUser.getLastName() + currentUser.getFirstName().Substring(0, 1) + currentUser.getMiddleName()).ToLower();
                string password = "testPassword57";



                insert.CommandText = "INSERT INTO [dbo].[EmployeeLogin] ([UserName],[PasswordHash],[LastLogin],[LastUpdatedBy],[LastUpdated]) VALUES (@userName, @password, @lastLogin, @lastUpdatedBy, @lastUpdate)";

                insert.Parameters.AddWithValue("@userName", username);
                insert.Parameters.AddWithValue("@password", SimpleHash.ComputeHash(password, "MD5", null));
                insert.Parameters.AddWithValue("@lastLogin", DateTime.Now.ToString());
                insert.Parameters.AddWithValue("@lastUpdatedBy", LastUpdatedBy);
                insert.Parameters.AddWithValue("@lastUpdate", LastUpdate);

                insert.ExecuteNonQuery();
                conn.Close();


            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('error inserting into DB for employeelogin Boiiiii')", true);
            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('error connecting to DB')", true);
        }
        //--------------------------------------------END OF INSERT INTO EMPLOYEELOGIN-------------------------------------------------------


        //--------------------------------------------INSERTING INTO EMPLOYEE TABLE----------------------------------------------------------



        try
        {
            SqlConnection conn = ProjectDB.connectToDB();
            try
            {

                string points = "0";
                System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
                insert.Connection = conn;

                //------------------------------------------------------INSERTS WITH PARAMETERIZED QUERIES----------------------------------------------------
                insert.CommandText = "INSERT INTO[dbo].[Employee]([FirstName],[LastName],[Email],[LastUpdatedBy],[LastUpdated],[EmpLoginID],[Points]) VALUES(@firstName, @lastName, @email, @lastUpdatedBy, @lastUpdated, @empLoginID, @points)";



                insert.Parameters.AddWithValue("@firstName", currentUser.getFirstName());
                insert.Parameters.AddWithValue("@lastName", currentUser.getLastName());
                insert.Parameters.AddWithValue("@email", currentUser.getEmail());
                insert.Parameters.AddWithValue("@lastUpdatedBy", currentUser.getLastUpdatedBy());
                insert.Parameters.AddWithValue("@lastUpdated", currentUser.getLastUpdate());
                insert.Parameters.AddWithValue("@empLoginID", currentUser.getEmployeeLoginID());
                insert.Parameters.AddWithValue("@points", points);

                insert.ExecuteNonQuery();
                conn.Close();
                SuccessLabel.Text = "*User Successfully Created";
            }
            //------------------------------------------------------INSERTS WITH PARAMETERIZED QUERIES----------------------------------------------------
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('error inserting into DB for employee')", true);
            }

        }
        catch (Exception)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('error connecting to DB')", true);
        }
    }

    protected void EditButton_Click(object sender, EventArgs e)
    {

        GridView1.Visible = true;

        
    }
    //------------------------------------------------------------------------
    //------------------------------------------------------------------------
    //------------------------------------------------------------------------

    //ShowData method for Displaying Data in Gridview  
    protected void ShowData()
    {
        dt = new DataTable();
        con = conn;
        //con.Open();
        adapt = new SqlDataAdapter("SELECT EmployeeID, FirstName, LastName, Email FROM Employee", con);
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        con.Close();
    }

    protected void GridView1_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        //NewEditIndex property used to determine the index of the row being edited.  
        GridView1.EditIndex = e.NewEditIndex;
        ShowData();
    }
    protected void GridView1_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
    {
        //Finding the controls from Gridview for the row which is going to update  
        Label id = GridView1.Rows[e.RowIndex].FindControl("lbl_ID") as Label;
        TextBox fName = GridView1.Rows[e.RowIndex].FindControl("txt_fName") as TextBox;
        TextBox lName = GridView1.Rows[e.RowIndex].FindControl("txt_lName") as TextBox;
        TextBox email = GridView1.Rows[e.RowIndex].FindControl("txt_email") as TextBox;
        con = conn;
        //con.Open();
        //updating the record  
        SqlCommand cmd = new SqlCommand("Update [dbo].[Employee] set [FirstName]= @firstName ,[LastName]= @lastName ,[Email]= @email where EmployeeID=" + Convert.ToInt32(id.Text), con);

        cmd.Parameters.AddWithValue("@firstName", fName.Text);
        cmd.Parameters.AddWithValue("@lastName", lName.Text);
        cmd.Parameters.AddWithValue("@email", email.Text);


        cmd.ExecuteNonQuery();
        con.Close();
        //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
        GridView1.EditIndex = -1;
        //Call ShowData method for displaying updated data  
        ShowData();
    }
    protected void GridView1_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
    {
        //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
        GridView1.EditIndex = -1;
        ShowData();
    }
}