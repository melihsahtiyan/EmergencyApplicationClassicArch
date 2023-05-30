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
                          join userProfile in Context.UserProfiles on post.Id equals userProfile.UserId
                          join category in Context.Categories on post.CategoryId equals category.Id
                          select new PostDetailDto
                          {
                              Id = post.Id,
                              FirstName = user.FirstName,
                              LastName = user.LastName,
                              IdentityNumber = user.IdentityNumber,
                              CategoryName = category.CategoryName,
                              Title = post.Title,
                              Description = post.Description,
                              Date = post.Date,
                              Latitude = post.Latitude,
                              Longitude = post.Longitude,
                              Altitude = post.Altitude,
                              BloodType = userProfile.BloodType,
                              Gender = userProfile.Gender,
                              Age = post.Date.Year - user.BirthDate.Year,
                              Allergies = (from userAllergy in Context.UserAllergies
                                           join allergy in Context.Allergies on userAllergy.AllergyId
                                               equals allergy.Id
                                           where userAllergy.UserId == post.UserId
                                           select allergy.Name).ToArray(),
                              Diseases = (from userDisease in Context.UserOngoingDiseases
                                          join ongoingDisease in Context.OngoingDiseases on
                                              userDisease.OngoingDiseaseId equals ongoingDisease.Id
                                          where userDisease.UserId == post.UserId
                                          select ongoingDisease.Name).ToArray()

                          }).ToList();
            return result;
        }

        public List<PostDetailDto> GetPostDetailsByUserId(int userId)
        {
            var result = (from post in Context.Posts
                          join user in Context.Users on post.UserId equals user.Id
                          join userProfile in Context.UserProfiles on post.Id equals userProfile.UserId
                          join category in Context.Categories on post.CategoryId equals category.Id
                          where post.UserId == userId
                          select new PostDetailDto()
                          {
                              Id = post.Id,
                              FirstName = user.FirstName,
                              LastName = user.LastName,
                              IdentityNumber = user.IdentityNumber,
                              CategoryName = category.CategoryName,
                              Title = post.Title,
                              Description = post.Description,
                              Date = post.Date,
                              Latitude = post.Latitude,
                              Longitude = post.Longitude,
                              Altitude = post.Altitude,
                              BloodType = userProfile.BloodType,
                              Gender = userProfile.Gender,
                              Age = post.Date.Year - user.BirthDate.Year,
                              Allergies = (from userAllergy in Context.UserAllergies
                                           join allergy in Context.Allergies on userAllergy.AllergyId
                                               equals allergy.Id
                                           where userAllergy.UserId == post.UserId
                                           select allergy.Name).ToArray(),
                              Diseases = (from userDisease in Context.UserOngoingDiseases
                                          join ongoingDisease in Context.OngoingDiseases on
                                              userDisease.OngoingDiseaseId equals ongoingDisease.Id
                                          where userDisease.UserId == post.UserId
                                          select ongoingDisease.Name).ToArray()
                          }).ToList();

            return result;
        }
    }
}
