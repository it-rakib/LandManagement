using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;

namespace Common.Service.CommonFunction
{
    public class cmnUploadFile
    {
        private static readonly List<string> fileExtension = new List<string> { ".JPG", ".JJPE", ".BMP", ".GIF", ".PNG", ".DOC", ".DOCX", ".PDF", ".TXT", "WPT", ".XLSX", ".XLS" };

        public static List<string> FileExtension => fileExtension;

        public string Upload(IFormFile files, string fileFolderName, string docTypeName)
        {
            try
            {
                var file = files;

                var folderName = Path.Combine("Resources", "FilesAndImages", fileFolderName);
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                var dbPath = "";
                var historyDbPath = "";
                if (file.Length > 0)
                {
                    var Extension = Path.GetExtension(ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"'));
                    var fileName = docTypeName + "_" + fileFolderName + Extension;
                    if (FileExtension.Contains(Extension.ToUpperInvariant()))
                    {
                        //if folder not exist
                        if (!Directory.Exists(pathToSave))
                        {
                            Directory.CreateDirectory(pathToSave);
                            var fullPath = Path.Combine(pathToSave, fileName);
                            dbPath = Path.Combine(folderName, fileName);
                            //if file not exist
                            if (!File.Exists(fullPath))
                            {
                                using var stream = new FileStream(fullPath, FileMode.Create);
                                file.CopyTo(stream);
                            }
                            //if file exist
                            else
                            {
                                var historyfolder = Path.Combine(pathToSave, "History");
                                //if history folder not exist
                                if (!Directory.Exists(historyfolder))
                                {
                                    Directory.CreateDirectory(historyfolder);
                                    var historyDestination = Path.Combine(historyfolder, DateTime.Now.ToString("yyyyMMddHHmmss") + fileName);
                                    File.Move(fullPath, historyDestination);
                                    var oldFileName = DateTime.Now.ToString("yyyyMMddHHmmss") + fileName;
                                    historyDbPath = Path.Combine(folderName, "History", fileName);
                                    using var stream = new FileStream(fullPath, FileMode.Create);
                                    file.CopyTo(stream);
                                }
                                //if history folder exist
                                else
                                {
                                    var historyDestination = Path.Combine(historyfolder, DateTime.Now.ToString("yyyyMMddHHmmss") + fileName);
                                    File.Move(fullPath, historyDestination);
                                    historyDbPath = Path.Combine(folderName, "History", fileName);
                                    using var stream = new FileStream(fullPath, FileMode.Create);
                                    file.CopyTo(stream);
                                }
                            }
                        }
                        //if folder exist
                        else
                        {
                            var fullPath = Path.Combine(pathToSave, fileName);
                            dbPath = Path.Combine(folderName, fileName);
                            //if file not exist
                            if (!File.Exists(fullPath))
                            {
                                using var stream = new FileStream(fullPath, FileMode.Create);
                                file.CopyTo(stream);
                            }
                            //if file exist
                            else
                            {
                                var historyfolder = Path.Combine(pathToSave, "History");
                                //if history folder not exist
                                if (!Directory.Exists(historyfolder))
                                {
                                    Directory.CreateDirectory(historyfolder);
                                    var historyDestination = Path.Combine(historyfolder, DateTime.Now.ToString("yyyyMMddHHmmss") + fileName);
                                    File.Move(fullPath, historyDestination);
                                    historyDbPath = Path.Combine(folderName, "History", fileName);
                                    using var stream = new FileStream(fullPath, FileMode.Create);
                                    file.CopyTo(stream);
                                }
                                //if history folder exist
                                else
                                {
                                    var historyDestination = Path.Combine(historyfolder, DateTime.Now.ToString("yyyyMMddHHmmss") + fileName);
                                    File.Move(fullPath, historyDestination);
                                    historyDbPath = Path.Combine(folderName, "History", fileName);
                                    using var stream = new FileStream(fullPath, FileMode.Create);
                                    file.CopyTo(stream);
                                }
                            }
                        }
                    }
                    else
                    {
                        dbPath = "";
                    }
                    return dbPath;
                }
                else
                {
                    return dbPath;
                }
            }
            catch (Exception)
            {
                return "";
            }
        }

    }
}
