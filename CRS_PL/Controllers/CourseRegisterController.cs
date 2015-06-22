﻿using CRS_COMMON.Logs;
using nus.iss.crs.bl;
using nus.iss.crs.dm;
using nus.iss.crs.dm.Course;
using nus.iss.crs.dm.Registration;
using nus.iss.crs.pl.AppCode.Session;
using nus.iss.crs.pl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace nus.iss.crs.pl.Controllers
{
    public class CourseRegisterController : BaseController
    {
        private static LogHelper _log = LogHelper.GetLogger(typeof(CourseRegisterController));
        // GET: CourseRegister
        public ActionResult IndividualRegister(string code,string message="")
        {
            if (!string.IsNullOrEmpty(message))
            {
                ViewBag.Message = message;
            }
            CRForm crform = GetModelForCourseRegister( "", true);
            var model = CourseManager.GetCourseByCode(code);
            crform.CourseTitle = model.CourseTitle;
            crform.CourseCode = model.Code;

            List<SelectItem> classlist = new List<SelectItem>();
            foreach (var item in model.CourseClasses)
            {
                classlist.Add(new SelectItem() { Value = item.ClassCode, Name = string.Format("{0}-{1}", item.StartDate.ToString("MMM dd, yyyy"), item.EndDate.ToString("MMM dd, yyyy")) });
            }
            ViewBag.ClassList = classlist;

            

            return View(crform);
        }

        [HttpPost]
        public ActionResult PostIndividualRegister(CRForm crform)
        {
            if (!this.ModelState.IsValid)
            {
                return RedirectToAction("IndividualRegister", new { code = crform.CourseCode, message = "something wrong!!!" });
            }
            string IDNumber = crform.IDNumber;
            if (SessionHelper.Current == null)
            {
                var user = UserManager.GetIndividualUserByIDNumber(IDNumber);
                if (user != null)
                {   //if exists ask him to login!
                    //string toPage = "?code="+code;
                    return Json(new { Code = -100, Message = "user exist,please login" });
                }
                else
                {
                    //auto register and login
                    user = UserManager.CreateIndIndividualUser(new dm.User() { LoginID = IDNumber });
                    user.RoleName = "User";
                    _log.Debug(string.Format("Your userid:{0},password:{1}", user.LoginID, user.Password));
                    SessionHelper.SetSession(user);
                }
            }
            CourseClass courseClass = ClassManager.GetCourseClassByCode(crform.ClassCode);
            Participant participant = null;
            participant = CourseRegistrationManager.GetIndividualParticipantByIDNumber(IDNumber);
            if (participant != null) {
                participant.EmploymentStatus = crform.EmploymentStatus;
                participant.CompanyName = crform.Company;
                participant.JobTitle = crform.JobTitle;
                participant.Department = crform.Department;
                participant.OrganizationSize = crform.OrganizationSize;
                participant.SalaryRange = crform.SalaryRage;

                participant.FullName = crform.FullName;
                participant.Gender = crform.Gender;
                participant.Nationality = crform.Nationality;
                participant.DOB = crform.DateOfBirth;
                participant.EMail = crform.Email;
                participant.ContactNumber = crform.ContactNumber;
                participant.DietaryRequirement = crform.DietaryRequirement;
                CourseRegistrationManager.UpdateIndividualParticipant(participant);
            }
            else
            {
                participant = CourseRegistrationManager.CreateParticipant(new Participant()
                {
                    IDNumber = IDNumber,
                    CompanyID = crform.CompanyID,
                    Salutation = crform.Salutation,
                    FullName = crform.FullName,
                    Gender = crform.Gender,
                    Nationality = crform.Nationality,
                    DOB = crform.DateOfBirth,
                    EMail = crform.Email,
                    ContactNumber = crform.ContactNumber,
                    DietaryRequirement = crform.DietaryRequirement,

                    EmploymentStatus = crform.EmploymentStatus,
                    CompanyName = crform.Company,
                    JobTitle = crform.JobTitle,
                    Department = crform.Department,
                    OrganizationSize = crform.OrganizationSize,
                    SalaryRange = crform.SalaryRage
                });
            }
            Registration registration = new Registration();

            registration.Sponsorship = crform.Sponsorship;
            registration.DietaryRequirement = crform.DietaryRequirement;
            registration.OrganizationSize = crform.OrganizationSize;

            registration.billingInfo.Address = crform.BillingAddress;
            registration.billingInfo.PersonName = crform.BillingPersonName;
            registration.billingInfo.Country = crform.BillingAddressCountry;
            registration.billingInfo.PostalCode = crform.BillingAddressPostalCode;  
            
            CourseRegistrationManager.CreateRegistration(courseClass, participant, registration);


            return Json(new { Code = 1, redirectUrl = Url.Action("ViewIndividualRegister", "CourseRegister") });
        }

        public ActionResult ViewIndividualRegister()
        {
            if (SessionHelper.Current == null)
                return RedirectToAction("Logon", "home");
            List<Registration> list = CourseRegistrationManager.GetRegistrationList(SessionHelper.Current);
            return View(list);
        }

        public ActionResult HRRegister(string code)
        {
            var model = CourseManager.GetCourseByCode(code);
            CRForm crform = new CRForm();
            crform.CourseTitle = model.CourseTitle;
            crform.CourseCode = model.Code;

            List<SelectItem> employlist = new List<SelectItem>();
            var employs = CourseRegistrationManager.GetEmployeeListByCompanyID(SessionHelper.Current.CompanyID);
            employlist.Add(new SelectItem() { Value = "-1", Name = "New Employee" });
            foreach (var item in employs)
            {
                employlist.Add(new SelectItem() { Value = item.IDNumber, Name = string.Format("{0}.{1}", item.Salutation, item.FullName) });
            }
            ViewBag.EmployeeList = employlist;

            List<SelectItem> classlist = new List<SelectItem>();
            foreach (var item in model.CourseClasses)
            {
                classlist.Add(new SelectItem() { Value = item.ClassCode, Name = string.Format("{0}-{1}", item.StartDate.ToString("MMM dd, yyyy"), item.EndDate.ToString("MMM dd, yyyy")) });
            }
            ViewBag.ClassList = classlist;

            Company company = UserManager.GetCompanyByID(SessionHelper.Current.CompanyID);
            if (company != null)
            {
                crform.CompanyID = company.CompanyID;
                crform.EmploymentStatus = "Regular Full Time";
                crform.Company = company.CompanyName;

                crform.OrganizationSize = company.OrganizationSize;
            }

            return View(crform);
        }

        [HttpPost]
        public ActionResult PostHRRegister(CRForm crform)
        {
            if (!this.ModelState.IsValid)
            {
                //log 
                return Content("wrong");
            }
            string IDNumber = crform.IDNumber;
            if (SessionHelper.Current == null)
            {
                //log
                return Content("wrong");
            }
            CourseClass courseClass = ClassManager.GetCourseClassByCode(crform.ClassCode);
            Participant participant = null;
            participant = CourseRegistrationManager.GetParticipantByHR(IDNumber,SessionHelper.Current.CompanyID);
            if (participant != null)
            {
                participant.EmploymentStatus = crform.EmploymentStatus;
                participant.CompanyName = crform.Company;
                participant.JobTitle = crform.JobTitle;
                participant.Department = crform.Department;
                participant.OrganizationSize = crform.OrganizationSize;
                participant.SalaryRange = crform.SalaryRage;

                participant.FullName = crform.FullName;
                participant.Gender = crform.Gender;
                participant.Nationality = crform.Nationality;
                participant.DOB = crform.DateOfBirth;
                participant.EMail = crform.Email;
                participant.ContactNumber = crform.ContactNumber;
                participant.DietaryRequirement = crform.DietaryRequirement;
                CourseRegistrationManager.UpdateIndividualParticipant(participant);
            }
            else
            {
                participant = CourseRegistrationManager.CreateParticipant(new Participant()
                {
                    IDNumber = IDNumber,
                    CompanyID = SessionHelper.Current.CompanyID,//crform.CompanyID,
                    Salutation = crform.Salutation,
                    FullName = crform.FullName,
                    Gender = crform.Gender,
                    Nationality = crform.Nationality,
                    DOB = crform.DateOfBirth,
                    EMail = crform.Email,
                    ContactNumber = crform.ContactNumber,
                    DietaryRequirement = crform.DietaryRequirement,

                    EmploymentStatus = crform.EmploymentStatus,
                    CompanyName = crform.Company,
                    JobTitle = crform.JobTitle,
                    Department = crform.Department,
                    OrganizationSize = crform.OrganizationSize,
                    SalaryRange = crform.SalaryRage
                });
            }
            Registration registration = new Registration();

            registration.Sponsorship = crform.Sponsorship;
            registration.DietaryRequirement = crform.DietaryRequirement;
            registration.OrganizationSize = crform.OrganizationSize;

            registration.billingInfo.Address = crform.BillingAddress;
            registration.billingInfo.PersonName = crform.BillingPersonName;
            registration.billingInfo.Country = crform.BillingAddressCountry;
            registration.billingInfo.PostalCode = crform.BillingAddressPostalCode;

            CourseRegistrationManager.CreateRegistration(courseClass, participant, registration);


            return Json(new { Code = 1, redirectUrl = Url.Action("ViewHRRegister", "CourseRegister") });
        }

        public ActionResult RenderCourseRegister(string courseCode,string idNumber)
        {
            CRForm crform = GetModelForCourseRegister(idNumber, false);

            var model = CourseManager.GetCourseByCode(courseCode);
            crform.CourseTitle = model.CourseTitle;
            crform.CourseCode = model.Code;
            List<SelectItem> classlist = new List<SelectItem>();
            foreach (var item in model.CourseClasses)
            {
                classlist.Add(new SelectItem() { Value = item.ClassCode, Name = string.Format("{0}-{1}", item.StartDate.ToString("MMM dd, yyyy"), item.EndDate.ToString("MMM dd, yyyy")) });
            }
            ViewBag.ClassList = classlist;

            return PartialView("~/views/courseregister/_courseregister.cshtml", crform);
        }

        public ActionResult ViewHRRegister()
        {
            if (SessionHelper.Current == null)
                return RedirectToAction("Logon", "home");
            List<Registration> list = CourseRegistrationManager.GetRegistrationList(new Company() { CompanyID = SessionHelper.Current.CompanyID });
            return View(list);
        }

        public ActionResult ViewCompanyEmployee()
        {
            if (SessionHelper.Current == null)
            {
                return RedirectToAction("Logon", "home");
            }
            List<Participant> list = CourseRegistrationManager.GetEmployeeListByCompanyID(SessionHelper.Current.CompanyID);
            return View(list);
        }

        private CRForm GetModelForCourseRegister(string idnumber,bool isIndividual=false)
        {
            CRForm crform = new CRForm();
            
            Participant participant=null;
            Registration registration = null;
            if (SessionHelper.Current != null)
            {
                if (isIndividual)
                {
                    participant = CourseRegistrationManager.GetIndividualParticipantByIDNumber(SessionHelper.Current.LoginID);
                    if(participant!=null)
                        registration = CourseRegistrationManager.GetLastIndividualRegistrationByParticipantID(participant.ParticipantID);
                }
                else
                {
                    participant = CourseRegistrationManager.GetParticipantByHR(idnumber, SessionHelper.Current.CompanyID);
                    if (participant != null)
                        registration = CourseRegistrationManager.GetLastRegistrationByHR(participant.ParticipantID,SessionHelper.Current.CompanyID);
                }
            }

            if (participant != null)
            {
                crform.Salutation = participant.Salutation;
                crform.FullName = participant.FullName;
                crform.Gender = participant.Gender;
                crform.Nationality = participant.Nationality;
                crform.DateOfBirth = participant.DOB;
                crform.Email = participant.EMail;
                crform.ContactNumber = participant.ContactNumber;
                crform.DietaryRequirement = participant.DietaryRequirement;

                crform.EmploymentStatus = participant.EmploymentStatus;
                crform.Company = participant.CompanyName;
                crform.JobTitle = participant.JobTitle;
                crform.Department = participant.Department;
                crform.OrganizationSize = participant.OrganizationSize;
                crform.SalaryRage = participant.SalaryRange;
            }
            
            if (registration != null)
            {
                crform.Sponsorship = registration.Sponsorship;
                crform.DietaryRequirement = registration.DietaryRequirement;
                crform.OrganizationSize = registration.OrganizationSize;
                crform.BillingAddress = registration.billingInfo.Address;
                crform.BillingPersonName = registration.billingInfo.PersonName;
                crform.BillingAddressCountry = registration.billingInfo.Country;
                crform.BillingAddressPostalCode = registration.billingInfo.PostalCode;
            }
            return crform;
        }
    }
}