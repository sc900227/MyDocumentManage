using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Notifications;
using Microsoft.AspNetCore.Mvc;
using MyDocumentManageNetCore.Domain.Controllers;

namespace MyDocumentManageNetCore.Web.Controllers
{
    //[Route("api/[controller]")]
    public class ValuesController : MyDocumentManageControllerBase
    {
        private readonly INotificationPublisher _notificationPublisher;

        public ValuesController(INotificationPublisher notificationPublisher)
        {
            _notificationPublisher = notificationPublisher;
        }
        //// GET api/values
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
