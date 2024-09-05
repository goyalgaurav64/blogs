﻿using blog_backend.Entity;
using blog_backend.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace blog_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IRepository<Category> _repository;
        public CategoryController(IRepository<Category> repository) 
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllCategory()
        {
            var categoryList = await _repository.GetAll();
            return Ok(categoryList);
        }
    }
}
