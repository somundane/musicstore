using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalProj.DataAccess;
using FinalProj.Models;

namespace FinalProj
{
    public partial class OrderConf : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtQty.Text == "")
            {
                Response.Write("<script>alert('Please enter a quantity')</script>");
            }
            else
            {
                Orders ord = (Orders)Session["OrderInfo"];
                ord.qty_ordered = Int32.Parse(txtQty.Text);
                Session["OrderInfo"] = ord;
                if (ord == null)
                {
                    Response.Write("<script>alert('null. thats weird')</script>");
                }
                else
                {

                    OrderTier ordTier = new OrderTier();
                    ordTier.insertOrder(ord);

                    Response.Redirect("Order.aspx");
                }


            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Order.aspx");
        }
    }
}