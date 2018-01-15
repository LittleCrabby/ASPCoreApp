using System.Collections.Generic;
using System.Linq;
using ASPCoreApp.Core.Entities;
using ASPCoreApp.Core.Interfaces;
using ASPCoreApp.Core.SharedKernel;
using Microsoft.EntityFrameworkCore;

namespace ASPCoreApp.Infrastructure.Data
{
    public class PostRepository<T> : IRepository<Post>
    {
        private readonly AppDbContext _dbContext;

        public PostRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Post GetById(int id)
        {
            return _dbContext.Set<Post>().Include(p => p.Comments).SingleOrDefault(e => e.Id == id);
        }

        public List<Post> List()
        {
            return _dbContext.Set<Post>().Include(p => p.Comments).ToList();
        }

        public Post Add(Post entity)
        {
            _dbContext.Set<Post>().Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public void Delete(Post entity)
        {
            _dbContext.Set<Post>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Update(Post entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}