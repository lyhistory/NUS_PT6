﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nus.iss.crs.pl.Admin
{
    public enum AdminAction
    { 
        Save,
        Edit,
        Delete
    }

    public enum CourseAdminAction
    {
        Save = AdminAction.Save,
        Edit = AdminAction.Edit,
        Delete = AdminAction.Delete
    }
}