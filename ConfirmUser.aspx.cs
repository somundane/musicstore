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
    public partial class ConfirmUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if session contains info, assign those info
            if (Session["NewUserInfo"] != null)
            {
                Users user = (Users)Session["NewUserInfo"];
                
                lblName.Text = user.first_name + " " + user.last_name;
                lblUn.Text = "username: " + user.username;
            }
            //if empty session variable, user needs to go to userreg page to fill it out
            //there, we assign their input to the session | ensures info is present for submit to work
            else
            {
                Response.Redirect("UserReg.aspx");

            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //if they hit cancel redirect them to previous page where page_load function handles keeping info on textboxes
            Response.Redirect("UserReg.aspx");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //take content in session (assigned from UseReg page) 
            Users user = (Users)Session["NewUserInfo"];
            Session["UserID"] = null;

            //add user to database thru function in usertier
            UserTier theTier = new UserTier();
            theTier.insertUser(user);
            //take username info to assign to session variable later
            Users me = new Users();

            me.user_id = Int32.Parse(theTier.getIdByUser(user.username));
            Session["UserID"] = me;

            Session["NewUserInfo"] = null;

            Response.Redirect("UserDefault.aspx");
        }
    }
}