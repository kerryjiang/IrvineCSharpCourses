using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Example19.Models
{
    public partial class LoginViewModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}