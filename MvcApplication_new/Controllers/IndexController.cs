using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using WPF_Viewer;

namespace MvcApplication_new.Controllers
{
    public class IndexApiController : ApiController
    {
        MVVM model = new MVVM();

        [System.Web.Http.HttpGet]
        public MVVM GetModel()
        {
            return model;
        }
    }
}
