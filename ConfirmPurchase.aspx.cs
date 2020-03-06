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
    public partial class ConfirmPurchase : System.Web.UI.Page
    {
        decimal total;
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Item> cart = (List<Item>)Session["cart"];

            if (cart != null)
            {
                total = (decimal)Session["total"];
                lblCart.Text = cart.Count.ToString() + " item(s) in cart.";
                lblTotal.Text = "Total is: $" + total.ToString("F", CultureInfo.InvariantCulture);
                Table theTable = null;
                foreach (Item item in cart)
                {
                    theTable = getItemTable(item);
                    pnlOut.Controls.Add(theTable);
                }
            }
            else
            {
                lblCart.Text = "No items to display.";
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

            //total purchase
            total = Decimal.Add(total, item.price);

            return productTable;

        }

        protected void btnSubmit_Click(Object Sender, EventArgs e)
        {

            List<Item> cart;

            if (Session["cart"] == null)
            {
                cart = new List<Item>();
            }
            else
            {
                cart = (List<Item>)Session["cart"];
            }

            Session["cart"] = null;

            foreach (Item buy in cart)
            {
                Sale sale = new Sale();
                sale.SKU = buy.SKU;
                sale.price = buy.price;
                //1 qty at a time for now
                sale.qty_sold = 1;


                Users me = (Users)Session["UserID"];
                sale.user_id = me.user_id;

                //add sale to table
                SaleTier add = new SaleTier();
                add.addSale(sale);

                //decrease item from inventory
                ItemTier dec = new ItemTier();
                dec.decreaseItem(buy.SKU);


                sale = null;

            }

            Session["cart"] = cart;

            cart.Clear();

            Response.Redirect("Purchases.aspx");

            total = 0;
        }

        protected void btnCancel_Click(Object Sender, EventArgs e)
        {
            Response.Redirect("Cart.aspx");
        }
    }
}