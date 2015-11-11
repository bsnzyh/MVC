using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace P02MVCAjax.Controllers
{
    public class StudentController : Controller
    {
        Models.ItcastSIMEntities db = new Models.ItcastSIMEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List(int id)
        {
            //List<Models.DTO.StudentDTO> list = db.Students.Where(s => s.IsDel == false).ToList().Select(s => s.ToDto()).ToList();
            //1.EF的查询方法，实际创建的是 某个实体类的代理类，代理类 继承于 该 实体类。
            Models.Student stu = db.Students.First();


            int pageIndex = id;
            int pageSize = 3;
            //2.1根据页码 获取分页数据(使用DTO学员实体类 内部不存在循环属性 --  关于使用DTO类的时候注意，类名不要和EF实体类一样)
            List<Models.DTO.StudentDTO> list = db.Students.OrderBy(s => s.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize)
                //将EF查出的 EF实体集合 转成 DTO实体集合，并返回
                .ToList().Select(s => s.ToDto()).ToList();

            //2.2获取总行数
            int rowCount = db.Students.Count();
            //2.3计算总页数
            int pageCount = Convert.ToInt32(Math.Ceiling((rowCount * 1.0) / pageSize));

            //2.4将数据 封装到 PagedDataModel 分页数据实体中
            Models.PagedDataModel<Models.DTO.StudentDTO> dataModel = new Models.PagedDataModel<Models.DTO.StudentDTO>()
            {
                PagedData = list,
                PageCount = pageCount,
                PageIndex = pageIndex,
                PageSize = pageSize,
                RowCount = rowCount
            };

            //2.5将分页数据实体 封装到 Json标准格式实体中
            Models.JsonModel jsonModel = new Models.JsonModel()
            {
                Data = dataModel,
                Msg = "成功~",
                Statu = "ok",
                BackUrl = ""
            };

            //重要：JavaScriptSerializer 无法识别 被序列化的 对象里 各种属性是否存在 循环依赖
            //【所以，我们不能使用 jss 去序列化 EF实体对象A ！】
            //因为 jss 会 循环 EF实体对象A 里的每个属性，想要根据此属性 生成对应的Json字符串，但是，EF实体A 的外键(导航)属性如果被访问，则会自动去数据库获取数据，而这个导航属性 对应的实体类B 中可能又包含指向实体A的类型，那么，EF又会去加载 A的数据，然后A里有包含B........陷入死循环...........

            //System.Web.Script.Serialization.JavaScriptSerializer jsS = new System.Web.Script.Serialization.JavaScriptSerializer();
            //string json = jsS.Serialize(jsonModel);

            //2.6生成 json格式数据，此Json方法默认只接收 Post请求，如果要接收 GEt请求，则需要加第二个参数
            return Json(jsonModel, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        /// <summary>
        /// 获取数据传递到修改页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ModifyPage(int id)
        {
            Models.Student model = db.Students.Where(s => s.Id == id).FirstOrDefault();
            List<Models.Class> listClass = db.Classes.ToList();
            SelectList list = new SelectList(listClass, "CID", "CName");
            ViewBag.classes = list.AsEnumerable();
            return View(model);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ModifyPage(Models.Student model)
        {
            //服务器端 验证（根据实体类属性的 验证特性来检查）
            if (!ModelState.IsValid)
            {
                return Content("数据有误~！请不要恶意禁用浏览器脚本~~~！");
            }
            try
            {
                DbEntityEntry entry = db.Entry<Models.Student>(model);
                entry.State = System.Data.EntityState.Unchanged;

                entry.Property("Name").IsModified = true;
                entry.Property("CId").IsModified = true;
                entry.Property("Gender").IsModified = true;

                db.SaveChanges();
                return Content("<script>alert('修改成功~');window.location='/Student/Index';</script>");
            }
            catch (Exception ex)
            {
                return Content("<script>alert('失败~~~~" + ex.Message + "');window.location='/Student/Index';</script>");
            }
        }

        public ActionResult ExitName()
        {
            string name = Request["Name"];
            if (name == "辉哥")
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
