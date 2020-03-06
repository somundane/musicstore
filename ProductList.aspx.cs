using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalProj.DataAccess;
using FinalProj.Models;

namespace FinalProj
{
    public partial class ProductList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ItemTier theTier = new ItemTier();
            List<Item> products = theTier.getAllItems();
            Table theTable = null;

            if (products == null)
            {
                lblOrd.Text = "No items to display.";
            }
            else
            {
                lblOrd.Text = " ";
                foreach (Item item in products)
                {
                    theTable = getItemTable(item);
                    pnlOut.Controls.Add(theTable);

                }
            }
        }

        protected Table getItemTable(Item item)
        {


            Table productTable = new Table();
            TableRow tr = new TableRow();
            TableCell td = new TableCell();
            //Button cart = new Button();
            Label theLabel = null;

            tr = new TableRow();
            td = new TableCell();
            theLabel = new Label();
            theLabel.Text = "Album Name: " + item.album_title;
            theLabel.Font.Bold = true;
            td.Controls.Add(theLabel);
            tr.Cells.Add(td);
            productTable.Rows.Add(tr);


            tr = new TableRow();
            td = new TableCell();
            string url = "ImageHandler.ashx?ID=" + item.SKU.ToString();
            Image productImage = new Image();

            productImage.ImageUrl = url;
            productImage.Attributes.Add("width", "200px");
            td.Controls.Add(productImage);
            tr.Cells.Add(td);
            productTable.Rows.Add(tr);

            tr = new TableRow();
            td = new TableCell();
            theLabel = new Label();
            theLabel.Text = "Artist: " + item.artist;
            td.Controls.Add(theLabel);
            tr.Cells.Add(td);
            productTable.Rows.Add(tr);

            tr = new TableRow();
            td = new TableCell();
            theLabel = new Label();
            theLabel.Text = "Price: " + item.price.ToString("C", CultureInfo.CurrentCulture);
            td.Controls.Add(theLabel);
            tr.Cells.Add(td);
            productTable.Rows.Add(tr);

            tr = new TableRow();
            td = new TableCell();
            theLabel = new Label();
            theLabel.Text = "Qty in stock: " + item.quantity;
            td.Controls.Add(theLabel);
            tr.Cells.Add(td);
            productTable.Rows.Add(tr);

            /*tr = new TableRow();
            td = new TableCell();
            cart = new Button();
            cart.Text = "Add To Cart";
            cart.CssClass = "btn btn-success";
            cart.ID = item.SKU.ToString();
            cart.Click += cartClick;
            td.Controls.Add(cart);
            tr.Cells.Add(td);
            productTable.Rows.Add(tr);*/

            //ContentPlaceHolder contentPH = (ContentPlaceHolder)this.Master.FindControl("ButtonPlace");
            //Button edit = (Button)contentPH.FindControl(item.SKU.ToString());
            Button edit = new Button();

            tr = new TableRow();
            td = new TableCell();
            edit = new Button();
            edit.Text = "Edit Item";
            edit.CssClass = "btn btn-link";
            edit.ID = item.SKU.ToString();
            edit.Click += editClick;
            //Session["delSKU"] = item.SKU;
            td.Controls.Add(edit);
            tr.Cells.Add(td);
            productTable.Rows.Add(tr);

            return productTable;

        }

        /*private void GetControl(ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                Item item = new Item();
                if (ctrl.ID == item.SKU.ToString())
                {
                    e = (Button)ctrl;
                }

                if (ctrl.Controls != null)
                    // call recursively this method to search nested control for the button 
                    GetControl(ctrl.Controls);
            }

        }

        protected void cartClick(Object Sender, EventArgs e)
        {
            Button theButton = (Button)Sender;

        }*/

        protected void editClick(Object Sender, EventArgs e)
        {
            //whichever button is clicked with id = SKU
            Button theButton = (Button)Sender;

            int id = int.Parse(theButton.ID);

            ItemTier tier = new ItemTier();
            Item item = tier.getItemByID(id);


            Session["ItemInfo"] = (Item)Session["ItemInfo"];
            Session["ItemInfo"] = item;

            //Redirect to edit page
            Response.Redirect("EditItem.aspx");

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddItem.aspx");
        }
    }
}