using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Example20.Models;
using System.IO;
using SkiaSharp;
using System.Net.Http.Headers;

namespace Example20.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public HomeController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Upload(FileViewModel fileView)
        {
            var imagesDir = Path.Combine(_hostingEnvironment.WebRootPath, "Images");

            if (!Directory.Exists(imagesDir))
                Directory.CreateDirectory(imagesDir);

            var fileContentDisposition = ContentDispositionHeaderValue.Parse(fileView.File.ContentDisposition);
            var originalFileName = fileContentDisposition.FileName.Trim('"');
          
            var ext = Path.GetExtension(originalFileName);
            
            var fileNameWithoutExt = Guid.NewGuid().ToString();
            var fileName = fileNameWithoutExt + ext;

            var targetFilePath = Path.Combine(imagesDir, fileName);

            using(var stream = System.IO.File.OpenWrite(targetFilePath))
            {
                fileView.File.CopyTo(stream);
            }

            var thumbnailFileName = fileNameWithoutExt + "_th" + ext;
            var thumbnailFilePath = Path.Combine(imagesDir, thumbnailFileName);
            

            MakeThumbnail(targetFilePath, thumbnailFilePath, 150, 70);

            return View("UploadOk", new UploadedFileViewModel
            {
                Description = fileView.Description,
                ImageFile = "/Images/" + fileName,
                ImageFileThumbnail = "/Images/" + thumbnailFileName
            });
        }

        private void MakeThumbnail(string inputFile, string outputFile, int size, int quality)
        {
            using (var input = System.IO.File.OpenRead(inputFile))
            {
                using (var inputStream = new SKManagedStream(input))
                {
                    using (var original = SKBitmap.Decode(inputStream))
                    {
                        int width, height;
                        if (original.Width > original.Height)
                        {
                            width = size;
                            height = original.Height * size / original.Width;
                        }
                        else
                        {
                            width = original.Width * size / original.Height;
                            height = size;
                        }

                        using (var resized = original
                            .Resize(new SKImageInfo(width, height), SKBitmapResizeMethod.Lanczos3))
                        {
                            if (resized == null) return;

                            using (var image = SKImage.FromBitmap(resized))
                            {
                                using (var output = 
                                    System.IO.File.OpenWrite(outputFile))
                                {
                                    image.Encode(SKEncodedImageFormat.Jpeg, quality)
                                        .SaveTo(output);
                                }
                            }
                        }
                    }
                }
            }
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
