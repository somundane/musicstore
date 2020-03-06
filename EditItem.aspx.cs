using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalProj.Models;
using FinalProj.DataAccess;

namespace FinalProj
{
    public partial class EditItem : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Item item = (Item)Session["ItemInfo"];

                txtSKU.Text = item.SKU.ToString("D6");
                /*if(txtSKU.Text.Length < 6)
                {
                    int zero = 6 - txtSKU.Text.Length;
                    string finalSKU = new String('0', zero) + txtSKU.Text;
                    txtSKU.Text = finalSKU;
                }*/

                txtAlbum.Text = item.album_title;
                txtArtist.Text = item.artist;
                txtQty.Text = item.quantity.ToString();
                txtPrice.Text = item.price.ToString("F", CultureInfo.InvariantCulture);
                byte[] cover = item.cover;


            }
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            Item item2 = new Item();
            Session["EditedItem"] = (Item)Session["EditedItem"];

            item2.SKU = int.Parse(txtSKU.Text);
            item2.album_title = txtAlbum.Text;
            item2.artist = txtArtist.Text;
            item2.price = decimal.Parse(txtPrice.Text);
            item2.quantity = int.Parse(txtQty.Text);


            //if there is a new file
            if (flUpload.HasFile )
            {
                Stream fs = flUpload.PostedFile.InputStream;
                BinaryReader br = new BinaryReader(fs);
                byte[] theImage = br.ReadBytes((Int32)fs.Length);
                item2.cover = theImage;
                
            }
            
            //if no new upload, keep old file
            else
            {
                Item item = (Item)Session["ItemInfo"];
                /*ItemTier imgTier = new ItemTier();
                byte[] theImage = imgTier.getImage(item.SKU);
                Stream same = new MemoryStream(theImage);

                BinaryReader img = new BinaryReader(same);
                byte[] sameImage = img.ReadBytes((Int32)same.Length);*/

                item2.cover = item.cover;
            }

            //Session variable for edited item
            Session["EditedItem"] = item2;
            ItemTier editTier = new ItemTier();

            editTier.updateItem(item2);

            Response.Redirect("ProductList.aspx");

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductList.aspx");
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {

            Item item = (Item)Session["ItemInfo"];
            //assign item SKU as button ID for delete

            //whichever button is clicked with id = SKU

            //take sku from session created in ProductList and use delete method from ItemTier
            ItemTier theTier = new ItemTier();
            //xxItem current = theTier.getItemByID(item.SKU);

            //xxint sku = Convert.ToInt32(Session["delSKU"]);
            theTier.deleteItem(item.SKU);
            Response.Redirect("ProductList.aspx");
        }
    }

}