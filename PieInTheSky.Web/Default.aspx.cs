using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PieInTheSky.DTO;
using PieInTheSky.DTO.Enums;

namespace PieInTheSky.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void orderButton_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text.Trim().Length == 0)
            {
                errorMessageLabel.Text = "Please enter a name. ";
                errorMessageLabel.Visible = true;
                return;
            }

            if (addressTextBox.Text.Trim().Length == 0)
            {
                errorMessageLabel.Text = "Please enter an address. ";
                errorMessageLabel.Visible = true;
                return;
            }

            try
            {
                var order = buildOrder();
                Domain.OrderManager.CreateOrder(order);
                //Response.Redirect("Success.aspx");
            }
            catch (Exception ex)
            {
                errorMessageLabel.Visible = true;
                errorMessageLabel.Text = ex.Message;
            }
        }

        private DTO.OrderDTO buildOrder()
        {
            var order = new DTO.OrderDTO();
            order.Id = Guid.NewGuid();
            order.Size = getSizeType();
            order.Crust = getCrustType();
            order.Sausage = sausageCheckBox.Checked;
            order.Pepperoni = pepperoniCheckBox.Checked;
            order.Onions = onionsCheckBox.Checked;
            order.GreenPeppers = greenpeppersCheckBox.Checked;
            order.Name = nameTextBox.Text;
            order.Address = addressTextBox.Text;
            order.Zip = zipTextBox.Text;
            order.Phone = phoneTextBox.Text;
            order.PaymentType = getPaymentType();
            order.Completed = false;
            order.TotalCost = Domain.PriceListManager.CalculateOrderTotal(order);

            return order;
        }

        private SizeType getSizeType()
        {
            DTO.Enums.SizeType size;
            if (!Enum.TryParse(sizeDropDownList.SelectedValue, out size))
            { throw new Exception("Could not determine the size type"); }
            else
            { return size; }
        }

        private CrustType getCrustType()
        {
            DTO.Enums.CrustType crust;
            if (!Enum.TryParse(crustDropDownList.SelectedValue, out crust))
            { throw new Exception("Could not determine the crust type"); }
            else
            { return crust; }
        }

        private PaymentType getPaymentType()
        {
            PaymentType paymentType;
            paymentType = (creditRadioButton.Checked) ? PaymentType.Credit : PaymentType.Cash;

            return paymentType;
        }

        protected void recalculateCost(object sender, EventArgs e)
        {
            if (sizeDropDownList.SelectedValue == string.Empty) return;
            if (crustDropDownList.SelectedValue == string.Empty) return;
            var order = buildOrder();
            resultLabel.Text = String.Format("Order Total: {0}", order.TotalCost.ToString("C"));
        }

    }
}