using BlogManagement.Models;

namespace BlogManagement.Services
{

    public interface IBlobService
    {
        Task<List<Blog>> GetAllBlogs();
        Task<Blog> GetBlogDetails(int id);
        Task<int> CreateBlog(Blog blog);
        Task DeleteBlog(int id);    
    }
    public class BlobService : IBlobService
    {  
        private readonly ApplicationDbContext _context;

        public BlobService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Blog>> GetAllBlogs()
        {
           /* return null;*/
            return await _context.ToListAsync();
        }

        public async Task<Blog> GetBlogDetails(int id)
        {
            /* return null;*/
            return await _context.blogs.Find(blog => blog.id == this.id);
        }

        public async Task<int> CreateBlog(Blog blogPost)
        {
            int id = _context.blogs.Add(blogPost);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<bool> UpdateBlog(Blog blog)
        {
            int id = _context.blogs.FirstOrDefault(blog);
            if (id==null)
            {
                return false;
            }
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task DeleteBlog(int id)
        {
            var blogPost = await _context.blogs.FindAsync(Blog => Blog.id == this.id);
            if (blogPost != null)
            {
                _context.Blog.Remove(blogPost);
                await _context.SaveChangesAsync();
            }
        }
    }
}
