using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Zenefits.Assignment.Service.WebUtilities;

namespace Zenefits.Assignment.Service.Controllers
{
    public class BaseController : ApiController
    {
        private IServiceProxy _assignmentProxy;
        private static readonly object padlock = new object();
        public IServiceProxy AssignmentProxy
        {
            get
            {
                lock (padlock)
                {
                    if (_assignmentProxy == null)
                    {
                        _assignmentProxy = new ServiceProxy();
                    }
                    return _assignmentProxy;
                }
            }
        }

        private readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public BaseController()
        {

        }

        
    }
}