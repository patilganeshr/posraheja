using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using System.Web;

namespace SharpiTech.POS.API.Controllers
{
    public class FileUploadController : ApiController
    {
        public FileUploadController()
        {

        }

        [Route("UploadFiles")]
        [HttpPost]
        public HttpResponseMessage UploadFiles()
        {
            Int32 maxlength = 2000000;

            HttpResponseMessage result = null;

            var httpRequest = HttpContext.Current.Request;

            if (httpRequest.Files[0].ContentLength < maxlength)
            {
                var docfiles = new List<string>();

                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];

                    string e = Path.GetExtension(postedFile.FileName);

                    string folderPath = HttpContext.Current.Server.MapPath("../POS/UploadedFiles/Items/");

                    //Check whether Directory (Folder) exists.
                    if (!Directory.Exists(folderPath))
                    {
                        //If Directory (Folder) does not exists. Create it.
                        Directory.CreateDirectory(folderPath);
                    }
                    //postedFile.SaveAs(path);
                    postedFile.SaveAs(folderPath + postedFile.FileName);
                    docfiles.Add(folderPath + postedFile.FileName);
                }

                result = Request.CreateResponse(HttpStatusCode.Created, docfiles);
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return result;
        }

    }
}
