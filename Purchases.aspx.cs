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
    public partial class Purchases : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                Users me = (Users)Session["UserID"];

                SaleTier theTier = new SaleTier();
                List<Sale> sales = theTier.getUserPurchase(me.user_id);
                if (sales == null)
                {
                    lblPurch.Text = "No items to display.";
                }
                else
                {
                    lblPurch.Text = " ";
                    Table theTable = null;
                    foreach (Sale order in sales)
                    {
                        Sale s = new Sale();
                        s.sales_no = order.sales_no;
                        s.SKU = order.SKU;
                        s.user_id = order.user_id;
                        Session["MyPurchases"] = s;

                        ItemTier aTier = new ItemTier();
                        Item items = aTier.getItemByID(s.SKU);

                        //foreach (Item item in items)
                        //{
                            theTable = getItemTable(items);
                            pnlOut.Controls.Add(theTable);
                        //}
                    }
                }
            }
            else
            {
                Response.Redirect("UserProductList.aspx");
            }

        }

        protected Table getItemTable(Item item)
        {
            Sale sale = (Sale)Session["MyPurchases"];

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

            return productTable;

        }

    }
}