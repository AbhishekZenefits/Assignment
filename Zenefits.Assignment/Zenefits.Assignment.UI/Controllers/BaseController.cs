using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Zenefits.Assignment.UI.WebUtilities;

namespace Zenefits.Assignment.UI.Controllers
{
    public class BaseController : Controller
    {
        #region
        public IServiceProxy _assignmentProxy;
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

        #endregion

        #region Constructor
        public BaseController()
        {
           
        }
        

        #endregion
    }
}