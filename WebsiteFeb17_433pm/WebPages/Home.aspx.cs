using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using database;
using System.Data.SqlClient;
using System.Collections;

public partial class HomeCode : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        //PlaceHolder[] plcArray = new PlaceHolder[125];
        Image[] imgArray = new Image[100];
        TextBox[] txtArray = new TextBox[100];
        Button[] btnArray = new Button[100];
        Label[] lblArray = new Label[100];
        

        //for (int i = 0; i < plcArray.Length; i++)
        //{
        //    plcArray[i] = new PlaceHolder();
        //    plcArray[]
        //}
        for (int i = 0; i <  imgArray.Length; i++)
        {
            imgArray[i] = new Image();
            imgArray[i].Attributes.Add("runat", "server");
            imgArray[i].Height = 50;
            imgArray[i].Width = 50;
            imgArray[i].BorderStyle = BorderStyle.Solid;
        }
        for (int i = 0; i < txtArray.Length; i++)
        {
            txtArray[i] = new TextBox();
            txtArray[i].Attributes.Add("runat", "server");
            txtArray[i].ReadOnly = true;
            txtArray[i].Rows = 3;
            txtArray[i].Width = 200;
        }
        for (int i = 0; i < btnArray.Length; i++)
        {
            btnArray[i] = new Button();
            btnArray[i].Attributes.Add("runat", "server");
            btnArray[i].Text = "Like :)";
            
        }
        for (int i = 0; i < lblArray.Length; i++)
        {
            lblArray[i] = new Label();
            lblArray[i].Attributes.Add("runat", "server");
            lblArray[i].Text = " Likes!";
        }
        
        //for (int i = 0, a = 0; i < plcArray.Length; i++, a++)
        //{
            
        //    plcArray[i].Controls.Add(imgArray[a]);
        //    this.Controls.Add(imgArray[a]);
        //    plcArray[++i].Controls.Add(txtArray[a]);
        //    this.Controls.Add(txtArray[a]);
        //    plcArray[++i].Controls.Add(new LiteralControl("< br/>"));
        //    this.Controls.Add(new LiteralControl)
        //    plcArray[++i].Controls.Add(btnArray[a]);
        //    plcArray[++i].Controls.Add(lblArray[a]);
        //}

        for (int a = 0; a < 100; a++)
        {
            this.Controls.Add(imgArray[a]);
            this.Controls.Add(txtArray[a]);
            this.Controls.Add(new LiteralControl("< br/>"));
            this.Controls.Add(btnArray[a]);
            this.Controls.Add(lblArray[a]);
            
            
        }




        //    Image imgOne = new Image();
        //imgOne.Height = 50;
        //imgOne.Width = 50;
        //imgOne.BorderStyle = BorderStyle.Dashed;
        //TextBox txtOne = new TextBox();
        //txtOne.ReadOnly = true;
        //Button btnOne = new Button();
        //btnOne.Click += likeClick;
        //btnOne.Text = "Like";
        //Label lblOne = new Label();
        
        //lblOne.Text = " Likes!";

        //PlaceHolder1.Controls.Add(imgOne);
        //PlaceHolder2.Controls.Add(txtOne);
        //PlaceHolder3.Controls.Add(btnOne);
        //PlaceHolder4.Controls.Add(lblOne);


    }

    //protected void btnTest_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        SqlConnection conn = ProjectDB.connectToDB();
    //        if(conn == null)
    //        {
    //            testError.Text += "\nFailed";
    //        }
    //        else
    //        {
    //            conn.Close();
    //        }
            
    //        testError.Text += "\nSuccess";
            
    //    }
    //    catch(Exception ex)
    //    {
    //        testError.Text += "\n" + ex;
    //    }
    //}

    protected void likeClick(object sender, EventArgs e)
    {
        

        

    }
}