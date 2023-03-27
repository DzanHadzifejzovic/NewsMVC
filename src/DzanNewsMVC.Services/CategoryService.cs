using DzanNewsMVC.DataModel;
using DzanNewsMVC.DataModel.Categories;
using DzanNewsMVC.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text;

namespace DzanNewsMVC.Services
{
    public class CategoryService: ICategoryService
    {
        private readonly HttpClient _categoryService;
        private readonly IConfiguration _config;
        public CategoryService(IConfiguration config)
        {
            _config = config;
            _categoryService = new HttpClient();
            _categoryService.BaseAddress = new Uri(_config.GetSection("ExternalServices").GetSection("NewsAPI").Value);
        }

        public async Task<CommandResponse<IEnumerable<CategoryDM>>> GetCategories()
        {
             CommandResponse<IEnumerable<CategoryDM>> result = new CommandResponse<IEnumerable<CategoryDM>>();
             try
             {
                 var response = await _categoryService.GetAsync("Category");

                 if (response.IsSuccessStatusCode)
                 {
                     var content = await response.Content.ReadAsStringAsync();
                     var loadedResponese = JsonConvert.DeserializeObject<CommandResponseDzanNewsAPI<IEnumerable<CategoryDM>>>(content);
                     if(result.Success)
                     {
                         result.Data = loadedResponese.Data;
                     }
                     else
                     {
                        result.ErrorMessage=loadedResponese.ErrorMessage;
                     }
                 }
                 else
                 {
                     result.ErrorMessage = "Service error";
                 }
             }catch (Exception ex)
             {
                 result.Success = false;
                 result.ErrorMessage = ex.Message;
             }
             return result;
        }

        public async Task<CommandResponse<CategoryDM>> GetCategoryById(int id)
        {
            CommandResponse<CategoryDM> result = new CommandResponse<CategoryDM>();
            try
            {
                string requestPath = $"Category/{id}";
                var response = await _categoryService.GetAsync(requestPath);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var loadedResponese = JsonConvert.DeserializeObject<CommandResponseDzanNewsAPI<CategoryDM>>(content);
                    if (result.Success)
                    {
                        result.Data = loadedResponese.Data;
                    }
                    else
                    {
                        result.ErrorMessage = loadedResponese.ErrorMessage;
                    }
                }
                else
                {
                    result.ErrorMessage = "Service error";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public async Task<CommandResponse<CategoryDM>> InsertCategory(InsertCategoryRequest category)
        {
            CommandResponse<CategoryDM> result = new CommandResponse<CategoryDM>();
            try
            { 
                var json = JsonConvert.SerializeObject(category);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _categoryService.PostAsync("Category", data);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var loadedResponese = JsonConvert.DeserializeObject<CommandResponseDzanNewsAPI<CategoryDM>>(content);
                    if (result.Success)
                    {
                        result.Data = loadedResponese.Data;
                    }
                    else
                    {
                        result.ErrorMessage = loadedResponese.ErrorMessage;
                    }
                }
                else
                {
                    result.ErrorMessage = "Service error";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}