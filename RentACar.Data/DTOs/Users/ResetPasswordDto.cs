﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Data.DTOs.Users
{
    public class ResetPasswordDto
    {

        public string CurrentPassword { get; set; }

        public string NewPassword { get; set; }


        public string ConfirmNewPassword { get; set; }
    }
}
