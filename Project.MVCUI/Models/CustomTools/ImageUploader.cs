using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Project.MVCUI.Models
{
    public static class ImageUploader
    {
        public static string ImageUpload(string serverPath, HttpPostedFileBase file, string name)
        {
            if (file != null)
            {
                Guid uniqueName = Guid.NewGuid();
                string[] fileArray = file.FileName.Split('.');
                string extansion = fileArray[fileArray.Length].ToLower();
                string fileName = $"{uniqueName}.{name}.{extansion}";

                if (extansion =="jpg"|| extansion=="jpeg" ||extansion=="png" || extansion == "gif")
                {
                    if (File.Exists(HttpContext.Current.Server.MapPath(serverPath+fileName)))
                    {
                        return "1";
                    }
                    else
                    {
                        string filePath = HttpContext.Current.Server.MapPath(serverPath + fileName);
                        file.SaveAs(filePath);
                        return $"{serverPath}{fileName}";
                    }

                }
                else
                {
                    return "2";
                }
            }
            else { return "3"; }
            


        }
    }
}