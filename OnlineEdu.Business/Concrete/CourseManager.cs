using System;
using System.Collections.Generic;
using System.Linq;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Concrete
{
    public class CourseManager : GenericManager<Course>, ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseManager(IRepository<Course> _repository, ICourseRepository courseRepository) : base(_repository)
        {
            _courseRepository = courseRepository;
        }

        public List<Course> TGetCoursesWithCategories()
        {
            return _courseRepository.GetCoursesWithCategories();
        }

        public void TShowOnMainPage(int id)
        {
            _courseRepository.ShowOnMainPage(id);
        }
    }
}
