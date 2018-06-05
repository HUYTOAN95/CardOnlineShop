using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopOnline.Areas.Admin.Models.DataModel
{  
    [Table("Administrator")]
    public class Administrator
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        [Required(ErrorMessage ="Hãy nhập tên người dùng")]
        [StringLength(64,ErrorMessage ="Tên đăng nhập ko quá 3-64 kí tự")]
        [Column(TypeName ="varchar")]
        [Display(Name ="Tên đăng nhập")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Hãymật khẩu người dùng")]
        [Column(TypeName = "varchar")]
        [Display(Name = "Mật khẩu người dùng")]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }
        [Column(TypeName = "nvarchar")]
        public string FullName { get; set; }
     
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }
        public string Avatar { get; set; }
        [Display(Name = "Là quản trị")]
        public byte ? IsAdmin { get; set; }
        [Display(Name = "Kích hoạt")]
        public byte ? Allowed { get; set; }
        // thuộc tính khóa ngoại tham chiếu 
        public ICollection<GrantPermissions> GrantPermissions { get; set; }
    }

    
}