 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Abstract
{
	public interface IBlogRepository : IRepository<Blog>
	{
		List<Blog> GetBlogsWithCategories();

	}
}
