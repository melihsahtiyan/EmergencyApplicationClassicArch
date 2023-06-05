using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Dtos.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PostManager : IPostService
    {
        IPostDal _postDal;

        public PostManager(IPostDal postDal)
        {
            _postDal = postDal;
        }

        public IDataResult<List<PostDetailDto>> GetPostDetailsByUserId(int userId)
        {
            var result = _postDal.GetPostDetailsByUserId(userId);
            return new SuccessDataResult<List<PostDetailDto>>(result, Messages.PostsListed);
        }

        public IDataResult<PostDetailDto> GetPostDetailsByPostId(int postId)
        {
            var result = _postDal.GetPostDetailsByPostId(postId);
            return new SuccessDataResult<PostDetailDto>(result, Messages.PostsListed);
        }

        public IResult Add(PostForCreateDto post)
        {
            var postToAdd = new Post
            {
                CategoryId = post.CategoryId,
                UserId = post.UserId,
                Description = post.Description,
                Date = post.Date,
                Latitude = post.Latitude,
                Longitude = post.Longitude,
                Altitude = post.Altitude,
                Title = post.Title
            };

            _postDal.Add(postToAdd);
            return new SuccessResult(Messages.PostAdded);
        }

        public IResult AddList(List<PostForCreateDto> posts)
        {
            foreach (var post in posts)
            {
                var postToAdd = new Post
                {
                    CategoryId = post.CategoryId,
                    UserId = post.UserId,
                    Description = post.Description,
                    Date = post.Date,
                    Latitude = post.Latitude,
                    Longitude = post.Longitude,
                    Altitude = post.Altitude,
                    Title = post.Title
                };
                _postDal.Add(postToAdd);
            }
            return new SuccessResult(Messages.PostAdded);
        }

        public IResult Delete(Post post)
        {
            _postDal.Delete(post);
            return new SuccessResult(Messages.PostDeleted);
        }

        public IResult DeleteById(int postId)
        {
            var postToCheck = _postDal.Get(p => p.Id == postId);
            if (postToCheck == null)
            {
                return new ErrorResult(Messages.PostNotFound);
            }
            _postDal.Delete(postToCheck);
            return new SuccessResult(Messages.PostDeleted);
        }

        public IResult DeleteList(List<Post> posts)
        {
            foreach (var post in posts)
            {
                _postDal.Delete(post);
            }
            return new SuccessResult(Messages.PostDeleted);
        }

        public IDataResult<List<Post>> GetAll()
        {
            var result = _postDal.GetAll();
            return new SuccessDataResult<List<Post>>(result, Messages.PostsListed);
        }

        public IDataResult<Post> GetById(int postId)
        {
            return new SuccessDataResult<Post>(_postDal.Get(p => p.Id == postId), Messages.PostListed);
        }

        public IDataResult<List<PostDetailDto>> GetPostDetails()
        {
            var result = _postDal.GetPostDetails();
            return new SuccessDataResult<List<PostDetailDto>>(result, Messages.PostsListed);
        }

        public IResult Update(PostForCreateDto post)
        {
            var postToUpdate = new Post
            {
                Id = post.Id,
                CategoryId = post.CategoryId,
                UserId = post.UserId,
                Description = post.Description,
                Date = post.Date,
                Latitude = post.Latitude,
                Longitude = post.Longitude,
                Altitude = post.Altitude,
                Title = post.Title
            };

            _postDal.Update(postToUpdate);
            return new SuccessResult(Messages.PostUpdated);
        }
    }
}
