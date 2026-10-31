using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Demo.PL.Helpers
{
    public class DecumentSettings
    {
        public static string UpLoadFile(IFormFile file,string folderName)
        {
            //1.gett located Folder pass
            //string folderPass = "D:\\Projects Mvc\\Demo.PL Solution\\Demo.PL\\wwwroot\\files\\  " + folderName;

            //string folderPass=Directory.GetCurrentDirectory()+ @"\wwwroot\files\"+ folderName;


            string folderPath = Path.Combine(Directory.GetCurrentDirectory() +"wwwroot\\files" + folderName);
            if (!Directory.Exists(folderPath)) 
               Directory.CreateDirectory(folderPath);

            //2.Get File Name And Make It Unique
            string fileName = $"{Guid.NewGuid()}{file.FileName}";

            //3.Get file path

            string filePath=Path.Combine(folderPath, fileName);

            //4. save file as stream [ data per time]

            var fileStream = new FileStream(filePath, FileMode.Create);

            file.CopyTo(fileStream);

            return fileName;

        }

        public static void DeleteFile(string fileName,string folderName)
        {

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files",folderName,fileName);

            if(File.Exists(filePath)) 
                 File.Delete(filePath);
        }

    }
}
