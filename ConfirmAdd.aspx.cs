using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalProj.DataAccess;
using FinalProj.Models;

namespace FinalProj
{
    public partial class ConfirmAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["NewItemInfo"] != null)
            {
                Item item = (Item)Session["NewItemInfo"];
                lblAlbum.Text = item.album_title;
                lblArtist.Text = "by " + item.artist;
                txtPrice.Text = item.price.ToString();
                txtQty.Text = item.quantity.ToString();
            }
            //if empty session variable, user needs to go to add item page where session var is filled
            else
            {
                Response.Redirect("AddItem.aspx");

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Item item = (Item)Session["NewItemInfo"];

            //insert item stored in session var (from prev page) and add user through function from usertier
            ItemTier theTier = new ItemTier();
            theTier.insertItem(item);

            Session["NewItemInfo"] = null;

            Response.Redirect("ProductList.aspx"); 
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddItem.aspx");
        }
    }
}