using AutoMapper;
using DzanNewsMVC.DataModel;
using DzanNewsMVC.DataModel.Categories;
using DzanNewsMVC.Models.Categories;
using DzanNewsMVC.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DzanNewsMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            /*
            CommandResponse<IEnumerable<CategoryDM>> categoryResponse = await _categoryService.GetCategories();
            if (categoryResponse.Success != true)
            {
                return NotFound();
            }

            var categories = _mapper.Map<IEnumerable<CategoryViewModel>>(categoryResponse.Data);

            return View(categories);
            */
            var categoriesDM = await _categoryService.GetCategories();

            var categories = _mapper.Map<IEnumerable<CategoryViewModel>>(categoriesDM.Data);

            return View(categories);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var categoryDM = await _categoryService.GetCategoryById(id);

            if(!categoryDM.Success || categoryDM.Data == null)
            {
                return NotFound();
            }
            var categoryVM = _mapper.Map<CategoryViewModel>(categoryDM.Data);

            return View(categoryVM);
        }
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(InsertCategoryViewModel newCategory)
        {
            if (ModelState.IsValid)
            {
                var category = _mapper.Map<InsertCategoryRequest>(newCategory);

                var result = await _categoryService.InsertCategory(category);
                return RedirectToAction("Detail",new {id=result.Data.Id});
            }
            return View(newCategory);
           
        }
    }
}
