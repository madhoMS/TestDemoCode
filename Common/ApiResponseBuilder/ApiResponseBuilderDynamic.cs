using System;
using System.Collections.Generic;
using System.Text;

namespace Common.ApiResponseBuilder
{
    public class ApiResponseBuilderDynamic
    {
        public ApiResponseBuilderDynamic()
        {
        }
        public TEntityApiDataResponse<T> ApiResponse<T>(int Status, string Message, T TempData)
        {
            var response = new TEntityApiDataResponse<T>();

            switch (Status)
            {
                case (int)EnumApiResponse.Success:
                    response.Data = TempData;
                    response.Status = "Success";
                    response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                    response.Message = Message;
                    break;
                case (int)EnumApiResponse.NotFound:
                    response.Data = TempData;
                    response.Status = "NotFound";
                    response.StatusCode = (int)System.Net.HttpStatusCode.NotFound;
                    response.Message = Message;
                    break;
                case (int)EnumApiResponse.Failed:
                    response.Data = TempData;
                    response.Status = "Failed";
                    response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                    response.Message = Message;
                    break;
                case (int)EnumApiResponse.Exist:
                    response.Data = TempData;
                    response.Status = "Exist";
                    response.StatusCode = (int)System.Net.HttpStatusCode.Found;
                    response.Message = Message;
                    break;
            }

            return response;
        }

        public TEntityApiResponse ApiResponse(int Status, string Message)
        {
            var response = new TEntityApiResponse();

            switch (Status)
            {
                case (int)EnumApiResponse.Success:
                    response.Status = "Success";
                    response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                    response.Message = Message;
                    break;
                case (int)EnumApiResponse.NotFound:
                    response.Status = "NotFound";
                    response.StatusCode = (int)System.Net.HttpStatusCode.NotFound;
                    response.Message = Message;
                    break;
                case (int)EnumApiResponse.Failed:
                    response.Status = "Failed";
                    response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                    response.Message = Message;
                    break;
                case (int)EnumApiResponse.Exist:
                    response.Status = "Exist";
                    response.StatusCode = (int)System.Net.HttpStatusCode.Found;
                    response.Message = Message;
                    break;
            }

            return response;
        }
    }


}
