using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopOnline.Areas.Admin.Models.DataModel
{
    public class SubMenu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubMenuID { get; set; }
        public string SubMenuName { get; set; }
        public string Link { get; set; }
        public string Icon { get; set; }
      
    }
}