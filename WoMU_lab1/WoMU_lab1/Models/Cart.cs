using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WoMU_lab1.Models
{
    public class Cart
    { 
        [Key]
        public int ID { get; set; }
        public string CartId { get; set; } 
        public int ArticleId { get; set; } 
        public int Count { get; set; } 
        public System.DateTime DateCreated { get; set; } 
        public virtual Article Article { get; set; } 
    } 
} 

