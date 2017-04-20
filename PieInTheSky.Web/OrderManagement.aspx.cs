using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PieInTheSky.Web
{
    public partial class OrderManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            refreshGrid();
        }

        protected void orderGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = orderGridView.Rows[index];
            var value = row.Cells[1].Text.ToString();
            var orderId = Guid.Parse(value);

            Domain.OrderManager.CompleteOrder(orderId);
            refreshGrid();
        }

        private void refreshGrid()
        {
            var orders = Domain.OrderManager.GetOrders();
            orderGridView.DataSource = orders;
            orderGridView.DataBind();
        }
    }
}