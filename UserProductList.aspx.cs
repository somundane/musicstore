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
    public partial class UserProductList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ItemTier theTier = new ItemTier();
            List<Item> products = theTier.getAllItems();
            Table theTable = null;

            if (products == null)
            {
                lblItem.Text = "No items to display.";
            }
            else
            {
                lblItem.Text = " ";
                foreach (Item item in products)
                {

                    if (item.quantity == 0)
                    {
                        theTable = outOfStockTable(item);
                        pnlOut.Controls.Add(theTable);
                    }
                    else
                    {
                        theTable = getItemTable(item);
                        pnlOut.Controls.Add(theTable);
                    }

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
            Button cart = new Button();

            tr = new TableRow();
            td = new TableCell();
            cart = new Button();
            cart.Text = "Add To Cart";
            cart.CssClass = "btn btn-success";
            cart.ID = item.SKU.ToString();
            cart.Click += cartClick;
            td.Controls.Add(cart);
            tr.Cells.Add(td);
            productTable.Rows.Add(tr);

            return productTable;

        }

        protected Table outOfStockTable(Item item)
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
            theLabel.Text = "Item currently out of stock";
            td.Controls.Add(theLabel);
            tr.Cells.Add(td);
            productTable.Rows.Add(tr);
            Button cart = new Button();

            return productTable;

        }

        protected void cartClick(Object Sender, EventArgs e)
        {
            //whichever button is clicked with id = SKU
            Button theButton = (Button)Sender;

            int id = int.Parse(theButton.ID);

            ItemTier tier = new ItemTier();
            Item item = tier.getItemByID(id);
            //create cart list
            List<Item> cart;


            //if empty session, create new list item
            if (Session["cart"] == null)
            {
                cart = new List<Item>();

                //add the item to the list
                cart.Add(item);

                //prevent this from being null which will empty your old list
                Session["cart"] = cart;

                Response.Write("<script>alert('Item added to cart')</script>");

            }
            //else open session where current list is and assign as current list
            else
            {
                bool exists = false;
                cart = (List<Item>)Session["cart"];
                for (int i = 0; i < cart.Count(); i++)
                {
                    if (id == cart[i].SKU)
                        exists = true;
                }

                if (exists == true)
                {
                    Response.Write("<script>alert('Item is already in cart')</script>");
                }
                else
                {

                    //add the item to the list
                    cart.Add(item);
                    Response.Write("<script>alert('Item added to cart')</script>");
                }

                //prevent this from being null which will empty your old list
                Session["cart"] = cart;
            }


        }

    }
}