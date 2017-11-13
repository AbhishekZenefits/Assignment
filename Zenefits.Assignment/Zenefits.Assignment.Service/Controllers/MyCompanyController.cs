using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Zenefits.Assignment.Entities;
using Zenefits.Assignment.Utilities;

namespace Zenefits.Assignment.Service.Controllers
{
    public class MyCompanyController : BaseController
    {
        #region Class Variables

        private readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Constructor
        public MyCompanyController()
        {

        }
        
        #endregion

        #region Service Methods

        /// <summary>
        /// This is the API controller method to get the company data
        /// </summary>
        /// <returns>Returns the list of company's data as an entity</returns>
        [HttpGet]
        public CompanyRootObjectEntity GetCompanyData()
        {
            var companyData = new CompanyRootObjectEntity();
            try
            {
                companyData = AssignmentProxy.WebGet<CompanyRootObjectEntity>(AssignmentConstants.BASE_SERVICE_URL);
                log.Info("Company data fetched from service successfully!!");
            }
            catch (Exception ex)
            {
                log.Error("GetCompanyData : Message" + ex.Message + "InnerException" + "" + ex.InnerException + "Source" + ex.Source);
            }

            return companyData;
        }

        /// <summary>
        /// API Controller method to fetch the department data
        /// </summary>
        /// <param name="companyId">Company Id to fetch the department data</param>
        /// <returns>Returns the department data for a company as an entity</returns>
        [HttpGet]
        public DepartmentRootObjectEntity GetDepartmentData(string companyId)
        {
            var departmentData = new DepartmentRootObjectEntity();
            try
            {
                departmentData = AssignmentProxy.WebGet<DepartmentRootObjectEntity>(AssignmentConstants.BASE_SERVICE_URL + "/" + companyId +
                    AssignmentConstants.DEPARTMENT_SERVICE_URL);
                log.Info("Department data fetched from service successfully!!");
            }
            catch (Exception ex)
            {
                log.Error("GetDepartmentData : Message" + ex.Message + "InnerException" + "" + ex.InnerException + "Source" + ex.Source);
            }

            return departmentData;
        }

        /// <summary>
        /// API Controller method to fetch the people data for a company
        /// </summary>
        /// <param name="companyId">Company Id to fetch the people data</param>
        /// <returns>Returns the people data fhierarchy as a list of entity</returns>
        [HttpGet]
        public List<EmployeeHierarchy> GetPeopleData(string companyId)
        {
            var peopleData = new PeopleRootObjectEntity();
            var peopleHierarchy = new List<EmployeeHierarchy>();

            try
            {
                peopleData = AssignmentProxy.WebGet<PeopleRootObjectEntity>(AssignmentConstants.BASE_SERVICE_URL + "/" + companyId +
                    AssignmentConstants.PEOPLE_SERVICE_URL);
                log.Info("People's data fetched from service successfully!!");

                peopleHierarchy = FindChildren(peopleData.Data.Data, null);

            }
            catch (Exception ex)
            {
                log.Error("GetPeopleData : Message" + ex.Message + "InnerException" + "" + ex.InnerException + "Source" + ex.Source);
            }

            return peopleHierarchy;
        }

        /// <summary>
        /// Private recursive method to get the employee hierarchy using DFS Algorithm
        /// </summary>
        /// <param name="data"></param>
        /// <param name="parentId"></param>
        /// <returns>Returns the hierarchical data</returns>
        private List<EmployeeHierarchy> FindChildren(List<PeopleDatumEntity> data, string parentId)
        {
            List<EmployeeHierarchy> result = new List<EmployeeHierarchy>();
            foreach (var item in data)
            {
                if((string.IsNullOrEmpty(item.Manager.Url) && string.IsNullOrEmpty(parentId)) || (!string.IsNullOrEmpty(parentId) && !string.IsNullOrEmpty(item.Manager.Url) && item.Manager.Url.Contains(parentId)))
                {
                    EmployeeHierarchy node = new EmployeeHierarchy();
                    node.FirstName = item.FirstName;
                    node.LastName = item.LastName;
                    node.Gender = item.Gender;
                    node.Id = item.Id;
                    node.Child = FindChildren(data, node.Id);
                    result.Add(node);
                }
            }
            return result;
        }

        #endregion
    }
}