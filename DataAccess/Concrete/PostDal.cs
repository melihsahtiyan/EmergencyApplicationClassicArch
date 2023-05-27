using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos.Post;

namespace DataAccess.Concrete
{
    public class PostDal : EfEntityRepositoryBase<Post, BaseDbContext>, IPostDal
    {
        public PostDal(BaseDbContext context) : base(context) { }
        public List<PostDetailDto> GetPostDetails()
        {
            var result = (from post in Context.Posts
                         join user in Context.Users on post.UserId equals user.Id
                         join category in Context.Categories on post.CategoryId equals category.Id
                         select new PostDetailDto
                         {
                             Id = post.Id,
                             FirstName = user.FirstName,
                             LastName = user.LastName,
                             Email = user.Email,
                             IdentityNumber = user.IdentityNumber,
                             CategoryName = category.CategoryName,
                             Title = post.Title,
                             Description = post.Description,
                             Date = post.Date,
                             Latitude = post.Latitude,
                             Longitude = post.Longitude,
                             Altitude = post.Altitude
                         }).ToList();
            return result;
        }

        public List<PostDetailDto> GetPostDetailsByUserId(int userId)
        {
            var result = (from post in Context.Posts
                join user in Context.Users on post.UserId equals user.Id
                join category in Context.Categories on post.CategoryId equals category.Id
                where post.UserId == userId
                select new PostDetailDto()
                {
                    Id = post.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    IdentityNumber = user.IdentityNumber,
                    CategoryName = category.CategoryName,
                    Title = post.Title,
                    Description = post.Description,
                    Date = post.Date,
                    Latitude = post.Latitude,
                    Longitude = post.Longitude,
                    Altitude = post.Altitude
                }).ToList();

            return result;
        }
    }
}
