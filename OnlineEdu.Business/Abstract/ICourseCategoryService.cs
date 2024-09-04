using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Abstract
{
	public interface ICourseCategoryService : IGenericService<CourseCategory>
	{
		void TShowOnMainPage(int id);
		//void TDontShowOnMainPage(int id); 
	}
}
