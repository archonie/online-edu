﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Abstract
{
    public interface ICourseRepository : IRepository<Course>
    {
        void ShowOnMainPage(int id);
        List<Course> GetCoursesWithCategories();


    }
}
