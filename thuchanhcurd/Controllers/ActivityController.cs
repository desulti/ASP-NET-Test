using ESEIM.Models;
using ESEIM.Utils;
using FTU.Utils.HelperNet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace thuchanhcurd.Controllers
{
    public class ActivityController : Controller
    {
        private readonly ILogger<ActivityController> _logger;
        private readonly EIMDBContext _context;
        public ActivityController(EIMDBContext context, ILogger<ActivityController> logger)
        {
            _context = context;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public object JtableActivity([FromBody] ModelActivity jTablePara)
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
                         x.Status,
                         x.Group,
                         x.Type,
                         x.WorkflowCode,
                     });


                var count = data.Count();
                var jdata = JTableHelper.JObjectTable(data.ToList(), jTablePara.Draw, count, "ID", "ActivityCode", "Title",  "Status",  "Group", "Type", "WorkflowCode");
                return Json(jdata);
            }
            catch (Exception ex)
            {
                var jdata = JTableHelper.JObjectTable(new List<object>(), jTablePara.Draw, 0, "ID", "ActivityCode", "Title", "Status",  "Group", "Type", "WorkflowCode");
                return Json(jdata);
            }
        }
        public class ModelActivity : JTableModel
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
