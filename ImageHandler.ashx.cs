using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProj.DataAccess;

namespace FinalProj
{
    /// <summary>
    /// Summary description for ImageHandler
    /// </summary>
    public class ImageHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            byte[] theImage;
            ItemTier theTier = new ItemTier();
            Int32 ImageID = Int32.Parse(context.Request.QueryString["ID"]);
            theImage = theTier.getImage(ImageID);
            if (theImage != null)
            {
                context.Response.BinaryWrite(theImage);
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}