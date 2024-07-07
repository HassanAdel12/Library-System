using AutoMapper;
using library_system.Core.DTO;
using library_system.Core.Interfaces;
using library_system.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace library_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper mapper;


        public CategoryController(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }

        [HttpGet("{ID:int}")]
        public IActionResult GetByID(int ID)
        {
            Category category = unitOfWork.Categories.GetById(ID);
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                try
                {
                    return Ok(mapper.Map<CategoryDTO>(category));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }

            }
        }



        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(mapper.Map<IEnumerable<CategoryDTO>>(unitOfWork.Categories.GetAll()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }


        [HttpPost]
        public IActionResult Add(CategoryDTO categoryDTO)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    Category category = unitOfWork.Categories.Add(mapper.Map<Category>(categoryDTO));
                    unitOfWork.Complete();
                    return Ok();

                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }

            }
            else
            {
                return BadRequest(ModelState);
            }
        }


        [HttpPut("{ID:int}")]
        public IActionResult Update(CategoryDTO categoryDTO, int ID)
        {

            if (ModelState.IsValid)
            {

                Category oldCategory = unitOfWork.Categories.GetById(ID);
                if (oldCategory != null)
                {
                    try
                    {
                        categoryDTO.CategoryId = ID;
                        mapper.Map(categoryDTO, oldCategory);

                        Category category = unitOfWork.Categories.Update(oldCategory);
                        unitOfWork.Complete();

                        return Ok(category);


                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex);
                    }

                }
                else
                {
                    return NotFound();
                }

            }
            else
            {
                return BadRequest(ModelState);
            }
        }



        [HttpDelete("{ID:int}")]
        public IActionResult Delete(int ID)
        {

            Category category = unitOfWork.Categories.GetById(ID);
            if (category != null)
            {
                try
                {

                    unitOfWork.Categories.Delete(category);
                    unitOfWork.Complete();

                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }

            }
            else
            {
                return NotFound();
            }


        }


    }
}
