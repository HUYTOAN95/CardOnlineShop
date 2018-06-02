using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardOnlineShop.Areas.Admin.Models.DataModel
{
    [Table("BillDetail")]
    public class BillDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BillDetailID { get; set; }
        [Display(Name = "Số hóa đơn")]
        public string BillID { get; set; }

        [Display(Name = "Mã sản phẩm")]
        public int ProductID { get; set; }
        [Display(Name = "Số lượng")]
        public int Quanlity { get; set; }
        public virtual Bill Bill { get; set; }
        public virtual Product Product { get; set; }
    }
}