using FileOrganizerHelper;
using ReportApi.AttributeFilter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ReportApi.Controllers
{
    [InputValidatorAttribute]
    public class ReportController : ApiController
    {
        ReportDecorator reportDecorator;
        public ReportController()
        {
            reportDecorator = new ReportDecorator();
        }

        // GET api/values
        public string Get()
        {
            return reportDecorator.GetAllReportCount();
        }

        // GET api/values/5
        public string Get(int id)
        {
            return reportDecorator.GetReportCount(id.ToString());
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
