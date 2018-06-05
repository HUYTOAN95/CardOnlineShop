using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopOnline.Areas.Admin.Models.DataModel
{
    [Table("Procuct")]
    public class Product
    {
        [Display(Name = "Mã sản phẩm")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }
        [Required(ErrorMessage = "Hãy nhập tên sản phẩm")]

        [Column(TypeName = "nvarchar")]
        [Display(Name = "Tên sản phẩm")]
        public string ProductName { get; set; }
        [Display(Name = "Trạng thái")]
        public bool ProductStatus { get; set; }
        [Display(Name = "Giá tiền sản phẩm")]
        [DataType(DataType.Currency)]
        public int ProductCost { get; set; }
        [Display(Name = "Mã loại hàng")]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<BillDetail> BillDetail { get; set; }
    }
}