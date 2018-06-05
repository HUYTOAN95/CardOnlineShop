using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopOnline.Areas.Admin.Models.DataModel
{  [Table("Employee")]
    public class Employee
    {   [Key]
        [Display(Name ="Mã nhân viên")]
        [Column(TypeName = "varchar")]
        public string EmployeeID { get; set; }
        [Display(Name = "Tên nhân viên")]
        public string EmployeeName { get; set; }
        [Display(Name = "Giới tính")]
        public string EmployeeGender { get; set; }
        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }
        [Display(Name ="Số điện thoại")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public virtual ICollection<Bill> Bill { get; set; }
      

    }
   
}