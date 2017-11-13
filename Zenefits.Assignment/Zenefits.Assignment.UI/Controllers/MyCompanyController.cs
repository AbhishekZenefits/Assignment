using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Zenefits.Assignment.Entities;
using Zenefits.Assignment.UI.WebUtilities;
using Zenefits.Assignment.Utilities;

namespace Zenefits.Assignment.UI.Controllers
{
    public class MyCompanyController : BaseController
    {
        #region Class Variables

        private readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Contructor
        public MyCompanyController()
        {
            
        }

        #endregion

        #region Controller Methods

        /// <summary>
        /// This method returns the Index View
        /// </summary>
        /// <returns>Returns Index.cshtml</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// UI Controller method to get the left side Company Names
        /// </summary>
        /// <returns>Returns the partial view with the company data</returns>
        public ActionResult LeftBanner()
        {
            var companies = GetCompanyData();

            return PartialView("~/Views/MyCompany/_Menu.cshtml", companies);
        }

        /// <summary>
        /// This is the UI controller method to get the company data
        /// </summary>
        /// <returns>Returns the list of company's data</returns>
        [HttpGet]
        public List<CompanyDatumEntity> GetCompanyData()
        {
            var companyData = new CompanyRootObjectEntity();
            try
            {
                companyData = AssignmentProxy.WebGet<CompanyRootObjectEntity>(string.Format("api/MyCompany/GetCompanyData"));
                log.Info("Company data fetched successfully to UI!!");
            }
            catch (Exception ex)
            {
                log.Error("GetCompanyData : Message" + ex.Message + "InnerException" + "" + ex.InnerException + "Source" + ex.Source);
            }
            return companyData.Data.Data;
        }

        /// <summary>
        /// UI controller method to return the view with Departments
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns>Returns the view for the department data</returns>
        public ActionResult DepartmentDetails(string companyId)
        {
            var departments = GetDepartmentData(companyId);

            return View("~/Views/MyCompany/Departments.cshtml", departments);
        }

        /// <summary>
        /// UI Controller method to fetch the department data
        /// </summary>
        /// <param name="companyId">Company Id to fetch the department data</param>
        /// <returns>Returns the department data for a company</returns>
        [HttpGet]
        public List<DepartmentDatumEntity> GetDepartmentData(string companyId)
        {
            var departmentData = new DepartmentRootObjectEntity();
            try
            {
                departmentData = AssignmentProxy.WebGet<DepartmentRootObjectEntity>(string.Format("api/MyCompany/GetDepartmentData?companyId={0}", 
                    companyId));
                log.Info("Department data fetched successfully to UI!!");
            }
            catch (Exception ex)
            {
                log.Error("GetDepartmentData : Message" + ex.Message + "InnerException" + "" + ex.InnerException + "Source" + ex.Source);
            }
            return departmentData.Data.Data;
        }

        /// <summary>
        /// UI controller method to return the view with Employees
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns>Returns the view for the employee data</returns>
        public ActionResult EmployeeDetails(string companyId)
        {
            var employees = GetPeopleData(companyId);

            return View("~/Views/MyCompany/Employee.cshtml", employees);
        }

        /// <summary>
        /// UI Controller method to fetch the people data for a company
        /// </summary>
        /// <param name="companyId">Company Id to fetch the people data</param>
        /// <returns>Returns the people data for a company</returns>
        [HttpGet]
        public List<EmployeeHierarchy> GetPeopleData(string companyId)
        {
            var peopleData = new List<EmployeeHierarchy>();
            try
            {
                peopleData = AssignmentProxy.WebGet<List<EmployeeHierarchy>>(string.Format("api/MyCompany/GetPeopleData?companyId={0}", companyId));
                log.Info("People data fetched successfully to UI!!");
            }
            catch (Exception ex)
            {
                log.Error("GetPeopleData : Message" + ex.Message + "InnerException" + "" + ex.InnerException + "Source" + ex.Source);
            }
            return peopleData;
        }

        #endregion
    }
}