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
    public partial class Order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ItemTier theTier = new ItemTier();
            List<Item> products = theTier.getLowItems();
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
            theLabel.Text = "Price: $" + item.price.ToString("C", CultureInfo.CurrentCulture);
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

            Button ord = new Button();

            tr = new TableRow();
            td = new TableCell();
            ord = new Button();
            ord.Text = "Order This";
            ord.CssClass = "btn btn-primary";
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

            Session["OrderInfo"] = new Orders();
            Orders ord = (Orders)Session["OrderInfo"];
            ord.SKU = id;
            Session["OrderInfo"] = ord;

            List<Item> items = (List<Item>)Session["Incoming"];
            ItemTier theTier = new ItemTier();
            items = theTier.getIncomingItems();
            Session["Incoming"] = items;

            bool exists = false;
            if (items != null) {
                for (int i = 0; i < items.Count(); i++)
                {
                    if (items[i].SKU == id)
                        exists = true;
                }
                if (exists == true)
                {
                    Response.Write("<script>alert('Item has already been ordered. Check Pending orders page.')</script>");
                }
                else
                {

                    Response.Redirect("OrderConf.aspx");
                }
            }
            else
            {
                Response.Redirect("OrderConf.aspx");
            }
        }

    }
}