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
        IResult Add(PostForCreateDto post);
        IResult Update(PostForCreateDto post);
        IResult Delete(PostForCreateDto post);
    }
}
