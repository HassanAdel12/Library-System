using AutoMapper;
using library_system.Core.DTO;
using library_system.Core.Interfaces;
using library_system.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace library_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper mapper;

        public BookController(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }



        [HttpGet("{ID:int}")]
        public IActionResult GetByID(int ID)
        {
            Book book = unitOfWork.Books.GetById(ID);
            if (book == null)
            {
                return NotFound();
            }
            else
            {
                try
                {
                    return Ok(mapper.Map<BookDTO>(book));
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
                return Ok(mapper.Map<IEnumerable<BookDTO>>(unitOfWork.Books.GetAll()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }



        [HttpPost]
        public IActionResult Add(BookDTO bookDTO)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    Book book = unitOfWork.Books.Add(mapper.Map<Book>(bookDTO));
                    unitOfWork.Complete();
                    return Ok(book);

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
        public IActionResult Update(BookDTO bookDTO, int ID)
        {

            if (ModelState.IsValid)
            {

                Book oldBook = unitOfWork.Books.GetById(ID);
                if (oldBook != null)
                {
                    try
                    {
                        bookDTO.BookId = ID;
                        mapper.Map(bookDTO, oldBook);

                        Book book = unitOfWork.Books.Update(oldBook);
                        unitOfWork.Complete();

                        return Ok(book);


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

            Book book = unitOfWork.Books.GetById(ID);
            if (book != null)
            {
                try
                {

                    unitOfWork.Books.Delete(book);
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
