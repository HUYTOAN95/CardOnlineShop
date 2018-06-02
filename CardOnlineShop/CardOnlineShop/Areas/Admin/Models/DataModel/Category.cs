using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CardOnlineShop.Areas.Admin.Models.DataModel
{  [Table("Category")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryID { get; set; }
        [Required(ErrorMessage = "Hãy nhập tên loại hàng")]
       
        [Column(TypeName = "nvarchar")]
        [Display(Name = "Tên loại hàng")]
        public string CategoryName { get; set; }
        [Display(Name = "Trạng thái")]
        public bool CategoryStatus { get; set; }
        public virtual ICollection<Product> Product { get; set; }



    }
}