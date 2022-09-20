using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Shop.Data.Models
{
    public class Order
    {
        [BindNever]
        [Key]
        public int id { get; set; }

        [Display(Name = "Name")]
        [StringLength(20)]
        [Required(ErrorMessage ="Length name 20 simbol")]
        public string name { get; set; }

        [Display(Name = "Surname")]
        [StringLength(20)]
        [Required(ErrorMessage = "Length surname 20 simbol")]
        public string surname { get; set; }

        [Display(Name = "Adress")]
        [StringLength(20)]
        [Required(ErrorMessage = "Length adress 20 simbol")]
        public string adress { get; set; }

        [Display(Name = "Phone number")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(20)]
        [Required(ErrorMessage = "Length phone 20 simbol")]
        public string phone { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(20)]
        [Required(ErrorMessage = "Length email 20 simbol")]
        public string email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime orderTime { get; set; }

        public List<OrderDetail> orderDetails { get; set; }
    }
}
