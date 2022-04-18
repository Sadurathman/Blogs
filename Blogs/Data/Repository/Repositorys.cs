using Blogs.Data;
using Blogs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogs.Repository
{
    public class Repositorys :IRepository
    {
        private AppDBContext _ctx;

        public Repositorys(AppDBContext ctx)
        {
            _ctx = ctx;
        }
        public void AddPost(Post post)
        {
            _ctx.Posts.Add(post);
        }

        public List<Post> GetAllPost()
        {
            return _ctx.Posts.ToList();
        }

        public Post GetPost(int Id)
        {
            return _ctx.Posts.FirstOrDefault(p => p.Id == Id);
        }

        public void RemovePost(int Id)
        {
            _ctx.Posts.Remove(GetPost(Id));
        }

        public void UpdatePost(Post post)
        {
            _ctx.Posts.Update(post);
        }

        public async Task<bool> SaveChangesAsync()
        {
            if (await _ctx.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }

    }
}
