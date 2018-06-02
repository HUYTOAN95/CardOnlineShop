using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardOnlineShop.Areas.Admin.Models.DataModel
{ [Table("GrantPermissions")]
    public class GrantPermissions
    {   [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PermissionID { get; set; }
        [Required(ErrorMessage = "Hãy nhập quyền truy cập")]
        [StringLength(64, ErrorMessage = "Tên đăng nhập ko quá 3-64 kí tự")]
        [Column(TypeName = "varchar")]
        [Display(Name = "Tên đăng nhập")]
        public string PemissionName { get; set; }
        [Display(Name = "Mô tả")]
        public string Descrpition { get; set; }
        public int UserID { get; set; }
        public virtual Administrator Administrator { get; set; }
    }
}