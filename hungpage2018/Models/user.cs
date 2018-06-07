using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace hungpage2018.Models
{
    public class user
    {
        [Required(ErrorMessage = "This field is required.")]
        public string username { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is required.")]
        public string password { get; set; }
    }
}