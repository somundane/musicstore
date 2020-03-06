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
    public partial class AddItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //must have info only when user clicks cancel
            if (Session["NewItemInfo"] != null)
            {
                //If it contains info, use the info to assign to textbox
                Item item = (Item)Session["NewItemInfo"];
                txtSKU.Text = item.SKU.ToString();
                txtAlbum.Text = item.album_title;
                txtArtist.Text = item.artist;
                txtQty.Text = item.quantity.ToString();
                txtPrice.Text = item.price.ToString();
                byte[] cover = item.cover;

                //null the session variable for next time | change item data when submit is clicked
                Session["NewItemInfo"] = null;

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Item item = new Item();
            ItemTier theTier = new ItemTier();

            bool exists = theTier.itemExists(int.Parse(txtSKU.Text));
            if (exists == true)
            {
                Response.Write("<script>alert('This SKU already exists')</script>");
                //Response.Redirect("ProductList.aspx");
            }
            else
            {

                item.SKU = int.Parse(txtSKU.Text);
                item.album_title = txtAlbum.Text;
                item.artist = txtArtist.Text;
                item.price = decimal.Parse(txtPrice.Text);
                item.quantity = int.Parse(txtQty.Text);


                Stream fs = flUpload.PostedFile.InputStream;
                BinaryReader br = new BinaryReader(fs);

                byte[] theImage = br.ReadBytes((Int32)fs.Length);

                item.cover = theImage;

                Session["NewItemInfo"] = item;

                Response.Redirect("ConfirmAdd.aspx");

            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductList.aspx");
        }


    }
}