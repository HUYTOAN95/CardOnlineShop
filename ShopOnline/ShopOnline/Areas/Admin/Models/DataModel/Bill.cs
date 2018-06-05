using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopOnline.Areas.Admin.Models.DataModel
{
    [Table("Bill")]
    public class Bill
    {
        [Display(Name = "Số hóa đơn")]
        public string  BillID { get; set; }
       
        [DataType(DataType.Date)]
        [Display(Name = "Ngày tạo hóa đơn")]
        public DateTime CreateDate { get; set; }
        // thuộc tính khóa ngoại
        [Required(ErrorMessage = "Hãy nhập mã nhân viên")]

        [Column(TypeName = "varchar")]
        [Display(Name = "Mã nhân viên")]
        public string EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<BillDetail> BillDetail { get; set; }
    }
}