﻿using CRS_COMMON.Logs;
using nus.iss.crs.bl;
using nus.iss.crs.bl.Session;
using nus.iss.crs.dm;
using nus.iss.crs.dm.Course;
using nus.iss.crs.pl.AppCode.Filter;
using nus.iss.crs.pl.AppCode.FormAuthentication;
using nus.iss.crs.pl.AppCode.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace nus.iss.crs.pl.Controllers
{
    public class HomeController : BaseController
    {
        private static LogHelper _log = LogHelper.GetLogger(typeof(HomeController));

        public ActionResult Index()
        {
            //ISession session = SessionFactory.CreateSession();
            //LogingStrategy loginStrategy = new NonLoginStrategy();

            //session.Login(loginStrategy);

            //CourseManager manager = session.CreateCourseManager();
            //List<CourseCategory> categoryList = CourseManager.GetCourseCategoryList(DateTime.Now, DateTime.Now.AddMonths(5), true);

            return View();
        }

        public JsonResult GetCourseCategoryList(string searchText = "")
        {
            List<CourseCategory> categoryList = CourseManager.GetCourseCategoryList(DateTime.Now, DateTime.Now.AddMonths(5), true);
            //foreach (var category in categoryList)
            //{
            //    var courselist=category.CourseList;
            //    foreach (var course in courselist)
            //    {
            //        var courseClasses=course.CourseClasses;

                    
            //        foreach (var item in courseClasses)
            //        {
            //            if (_groupbyMonth.ContainsKey(item.StartMonth.ToString()))
            //            {
            //                item.DisplayStartDay = _groupbyMonth[item.StartMonth.ToString()];
            //            }
            //        }
            //    }
            //}

            return Json(new { Data = categoryList });
        }

        public ActionResult CourseDetail(string code)
        {
            var model = CourseManager.GetCourseByCode(code);
            return View(model);
        }

        [CRSAuthorize(Roles = "HR")]
        public ActionResult About()
        {
            _log.Debug("test about");
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [CRSAuthorize(Roles="Individual")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Logon(string message="")
        {
            ViewBag.Message = message;
            ViewBag.isLogon = SessionHelper.Current == null ? false : true;
            return View();
        }
        [HttpPost]
        public JsonResult PostLogon(string loginID,string password)
        {

            nus.iss.crs.dm.User loginUser = new nus.iss.crs.dm.User() {UserID="test",Password="1111",Email="", RoleName="HR" };
            loginUser.GetRole();
            SessionHelper.SetSession(loginUser);
            CRSFormsAuthentication<User>.SetAuthCookie(loginUser.UserID, loginUser, true);

            //ISession session = SessionFactory.CreateSession();
            //session.Login(new IDLoginStrategy(loginUser));

            //User validUser = session.GetCurrentUser();
            //validUser.GetRole();           
            

            return Json(new{Code=1});
        }


        public ActionResult Unauthorized()
        {
            return View();
        }
    }
}