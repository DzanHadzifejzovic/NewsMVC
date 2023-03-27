using DzanNewsMVC.DataModel;
using DzanNewsMVC.DataModel.Authors;
using DzanNewsMVC.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DzanNewsMVC.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IConfiguration _config;
        private readonly HttpClient _httpClientAuthor;

        public AuthorService(IConfiguration config)
        {
            _config = config;
            _httpClientAuthor = new HttpClient();
            _httpClientAuthor.BaseAddress = new Uri(_config.GetSection("ExternalServices").GetSection("NewsAPI").Value);
        }

        public async Task<CommandResponse<IEnumerable<AuthorDM>>> GetAuthors()
        {
            CommandResponse<IEnumerable<AuthorDM>> result = new CommandResponse<IEnumerable<AuthorDM>>();
            try
            {
                var response = await _httpClientAuthor.GetAsync("Author");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var loadedResponse = JsonConvert.DeserializeObject<CommandResponseDzanNewsAPI<IEnumerable<AuthorDM>>>(content);
                    if (result.Success)
                    {
                        result.Data = loadedResponse.Data;
                    }
                    else
                    {
                        result.ErrorMessage = loadedResponse.ErrorMessage;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public async Task<CommandResponse<AuthorDM>> GetAuthorById(int id)
        {
            CommandResponse<AuthorDM> result = new CommandResponse<AuthorDM>();
            try
            {
                string requestPath = $"Author/{id}";
                var response = await _httpClientAuthor.GetAsync(requestPath);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var loadedResponse = JsonConvert.DeserializeObject<CommandResponseDzanNewsAPI<AuthorDM>>(content);
                    if (result.Success)
                    {
                        result.Data = loadedResponse.Data;
                    }
                    else
                    {
                        result.ErrorMessage = loadedResponse.ErrorMessage;
                    }
                }
            }catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public async Task<CommandResponse<AuthorDM>> InsertAuthor(InsertAuthorRequest authorDM)
        {
            CommandResponse<AuthorDM> result = new CommandResponse<AuthorDM>();
            try
            {
                var json = JsonConvert.SerializeObject(authorDM);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClientAuthor.PostAsync("Author", data);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var loadedResponese = JsonConvert.DeserializeObject<CommandResponseDzanNewsAPI<AuthorDM>>(content);
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
