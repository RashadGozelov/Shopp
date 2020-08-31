using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Projectt.Extentions
{
    public static class IFormFileExtention
    {
        public static bool IsImage(this IFormFile file)
        {
            return file.ContentType.Contains(@"image/");
        }

        public static bool ImageSizeCheck(this IFormFile file, int maxSize)
        {
            return file.Length / 1024 / 1024 < maxSize;
        }

        public async static Task<string> CopyImages(this IFormFile file, string root, string folder)
        {
            string path = Path.Combine(root, "img");
            string filename = Path.Combine(folder, Guid.NewGuid().ToString() + file.FileName);
            string resultfile = Path.Combine(path, filename);
            using (FileStream fileStream = new FileStream(resultfile, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            string filename_replace = filename.Replace(@"\", "/");
            return filename_replace;
        }
    }
}
