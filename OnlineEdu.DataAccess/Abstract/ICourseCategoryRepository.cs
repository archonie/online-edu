using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Abstract
{
	public interface ICourseCategoryRepository: IRepository<CourseCategory>
	{
		void ShowOnMainPage(int id);
		//void DontShowOnMainPage(int id);

	}
}
