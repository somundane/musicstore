using System;
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
    public partial class Cart : System.Web.UI.Page
    {
        //int count = -1;
        decimal total = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Item> cart = (List<Item>)Session["cart"];

            if (cart != null)
            {
                lblCart.Text = cart.Count.ToString() + " item(s) in cart";
                Table theTable = null;
                foreach (Item item in cart)
                {
                    theTable = getItemTable(item);
                    pnlOut.Controls.Add(theTable);
                    total += item.price;
                }
            }
            else
            {
                lblCart.Text = "No items to display.";
                Session["cart"] = null;
            }
        }

        protected Table getItemTable(Item item)
        {
            Table productTable = new Table();
            TableRow tr = new TableRow();
            TableCell td = new TableCell();
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

            Button ord = new Button();

            tr = new TableRow();
            td = new TableCell();
            ord = new Button();
            ord.Text = "Remove";
            ord.CssClass = "btn btn-danger";
            ord.ID = item.SKU.ToString();
            ord.Click += ordClick;
            td.Controls.Add(ord);
            tr.Cells.Add(td);
            productTable.Rows.Add(tr);

            return productTable;

        }

        protected void ordClick(Object Sender, EventArgs e)
        {
            //whichever button is clicked with id = SKU
            Button theButton = (Button)Sender;
            int id = int.Parse(theButton.ID);

            ItemTier tier = new ItemTier();
            Item item = tier.getItemByID(id);
            //create cart list
            List<Item> cart = (List<Item>)Session["cart"];
            
            if (Session["cart"] == null)
            {
                cart = new List<Item>();
            }
            else
            {
                for (int i = 0; i < cart.Count(); i++)
                {
                    if (cart[i].SKU == id)
                    {
                        cart = (List<Item>)Session["cart"];
                        //comments similar to userproductlist.aspx except this one removes
                        cart.RemoveAt(i);

                        Session["cart"] = null;

                        //count = -1;

                        Session["cart"] = cart;
                    }
                }
            }

            //Redirect to same page / refresh
            Response.Redirect("Cart.aspx");
        }

        protected void btnAdd_Click(Object Sender, EventArgs e)
        {
            if (Session["cart"] == null)
            {
                Response.Write("<script>alert('Your cart is empty')</script>");
            }
            else
            {
                Session["total"] = total;
                Response.Redirect("ConfirmPurchase.aspx");
            }
        }
    }
}