using AutoMapper;
using DzanNewsMVC.DataModel;
using DzanNewsMVC.DataModel.Authors;
using DzanNewsMVC.Models.Authors;
using DzanNewsMVC.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DzanNewsMVC.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public AuthorController(IAuthorService authorService,IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            CommandResponse<IEnumerable<AuthorDM>> resultDM = await _authorService.GetAuthors();

            var result =  _mapper.Map<IEnumerable<AuthorViewModel>>(resultDM.Data);

            return View(result);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var authorDM = await _authorService.GetAuthorById(id);

            if (!authorDM.Success || authorDM.Data == null)
            {
                return NotFound();
            }
            var authorVM = _mapper.Map<AuthorViewModel>(authorDM.Data);

            return View(authorVM);
        }
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(InsertAuthorViewModel newAuthor)
        {
            if (ModelState.IsValid)
            {
                var author = _mapper.Map<InsertAuthorRequest>(newAuthor);

                var result = await _authorService.InsertAuthor(author);
                return RedirectToAction("Detail", new { id = result.Data.Id });
            }
            return View(newAuthor);

        }
    }
}
