using Data.Infrastructure;
using Data.Repository;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Controllers
{
    public class StudentController : Controller
    {

        private IStudentService _StudentService;
        public StudentController()
        {
            var dbfactory = new DatabaseFactory();

            _StudentService = new StudentService(new StudentRepository(dbfactory), new UnitOfWork(dbfactory));
        }
        //
        // GET: /Student/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Student() {

            var list = _StudentService.Get().ToList();
            return Json(list,JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Save(Student student ) 
        {

            if (ModelState.IsValid)
            {
                if (student.ID>0)
                {
                    _StudentService.Update(student);
                }
                else
                {
                    _StudentService.Save(student);
                }
            }
            //_StudentService.Save(student);
            _StudentService.Commit();
            CommitOperation commmitOperation = CommitOperation.GetCommitOperation;
            commmitOperation.OperationId = student.ID;
            return Json(commmitOperation,JsonRequestBehavior.DenyGet);
        
        }

        public ActionResult Delete(int id) {

            Student student = _StudentService.GetById(id);
            _StudentService.Delete(student);
            _StudentService.Commit();
            CommitOperation commmitOperation = CommitOperation.GetCommitOperation;
            return Json(commmitOperation, JsonRequestBehavior.AllowGet);
        
        }
	}
}