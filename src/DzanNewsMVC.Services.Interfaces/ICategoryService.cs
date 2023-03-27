using DzanNewsMVC.DataModel;
using DzanNewsMVC.DataModel.Categories;


namespace DzanNewsMVC.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<CommandResponse<IEnumerable<CategoryDM>>> GetCategories();

        Task<CommandResponse<CategoryDM>> GetCategoryById(int id);

        Task<CommandResponse<CategoryDM>> InsertCategory(InsertCategoryRequest cvm);
    }
}