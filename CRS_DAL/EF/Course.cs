//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRS_DAL.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Course
    {
        public string CourseID { get; set; }
        public string CourseCode { get; set; }
        public string CourseTitle { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> Fee { get; set; }
        public string Instructors { get; set; }
        public int NumberOfDays { get; set; }
    }
}
