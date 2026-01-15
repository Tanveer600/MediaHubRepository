using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Application
{
    public class ResponseDataModel
    {
        public bool IsSuccess { get; set; } 
        public string? Message { get; set; } 
        public object? Data { get; set; } 
        public object? ErrorMessage { get; set; } 
    }
}
