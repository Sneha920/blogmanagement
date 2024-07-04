using BlogManagement.Models;
using Microsoft.AspNetCore.Mvc;
using BlogManagement.Services;

namespace BlogManagement.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : Controller
    {
        public readonly BlobService _blobService;
        public  BlogController(BlobService blobService)
        {
            _blobService = blobService;
        }  

        [HttpPost]
        [Route("createBlog")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<int> Create([FromBody] Blog blog)
        {
            int id =  await _blobService.CreateBlog(blog);
            return id;
        }


        [HttpGet]
        [Route("GetAllBlogs")]
        public async Task<ActionResult<List<Blog>>> GetAllBlogs()
        {
            var blogPosts = await _blobService.GetAllBlogs();
            return Ok(blogPosts);
        }

      
        [HttpGet]
        [Route("getBlogdetails/{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Blog>> GetBlogDetails(int id)
        {
            var blog = await _blobService.GetBlogDetails(id);
            if (blog == null)
            {
                return NotFound();
            }
            return Ok(blog);
        }

        [HttpPost("{id}")]
        [Route("updateBlogDetails")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateBlog(int id,[FromBody] Blog blog)
        {
                if (await _blobService.GetBlogDetails(id) == null)
                {
                    return NotFound();
                }
            else
            {
               await _blobService.UpdateBlog(blog);
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        [Route("deleteBlog")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteBlogPost(int id)
        {
            var blogPost = await _blobService.GetBlogDetails(id);
            if (blogPost == null)
            {
                return NotFound();
            }

            await _blobService.DeleteBlog(id);
            return NoContent();
        }
    }

}
