using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Example20.Models
{
    public partial class UploadedFileViewModel
    {        
        public string ImageFile { get; set; }

        public string ImageFileThumbnail { get; set; }

        public string Description { get; set; }
    }
}