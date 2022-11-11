using System;
using System.Collections.Generic;
using System.Text;

namespace Common.ApiResponseBuilder
{
    public partial class TEntityApiResponse
    {
        public int StatusCode { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
    }

    public partial class TEntityApiDataResponse<T> : TEntityApiResponse
    {
        public T Data { get; set; }
    }

    public enum EnumApiResponse
    {
        NotFound = 0,
        Success = 1,
        Exist = 2,
        Failed = 3
    }

}
