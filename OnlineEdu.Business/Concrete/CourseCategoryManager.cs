using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Concrete
{
	public class CourseCategoryManager : GenericManager<CourseCategory>, ICourseCategoryService
	{
		private readonly ICourseCategoryRepository _courseCategoryRepository;
		public CourseCategoryManager(IRepository<CourseCategory> _repository, ICourseCategoryRepository courseCategoryRepository) : base(_repository)
		{
			_courseCategoryRepository = courseCategoryRepository;
		}



		public void TShowOnMainPage(int id)
		{
			_courseCategoryRepository.ShowOnMainPage(id);
		}
	}
}
