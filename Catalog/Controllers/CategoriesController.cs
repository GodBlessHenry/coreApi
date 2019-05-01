using AutoMapper;
using Catalog.Contract;
using Catalog.Entity;
using Catalog.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public CategoriesController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryDto>> Get()
        {
            var items = _uow.GetRepository<Category>().GetAll();

            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(items));
        }

        [HttpGet("{id}")]
        public ActionResult<CategoryDto> Get(Guid id)
        {
            var item = _uow.GetRepository<Category>().Get(id);

            return Ok(_mapper.Map<CategoryDto>(item));
        }

        [HttpPost]
        public ActionResult<CategoryDto> Post([FromBody] CategoryDto item)
        {
            //// TODO: Move this into the automapper
            //if (item.Id == null || item.Id == Guid.Empty)
            //    item.Id = Guid.NewGuid();
            _uow.GetRepository<Category>().Add(_mapper.Map<Category>(item));

            return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
        }
    }
}
