using DzanNewsMVC.DataModel.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DzanNewsMVC.DataModel
{
    public class CommandResponse
    {
        public bool Success 
        { get
            {
                bool isSuccess = String.IsNullOrEmpty(ErrorMessage);
                return isSuccess; 
            }
            set { Success = value; }
        }
        public string ErrorMessage { get; set; }

        
    }

    public class CommandResponse<T> : CommandResponse
    {
        public T Data { get; set; }
    }
}
