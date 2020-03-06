using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalProj.Models;
using FinalProj.DataAccess;

namespace FinalProj
{
    public partial class Sales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SaleTier theTier = new SaleTier();
            List<Sale> saleList = theTier.getAllItems();

            grvSale.DataSource = saleList;
            grvSale.DataBind();
        }
    }
}