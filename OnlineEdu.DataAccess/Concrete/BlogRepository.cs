using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.DataAccess.Repositories;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Concrete
{
	public class BlogRepository : GenericRepository<Blog>, IBlogRepository
	{
        public BlogRepository(OnlineEduContext context) : base(context)
        {
        }

        public List<Blog> GetBlogsWithCategories()
		{
			return _context.Blogs.Include(x => x.BlogCategory).ToList();
		}
	}
}
