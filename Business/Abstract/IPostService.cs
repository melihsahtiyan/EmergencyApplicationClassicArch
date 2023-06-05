using Core.Utilities.Results;
using Entity.Concrete;
using Entity.Dtos.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPostService
    {
        IDataResult<List<Post>> GetAll();
        IDataResult<Post> GetById(int postId);
        IDataResult<List<PostDetailDto>> GetPostDetails();
        IDataResult<List<PostDetailDto>> GetPostDetailsByUserId(int userId);
        IDataResult<PostDetailDto> GetPostDetailsByPostId(int postId);
        IResult Add(PostForCreateDto post);
        IResult AddList(List<PostForCreateDto> posts);
        IResult Update(PostForCreateDto post);
        IResult Delete(Post post);
        IResult DeleteById(int postId);
        IResult DeleteList(List<Post> posts);
    }
}
