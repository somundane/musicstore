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
    public partial class PendingOrders : System.Web.UI.Page
    {
        int orderno;
        int qty;

        protected void Page_Load(object sender, EventArgs e)
        {
            OrderTier theTier = new OrderTier();
            List<Orders> orders = (List<Orders>)Session["Pending"];
            orders = theTier.getPendingOrders();

            if (orders == null)
            {
                lblOrd.Text = "No items to display.";
            }
            else
            {
                lblOrd.Text = " ";
                Table theTable = null;
                foreach (Orders order in orders)
                {
                    orderno = order.order_no;
                    qty = order.qty_ordered;

               }
                ItemTier aTier = new ItemTier();
                List<Item> items = aTier.getIncomingItems();
                foreach (Item item in items)
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
            theLabel.Text = "Price: " + item.price.ToString("C", CultureInfo.CurrentCulture);
            td.Controls.Add(theLabel);
            tr.Cells.Add(td);
            productTable.Rows.Add(tr);

            tr = new TableRow();
            td = new TableCell();
            theLabel = new Label();
            theLabel.Text = "Qty ordered: " + qty;
            td.Controls.Add(theLabel);
            tr.Cells.Add(td);
            productTable.Rows.Add(tr);

            Button rec = new Button();

            tr = new TableRow();
            td = new TableCell();
            rec = new Button();
            rec.Text = "Received";
            rec.CssClass = "btn btn-success";
            rec.ID = item.SKU.ToString();
            rec.Click += recClick;
            td.Controls.Add(rec);
            tr.Cells.Add(td);
            productTable.Rows.Add(tr);

            return productTable;

        }

        protected void recClick(Object Sender, EventArgs e)
        {

            Button theButton = (Button)Sender;
            int id = int.Parse(theButton.ID);

            ItemTier tier = new ItemTier();
            Item item = tier.getItemByID(id);

            ItemTier itemTier = new ItemTier();
            itemTier.itemRec(id, qty);
            OrderTier ordTier = new OrderTier();
            ordTier.orderRec(orderno);

            Session["OrderInfo"] = null;

            //Redirect to edit page
            Response.Redirect("PendingOrders.aspx");
        }
    }
}