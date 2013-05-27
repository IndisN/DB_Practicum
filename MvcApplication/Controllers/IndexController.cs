using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WPF_Viewer;

namespace MvcApplication.Controllers
{
    public class IndexApiController : ApiController
    {
        WPF_Viewer.MVVM model = new WPF_Viewer.MVVM();

        [System.Web.Http.HttpGet]
        public MVVM GetModel()
        {
            return model;
        }

    }
}
