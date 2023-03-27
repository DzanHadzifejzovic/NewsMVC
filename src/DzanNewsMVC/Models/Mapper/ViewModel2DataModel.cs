using AutoMapper;
using DzanNewsMVC.DataModel.Authors;
using DzanNewsMVC.DataModel.Categories;
using DzanNewsMVC.Models.Authors;
using DzanNewsMVC.Models.Categories;

namespace DzanNewsMVC.Models.Mapper
{
    public class ViewModel2DataModel:Profile
    {
        public ViewModel2DataModel()
        {
            this.CreateMap<InsertCategoryViewModel, InsertCategoryRequest>();
            this.CreateMap<InsertAuthorViewModel, InsertAuthorRequest>();

        }
    }
}
