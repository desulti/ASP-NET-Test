using ESEIM.Models;
using ESEIM.Utils;
using FTU.Utils.HelperNet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using thuchanhcurd.Models;

namespace thuchanhcurd.Controllers
{
    public class CompanyRuleController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EIMDBContext _context;

        public CompanyRuleController(EIMDBContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }


        [HttpPost]
        public object JTable([FromBody] CompanyJTableCustom jTablePara)
        {
            try {
                // Way 1 using Where
                var data = _context.CompanyRuleItems.Where(x => x.Flag == true
                && (string.IsNullOrEmpty(jTablePara.Item) || x.Item.Contains(jTablePara.Item))
                && (string.IsNullOrEmpty(jTablePara.Description) || x.Description == jTablePara.Description)).Select(
                        x => new
                        {
                            x.Id,
                            x.ItemCode,
                            x.Item,
                            x.Status,
                            x.Description,
                            x.Flag,
                            x.Note
                        });
                // Way 2 use SQL like LINQ syntax
                var data2 = from a in _context.CompanyRuleItems
                            where a.Flag == true
                            && (string.IsNullOrEmpty(jTablePara.Item) || a.Item.Contains(jTablePara.Item)
                            && (string.IsNullOrEmpty(jTablePara.Description) || a.Description == jTablePara.Description))

                            select new
                            {
                                a.Id,
                                a.ItemCode,
                                a.Item,
                                a.Description,
                                a.Flag,
                                a.Note
                            };
                // End
                var count = data.Count();
                var jdata = JTableHelper.JObjectTable(data.ToList(), jTablePara.Draw, count, "Id", "ItemCode", "Item", "Description", "Note", "Status", " Flag");
                return Json(jdata);
            }
            catch (Exception ex) {
                var jdata = JTableHelper.JObjectTable(new List<object>(), jTablePara.Draw, 0, "Id", "ItemCode", "Item", "Description", "Note", "Status", " Flag");
                return Json(jdata);
            }
        }
        // Create
        [HttpPost]
        public JsonResult Insert([FromBody] CompanyRuleItem obj)
        {
            var msg = new JMessage { Error = false, Title = "" };
            try {
                var checkExist = _context.CompanyRuleItems.FirstOrDefault(x => x.Id.Equals(obj.Id));
                if (checkExist == null) {
                    obj.CreateTime = DateTime.Now;
                    //obj.CreateBy = ESEIM.AppContext.UserName;
                    obj.Flag = true;

                    _context.CompanyRuleItems.Add(obj);
                    _context.SaveChanges();
                    msg.Object = obj.Id;
                    msg.Title = string.Format("Thành công");
                }
                else {
                    msg.Error = true;
                    msg.Title = string.Format("Tồn tại");
                }
            }
            catch {
                msg.Error = true;
                msg.Title = string.Format("Lỗi");
            }
            return Json(msg);
        }

        // Update
        [HttpPost]
        public object Update([FromBody] CompanyRuleItem obj)
        {
            var msg = new JMessage();
            try {
                var item = _context.CompanyRuleItems.FirstOrDefault(x => x.Id.Equals(obj.Id));
                if (item != null) {
                    item.UpdateBy = User.Identity.Name;
                    item.UpdateTime = DateTime.Now.Date;
                    item.Item = obj.Item;
                    item.ItemCode = obj.ItemCode;
                    item.Status = obj.Status;
                    item.Note = obj.Note;

                    _context.CompanyRuleItems.Update(item);
                    _context.SaveChanges();

                    msg.Error = false;
                    msg.Title = String.Format("Đã lưu thay đổi"); //"Đã lưu thay đổi";
                }
                else {
                    msg.Error = true;
                    msg.Title = String.Format("Có lỗi xảy ra!"); //"Có lỗi xảy ra!";
                }

                return msg;
            }
            catch {
                msg.Error = true;
                msg.Title = String.Format("Có lỗi xảy ra!"); //"Có lỗi xảy ra!";
                return msg;
            }
        }

        // Remove
        [HttpPost]
        public object Delete(int Id)
        {
            var msg = new JMessage { Error = true };
            try {
                var data = _context.CompanyRuleItems.FirstOrDefault(x => x.Id == Id);

                _context.CompanyRuleItems.Remove(data);
                _context.SaveChanges();
                msg.Error = false;
                msg.Title = String.Format("thành công");
                return Json(msg);


            }
            catch (Exception ex) {
                msg.Error = true;
                msg.Title = "Không tìm thấy dịch vụ. Vui lòng làm mới lại trang";//Không tìm thấy dịch vụ. Vui lòng làm mới lại trang
                return Json(msg);
            }
        }

        // Read
        public JsonResult GetItem(int id)
        {
            var msg = new JMessage() { Error = false, Title = "" };
            try {
                var obj = _context.CompanyRuleItems.FirstOrDefault(x => x.Id.Equals(id));
                if (obj != null) {
                    msg.Object = new CompanyRuleItem
                    {
                        Id = obj.Id,
                        ItemCode = obj.ItemCode,
                        Item = obj.Item,
                        Status = obj.Status,
                        Description = obj.Description,
                        Note = obj.Note,

                    };
                }
                else {
                    msg.Error = true;
                    //msg.Title = "Không tìm thấy thông tin ";
                    msg.Title = "Không tìm thấy thông tin";
                }
            }
            catch (Exception ex) {
                msg.Error = true;
                msg.Object = ex;
                msg.Title = "";
            }
            return Json(msg);
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
    }
}
