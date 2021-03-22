using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChetuProject.Models
{
    public class UserAccount
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="UserName is required.")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Compare("Password",ErrorMessage ="Please Confirm Your Password.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }


        [Required(ErrorMessage = "Email is required.")]
        //[RegularExpression(@"^\w +@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$",ErrorMessage ="Please Enter Valid Email.")]
        public string Email { get; set; }


      [Required(ErrorMessage = "Gender is required.")]
        public Gen gender { get; set; }


        [Required(ErrorMessage = "MobileNo is required.")]
        public string MobileNo { get; set; }


       // [Required(ErrorMessage = "FileUplaod is required.")]
        public string ProfileImage { get; set; }


        public bool Status { get; set; }


    }

    public enum Gen
    { 
      Male,
      Female
    }
}