using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Example19.Models
{
    public partial class EditUserViewModel
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public List<SelectListItem> AllRoles { get; set; }

        public short[] SelectedRoles { get; set; }
    }
}