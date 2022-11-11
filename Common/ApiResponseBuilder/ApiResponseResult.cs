using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.ApiResponseBuilder
{
    public class ApiResponseResult
    {
        public ApiResponseResult()
        {

        }



        public IActionResult ResultResponse(TEntityApiResponse result)
        {
            IActionResult response = null;
            switch (result.Status)
            {
                case "Success":
                    response = new OkObjectResult(result);
                    break;
                case "Failed":
                    response = new BadRequestObjectResult(result);
                    break;
                case "NotFound":
                    response = new NotFoundObjectResult(result);
                    break;
                case "Exist":
                    response = new BadRequestObjectResult(result);
                    break;
            }
            return response;
        }

        public IActionResult ResultDataResponse<t>(TEntityApiDataResponse<t> result)
        {
            IActionResult response = null;
            switch (result.Status)
            {
                case "Success":
                    response = new OkObjectResult(result);
                    break;
                case "Failed":
                    response = new BadRequestObjectResult(result);
                    break;
                case "NotFound":
                    response = new NotFoundObjectResult(result);
                    break;
                case "Exist":
                    response = new BadRequestObjectResult(result);
                    break;
            }
            return response;
        }
    }
}
