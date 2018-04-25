using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Notifications;
using Microsoft.AspNetCore.Mvc;
using MyDocumentManageNetCore.Domain.Controllers;
using MyDocumentManageNetCore.Domain.Entitys;

namespace MyDocumentManageNetCore.Web.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : MyDocumentManageControllerBase
    {
        private readonly INotificationPublisher _notificationPublisher;
        private readonly IRepository<TB_ReagentInfo, Int64> repository;

        public ValuesController(INotificationPublisher notificationPublisher,IRepository<TB_ReagentInfo,Int64> _repository)
        {
            _notificationPublisher = notificationPublisher;
            repository = _repository;
        }
        //public IHttpActionResult
        public JsonResult Index()
        {
            var result= repository.GetAll().OrderBy(a => a.ID).ToList();
            return Json(result);
            //return Redirect("/swagger");
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
