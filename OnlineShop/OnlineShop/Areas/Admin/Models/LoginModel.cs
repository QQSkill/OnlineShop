﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Mời nhập vào user name")]
        public string UserName { set; get; }

        [Required(ErrorMessage = "Mời nhập vào password")]
        public string PassWord { set; get; }

        public bool RememberMe { set; get; }
    }
}