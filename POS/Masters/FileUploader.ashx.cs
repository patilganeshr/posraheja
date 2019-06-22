using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace POS.Masters
{
    /// <summary>
    /// Summary description for FileUploader
    /// </summary>
    public class FileUploader : IHttpHandler
    {   
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                if (context.Request.Files.Count > 0)
                {
                    HttpFileCollection files = context.Request.Files;

                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFile file = files[i];

                        string fname;

                        if (HttpContext.Current.Request.Browser.Browser.ToUpper() == "IE" || HttpContext.Current.Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                        }

                        if ((file.ContentLength/1024/1024) < 100)
                        {
                            //fname = Path.Combine(context.Server.MapPath("~/UploadedFiles/CoursesDocuments/"), fname);

                            fname = fname.Replace(" ", "_");

                            var serverPath = context.Server.MapPath("~/");

                            var folderPath = context.Request.Form.GetValues("File_Path")[0];

                            var createdBy = Convert.ToInt32(context.Request.Form.GetValues("Created_By")[0]);

                            if (Directory.Exists(serverPath + folderPath) == false)
                            {
                                Directory.CreateDirectory(serverPath + folderPath);
                            }

                            fname = Path.Combine(serverPath + folderPath, fname);

                            file.SaveAs(fname);

                            //SaveUploadedDocumentDetails(folderPath, fname, createdBy);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("<script> alert(" + ex.Message + "); </script> ");
                //Note: Exception.Message returns a detailed message that describes the current exception. 
                //For security reasons, we do not recommend that you return Exception.Message to end users in 
                //production environments. It would be better to put a generic error message.
            }

        }


        //public void ProcessRequest(HttpContext context, string filePath)
        //{
        //    if (context.Request.Files.Count > 0)
        //    {
        //        HttpFileCollection files = context.Request.Files;
        //        for (int i = 0; i < files.Count; i++)
        //        {
        //            HttpPostedFile file = files[i];
        //            string fname;
        //            if (HttpContext.Current.Request.Browser.Browser.ToUpper() == "IE" || HttpContext.Current.Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
        //            {
        //                string[] testfiles = file.FileName.Split(new char[] { '\\' });
        //                fname = testfiles[testfiles.Length - 1];
        //            }
        //            else
        //            {
        //                fname = file.FileName;
        //            }

        //            //fname = Path.Combine(context.Server.MapPath("~/UploadedFiles/CoursesDocuments/"), fname);
        //            fname = Path.Combine(context.Server.MapPath(filePath), fname);
        //            file.SaveAs(fname);
        //        }
        //    }
        //}

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }

}