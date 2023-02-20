using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_webapi.Models
{
     public class ServiceResponse<T>
     {
          public T? Data { get; set; }
          public string Message { get; set; } = string.Empty;
          public bool Success { get; set; } = true;
     }
}