using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WPF_Viewer;

namespace WebApplication1.Controllers
{
    public class IndexApiController : ApiController
    {
        WPF_Viewer.MVVM model = new WPF_Viewer.MVVM();

        [HttpGet]
        public MVVM GetModel()
        {
            return model;
        }
    }
}