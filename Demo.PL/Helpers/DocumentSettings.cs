using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Demo.PL.Helpers
{
    public class DocumentSettings
    {

        public static string UploadFile(IFormFile file,string folderName)
        {
            //Get Located Folder Path
            //string folderPath = "D:\\Projects\\MVC Project\\DemoSolution\\Demo.PL\\wwwroot\\files\\images\\";//We can't use static path like that
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\files", folderName);

            //2.Get File Name and make it unique

            string fileName = $"{Guid.NewGuid()},{file.FileName}";

            string filePath = Path.Combine(folderPath,fileName);

            //Save File As Stream

            using (var fs = new FileStream(filePath, FileMode.Create)) 
            file.CopyTo(fs);

            return fileName;
        }
    }
}
