using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WoMU_lab1.Models {
    public class AddedArticleModel {
        public Article Article { get; set; }
        public Article[] Related { get; set; }
    }
}