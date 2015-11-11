using MyFirstMvc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstMvc.Controllers
{
    public class StuController : Controller
    {

        ItcastSIMEntities db = new ItcastSIMEntities();
        public StuController()
        {
            db.Configuration.ValidateOnSaveEnabled = false;
        }
        public ActionResult Index()
        {
            List<Student> listStu = db.Students.Where(s => s.IsDel == false).ToList();
            IQueryable<Student> query = db.Students.Where(s => s.IsDel == false);
            //var s1 = from p in db.Students where p.IsDel == false select p;
            //ObjectQuery<Student> parents = s1 as ObjectQuery<Student>;
            string sql = query.ToString();
            return View(listStu);////将 listStu 对象 传给 视图 里的 Model 属性
        }

        public ActionResult Del(int id)
        {
            Models.Student stu = new Student() { Id = id };
            //db.Set<Models.Student>().Attach(stu);
            //db.Set<Models.Student>().Remove(stu);
            DbEntityEntry entry = db.Entry<Models.Student>(stu);
            entry.State = System.Data.EntityState.Deleted;

            int res = db.SaveChanges();
            if (res > 0)
            {
                return Content("<script>alert('删除成功~~！');window.location='/Stu/Index';</script>");
            }
            else
            {
                return Content("<script>alert('删除失败~~！');window.location='/Stu/Index';</script>");
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Student stu = db.Set<Models.Student>().Where(s => s.Id == id).FirstOrDefault();
            //查询出班级信息 做成下拉框
            //List<SelectListItem> classList = db.Classes.Where(c => c.CIsDel == false).ToList().Select(c => new SelectListItem() { Value = c.CID.ToString(), Text = c.CName, Selected = (c.CID == stu.CId) }).ToList();
            List<Models.Class> classList = (from c in db.Classes where c.CIsDel == false select c).ToList();
            ViewBag.classes = classList;
            return View(stu);
           
        }

        [HttpPost]
        public ActionResult Edit(Models.Student s)//模型绑定
        {
            DbEntityEntry entry = db.Entry<Models.Student>(s);
            entry.State = System.Data.EntityState.Unchanged;
            entry.Property("Name").IsModified = true;
            entry.Property("CId").IsModified = true;
            db.SaveChanges();
            //db.Database.lo
            return Redirect("/stu/index");
        }

        //-------------------------------- Razor 视图 --------------------------------
        public ActionResult RazorView()
        {
            ViewBag.CName = "aa";
            Models.Class model = new Models.Class() { CName = "adsf" };
            return View(model);
        }

        public ActionResult SonPage()
        {
            return View();
        }
    }
}
