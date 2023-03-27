using AutoMapper;
using DzanNewsMVC.DataModel.Authors;
using DzanNewsMVC.DataModel.Categories;
using DzanNewsMVC.Models.Authors;
using DzanNewsMVC.Models.Categories;

namespace DzanNewsMVC.Models.Mapper
{
    public class DataModel2ViewModel:Profile
    {
        public DataModel2ViewModel()
        {
            //this.CreateMap<CategoryDM,CategoryViewModel>();
            this.CreateMap<DataModel.Categories.CategoryDM, CategoryViewModel>();
            this.CreateMap<InsertCategoryRequest, InsertCategoryViewModel>();

            this.CreateMap<AuthorDM,AuthorViewModel>();
            this.CreateMap<InsertCategoryRequest, InsertCategoryViewModel>();
        }
    }
}
