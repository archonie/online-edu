using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.DataAccess.Repositories;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Concrete
{
	public class CourseCategoryRepository : GenericRepository<CourseCategory>, ICourseCategoryRepository
	{
		public CourseCategoryRepository(OnlineEduContext _context) : base(_context)
		{
		}

		//public void DontShowOnMainPage(int id)
		//{
		//	var value = _context.Courses.Find(id);
		//	value.IsShown = false;
		//	_context.SaveChanges();
		//}

		public void ShowOnMainPage(int id)
		{
			var value = _context.CourseCategories.Find(id);
			value.IsShown = !value.IsShown;
			_context.SaveChanges();
		}
	}
}
