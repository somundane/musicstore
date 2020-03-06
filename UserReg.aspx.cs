using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalProj.DataAccess;
using FinalProj.Models;

namespace FinalProj
{
    public partial class UserReg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //placeholder
            Session["UserID"] = (Users)Session["UserID"];
            Users me = new Users();
            me.user_id = 1;
            Session["UserID"] = me;

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogIn.aspx");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Users user = new Users();
            UserTier theTier = new UserTier();

            //see if username already exists to avoid duplicate usernames
            bool exists = theTier.userExists(txtUn.Text);
            if (exists == true)
            {
                Response.Write("<script>alert('This username already exists')</script>");
            }
            //if username is unique, see if password entries match each other for safety
            else
            {
                //if passwords match
                //create item with user input and assign it to session variable to make accessible by confirmation page
                if (txtPass.Text == txtPass2.Text)
                {
                    user.first_name = txtFn.Text;
                    user.last_name = txtLn.Text;
                    user.username = txtUn.Text;
                    user.password = txtPass.Text;
                    //default user type to user
                    user.type = "user";

                    Session["NewUserInfo"] = user;

                    Response.Redirect("ConfirmUser.aspx");

                }
                else
                {
                    Response.Write("<script>alert('Passwords must match')</script>");
                }



            }
        }
    }
}