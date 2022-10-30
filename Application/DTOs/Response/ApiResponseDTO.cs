using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Response
{
    public class ApiResponseDTO<T>
    {
        private T _value;
        public int Status { get; set; }
        public string? Message { get; set; }

        public T Data { get { return _value; } set { _value = value; } }
        public static implicit operator T(ApiResponseDTO<T> value)
        {
            return value.Data;
        }
        public static implicit operator ApiResponseDTO<T>(T value)
        {
            return new ApiResponseDTO<T> { Data = value };
        }
    }
}
