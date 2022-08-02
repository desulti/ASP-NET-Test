using ESEIM.Models;
using ESEIM.Utils;
using FTU.Utils.HelperNet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ESEIM.Models;
using ESEIM.Utils;
using FTU.Utils.HelperNet;
using III.Domain.Enums;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


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
                int intBeginFor = (jTablePara.CurrentPage - 1) * jTablePara.Length;

                var query = from a in _context.Activitys                            
                            select new
                            {
                                a.ID,
                                a.ActivityCode,
                                a.Title,
                                a.Duration,
                                a.Unit,
                                a.Located,
                                a.Status,
                                a.Desc,
                                a.ShapeJson,
                                a.Group,
                                a.Type,
                                a.WorkflowCode,
                                a.CreatedBy,
                                a.CreatedTime,
                                a.UpdatedBy,
                                a.UpdatedTime,
                                a.DeletedBy,
                                a.DeletedTime,
                                a.IsDeleted,
                                a.NestedWF,
                                a.RoleDefault,
                                a.ListGroupData,
                            };
                var count = query.Count();
                var data = query.OrderUsingSortExpression(jTablePara.QueryOrderBy).Skip(intBeginFor).Take(jTablePara.Length).AsNoTracking().ToList();
                var jdata = JTableHelper.JObjectTable(data.ToList(), jTablePara.Draw, count, "ActivityCode", "Duration", "Unit", "Located", "Title",  "Status", "Desc", "ShapeJson", "Group", "Type", "WorkflowCode", "CreatedBy", "CreatedTime", "UpdatedBy", "UpdatedTime", "DeletedBy", "DeletedTime", "IsDeleted", "NestedWF", "RoleDefault", "ListGroupData");
                return Json(jdata);
            }
            catch (Exception ex)
            {
                var jdata = JTableHelper.JObjectTable(new List<object>(), jTablePara.Draw, 0, "ActivityCode", "Duration", "Unit", "Located", "Title", "Status", "Desc", "ShapeJson", "Group", "Type", "WorkflowCode", "CreatedBy", "CreatedTime", "UpdatedBy", "UpdatedTime", "DeletedBy", "DeletedTime", "IsDeleted", "NestedWF", "RoleDefault", "ListGroupData");
                return Json(jdata);
            }
        }
        public class ModelActivity : JTableModel
        {
          
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
