﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace EMI.Models
{
    public class Email
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide your surname."), Display(Name = "Surname")] public string Surname { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide your name."), Display(Name = "First Name")]
        public string Name
        {
            get; set;
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide your cellphone number."), Display(Name = "CellPhone"), Phone(ErrorMessage = "Please provide a correct cellphone number.")]
        public string Cellphone
        {
            get; set;
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide your message."), Display(Name = "Message")]
        public string Message
        {
            get; set;
        }

        public string Subject
        {
            get; set;
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide your email address."), Display(Name = "Email Address"), EmailAddress(ErrorMessage = "Please provide a correct email address.")]
        public string EmailAddress
        {
            get; set;
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide your address."), Display(Name = "Address")]
        public string Address
        {
            get; set;
        }
    }
}