﻿using CRS_DAL.Repository;
using nus.iss.crs.dm;
using nus.iss.crs.dm.Course;
using nus.iss.crs.dm.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.bl
{
    class CourseRegistrationManager
    {
        static UnitOfWork unitOfWork = new UnitOfWork();

        internal CourseRegistrationManager() { }
        internal CourseRegistrationManager(ISession session)
        {
            //only course admin can do  
            if (session.GetCurrentUser().GetRole() == null)
            {
                throw new Exception("No permisison");
            }
        }

        //how to find out the list of selected course?
        //public List<Course> GetSelectedCourseList()
        //{
        //    List<Course> courseList = new List<Course>();
        //    return courseList;
        //}

        //public bool RegisterCourse(CourseClass courseClass)
        //{
        //    //Registration(courseClass,)
        //    return false;
        //}

        //get employee list by HR
        public List<Participant> GetEmployeeListByCompanyID(string companyID) 
        {
            return unitOfWork.CourseRegistrationService.GetEmployeeListByCompanyID(companyID);
        }
        
        //Populate employee details by ID Number
        public Participant GetEmployeeByIDNumber(string idNumber)
        {
            return unitOfWork.CourseRegistrationService.GetEmployeeByIDNumber(idNumber);
        }

        //Create new employee
        public bool CreateEmployee(Participant participant)
        {
            return unitOfWork.CourseRegistrationService.CreateEmployee(participant);
        }

        //View course details


        public List<Registration> GetRegistrationList(CourseClass cls)
        {
            return null;
        }

        public List<Registration> GetRegistrationList(User user)
        {
            return null;
        }

        public List<Registration> GetRegistrationList(Company company)
        {
            return null;
        }


        /// <summary>
        /// Edit, Cancel
        /// </summary>
        /// <param name="registration"></param>
        /// <returns></returns>
        public bool EditRegistration(Registration registration)
        {
               
            return false;
        }

        public bool DeleteRegistration(Registration registration)
        {
            return false;
        }


        public Registration GetRegistration(string RegID)
        {
            return null;
        }


    }
}
