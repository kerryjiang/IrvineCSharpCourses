using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Example20.Models
{
    public partial class FileViewModel
    {
        [Required]
        [FileExtensions(Extensions = "jpg,jpeg")]
        public IFormFile File { get; set; }

        [Required]
        public string Description { get; set; }
    }
}