using blog_backend.Data;
using blog_backend.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace blog_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IRepository<Blog> _repository;
        public BlogController(IRepository<Blog> repository) 
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult> GetBlogsList()
        {
            var blogs = await _repository.GetAll();
            return Ok(blogs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetBlog([FromRoute] int id)
        {
            var blog = await _repository.GetById(id);
            if (blog == null)
            {
                return NotFound();
            }
            return Ok(blog);
        }

        [HttpPost]
        public async Task<ActionResult> AddBlog([FromBody] Blog blog)
        {
            await _repository.Add(blog);
            await _repository.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBlog([FromBody] Blog blogPost, [FromRoute] int id)
        {
            var blog = await _repository.GetById(id);
            if (blog == null)
            {
                return NotFound();
            }

            blog.Category = blogPost.Category;
            blog.Description = blogPost.Description;
            blog.Content = blogPost.Content;
            blog.Title  = blogPost.Title;
            blog.IsFeatured = blogPost.IsFeatured;
            blog.Image = blogPost.Image;

            _repository.Update(blog);
            await _repository.SaveChanges();
            return Ok();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBlog([FromRoute] int id, [FromBody] Blog blogPost)
        {
            var blog = await _repository.GetById(id);
            if (blog == null)
            {
                return NotFound();
            }
            _repository.Delete(id);
            await _repository.SaveChanges();
            return Ok();
        }
    }
}
