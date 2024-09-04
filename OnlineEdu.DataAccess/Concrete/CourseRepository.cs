using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.DataAccess.Repositories;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Concrete
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(OnlineEduContext context) : base(context)
        {
        }

        public List<Course> GetCoursesWithCategories()
        {
            return _context.Courses.Include(x => x.CourseCategory).ToList();
        }

        public void ShowOnMainPage(int id)
        {
            var value = _context.Find<Course>(id);
            value.IsShown = !value.IsShown;
            _context.SaveChanges();
        }
    }
}
