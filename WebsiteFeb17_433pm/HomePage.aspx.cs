using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HomePage : System.Web.UI.Page
{
    
    
    protected void Page_Load(object sender, EventArgs e)
    {
        
        Image[] imgArray = new Image[100];
        TextBox[] txtArray = new TextBox[100];
        Button[] btnArray = new Button[100];
        Label[] lblArray = new Label[100];

        int displayNum = 100;

        

        for (int i = 0; i < displayNum; i++)
        {
            imgArray[i] = new Image();
            imgArray[i].Height = 50;
            imgArray[i].Width = 50;
            imgArray[i].BorderStyle = BorderStyle.Solid;

            txtArray[i] = new TextBox();
            txtArray[i].Height = 100;
            txtArray[i].Width = 200;
            txtArray[i].TextMode = TextBoxMode.MultiLine;

            btnArray[i] = new Button();
            btnArray[i].Text = "Like :)";

            lblArray[i] = new Label();
            lblArray[i].Text = " Likes!";
        }

        

        for (int a = 0; a < 100; a++)
        {
            form1.Controls.Add(imgArray[a]);
            form1.Controls.Add(txtArray[a]);
            form1.Controls.Add(new LiteralControl("<br />"));
            form1.Controls.Add(btnArray[a]);
            form1.Controls.Add(lblArray[a]);
            form1.Controls.Add(new LiteralControl("<br />"));
            form1.Controls.Add(new LiteralControl("<br />"));
            
        }
    }

    protected void likeClick(object sender, EventArgs e, Control cntrl)
    {

    }
}