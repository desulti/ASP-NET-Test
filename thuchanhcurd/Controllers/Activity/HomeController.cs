using ESEIM.Models;
using FTU.Utils.HelperNet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using thuchanhcurd.Models;

using Microsoft.AspNetCore.Http;



namespace thuchanhcurd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EIMDBContext _context;

        public HomeController(EIMDBContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public object JTableCast([FromBody] ModelCast jTablePara)
        {
            try
            {
                // Way 1 using Where
                var data = _context.Activitys
               .Select(
                     x => new
                     {
                         x.ID,
                         x.ActivityCode,
                         x.Title,
                         x.Duration,
                         x.Unit,
                         x.Located,
                         x.Status,
                         x.Desc,
                         x.ShapeJson,
                         x.Group,
                         x.Type,
                         x.WorkflowCode,
                         x.CreatedBy,
                         x.CreatedTime,
                         x.UpdatedBy,
                         x.UpdatedTime,
                         x.DeletedBy,
                         x.DeletedTime,
                         x.IsDeleted,
                         x.NestedWF,
                         x.RoleDefault,
                         x.ListGroupData,
                       

                     });


                var count = data.Count();
                var jdata = JTableHelper.JObjectTable(data.ToList(), jTablePara.Draw, count, "ID", "ActivityCode", "Title", "Duration", "Unit", "Located", "Status", "Desc", "ShapeJson", "Group", "Type", "WorkflowCode", "CreatedBy", "CreatedTime", "UpdatedBy", "UpdatedTime", "DeletedBy", "DeletedTime", "IsDeleted", "NestedWF", "RoleDefault", "ListGroupData");
                return Json(jdata);
            }
            catch (Exception ex)
            {
                var jdata = JTableHelper.JObjectTable(new List<object>(), jTablePara.Draw, 0, "ID", "ActivityCode", "Title", "Duration", "Unit", "Located", "Status", "Desc", "ShapeJson", "Group", "Type", "WorkflowCode", "CreatedBy", "CreatedTime", "UpdatedBy", "UpdatedTime", "DeletedBy", "DeletedTime", "IsDeleted", "NestedWF", "RoleDefault", "ListGroupData");
                return Json(jdata);
            }
        }
        public class ModelCast
        {
            internal readonly int Draw;

            public int ID { get; set; }

            public string ActivityCode { get; set; }

            public string Title { get; set; }

            public decimal Duration { get; set; }

            public string Unit { get; set; }

            public string Located { get; set; }

            public string Status { get; set; }

            public string Desc { get; set; }

            public string ShapeJson { get; set; }

            public string Group { get; set; }

            public string Type { get; set; }

            public string WorkflowCode { get; set; }

            public string CreatedBy { get; set; }

            public DateTime? CreatedTime { get; set; }

            
            public string UpdatedBy { get; set; }

            public DateTime? UpdatedTime { get; set; }

            
            public string DeletedBy { get; set; }

            public DateTime? DeletedTime { get; set; }

            public bool IsDeleted { get; set; }

            public string NestedWF { get; set; }
            public string RoleDefault { get; set; }
            public string ListGroupData { get; set; }
        }
    }
}
