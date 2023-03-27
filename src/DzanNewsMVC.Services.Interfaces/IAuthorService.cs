using DzanNewsMVC.DataModel;
using DzanNewsMVC.DataModel.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DzanNewsMVC.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<CommandResponse<IEnumerable<AuthorDM>>> GetAuthors();
        Task<CommandResponse<AuthorDM>> GetAuthorById(int id);

        Task<CommandResponse<AuthorDM>> InsertAuthor(InsertAuthorRequest authorDM);
    }
}
