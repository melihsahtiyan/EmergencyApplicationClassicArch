using Core.DataAccess;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos.Post;

namespace DataAccess.Abstract
{
    public interface IPostDal : IEntityRepository<Post>
    {
        List<PostDetailDto> GetPostDetails();
        List<PostDetailDto> GetPostDetailsByUserId(int userId);
        PostDetailDto GetPostDetailsByPostId(int postId);
    }
}
