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
        [StringLength(30, ErrorMessage ="Between 3 & 30 characters", MinimumLength =3)]
        public string OrderFName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [DisplayName("Last Name")]
        [StringLength(50, ErrorMessage = "Between 3 & 50 characters", MinimumLength = 3)]
        public string OrderSName { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(70, ErrorMessage = "Between 5 & 70 characters", MinimumLength = 5)]
        public string OrderAddress { get; set; }

        [Required(ErrorMessage = "City is required")]
        [StringLength(40, ErrorMessage = "Between 3 & 40 characters", MinimumLength = 3)]
        public string OrderCity { get; set; }

        [Required(ErrorMessage = "Postal Code is required")]
        [DisplayName("Postal Code")]
        [StringLength(10, ErrorMessage = "Between 3 & 10 characters", MinimumLength = 3)]
        public string OrderZipCode { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [StringLength(24, ErrorMessage = "Between 3 & 24 characters", MinimumLength = 3)]
        public string OrderPhone { get; set; }
    
        [DisplayName("Email Address")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
            ErrorMessage = "Email is is not valid.")]
        [DataType(DataType.EmailAddress)]
        public string OrderEmail { get; set; }

        [ScaffoldColumn(false)]
        public decimal OrderTotal { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}