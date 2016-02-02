using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel;

namespace WoMU_lab1.Models
{
 
    [Bind(Exclude = "OrderId")]
    public partial class Order
    {

        [ScaffoldColumn(false)]
        [Key]
        public int OrderId { get; set; }

        [ScaffoldColumn(false)]
        public System.DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [DisplayName("First Name")]
        [StringLength(30)]
        public string OrderFName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [DisplayName("Last Name")]
        [StringLength(50)]
        public string OrderSName { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(70)]
        public string OrderAddress { get; set; }

        [Required(ErrorMessage = "City is required")]
        [StringLength(40)]
        public string OrderCity { get; set; }

        [Required(ErrorMessage = "Postal Code is required")]
        [DisplayName("Postal Code")]
        [StringLength(10)]
        public string OrderZipCode { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [StringLength(24)]
        public string OrderPhone { get; set; }
    
        [DisplayName("Email Address")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
            ErrorMessage = "Email is is not valid.")]
        [DataType(DataType.EmailAddress)]
        public string OrderEmail { get; set; }

        [ScaffoldColumn(false)]
        public decimal OrderTotal { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

        public string ToString(Order order)
        {
            StringBuilder cooc = new StringBuilder();

            cooc.Append("<p>Order Information for Order: " + order.OrderId + "<br>Placed at: " + order.OrderDate + "</p>").AppendLine();
            cooc.Append("<p>Name: " + order.OrderFName + " " + order.OrderSName + "<br>");
            cooc.Append("Address: " + order.OrderAddress + " " + order.OrderCity + " " + order.OrderZipCode + "<br>");
            cooc.Append("Contact: " + order.OrderEmail + "     " + order.OrderPhone + "</p>");
            cooc.Append("<br>").AppendLine();
            cooc.Append("<Table>").AppendLine();
            // Display header 
            string header = "<tr> <th>Item Name</th>" + "<th>Quantity</th>" + "<th>Price</th> <th></th> </tr>";
            cooc.Append(header).AppendLine();

            String output = String.Empty;
            try
            {
                foreach (var article in order.OrderDetails)
                {
                    cooc.Append("<tr>");
                    output = "<td>" + article.Article.ArticleName + "</td>" + "<td>" + article.Quantity + "</td>" + "<td>" + article.Quantity * article.UnitPrice + "</td>";
                    cooc.Append(output).AppendLine();
                    Console.WriteLine(output);
                    cooc.Append("</tr>");
                }
            }
            catch (Exception ex)
            {
                output = "No items ordered.";
            }
            cooc.Append("</Table>");
            cooc.Append("<b>");
            // Display footer 
            string footer = String.Format("{0,-12}{1,12}\n",
                                          "Total", order.OrderTotal);
            cooc.Append(footer).AppendLine();
            cooc.Append("</b>");

            return cooc.ToString();
        }
    }
}