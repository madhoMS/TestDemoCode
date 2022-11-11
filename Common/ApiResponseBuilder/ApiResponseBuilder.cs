
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.ApiResponseBuilder
{
    public class ApiResponseBuilder : IDisposable
    {
        public TEntityApiResponse Response { get; set; }

        public ApiResponseBuilder()
        {
        }

        public ApiResponseBuilder(int status, string message)
        {
            Response = apiResponse(status, message);
        }

        public TEntityApiResponse apiResponse(int Status, string Message)
        {
            var response = new TEntityApiResponse();
            switch (Status)
            {
                case (int)EnumApiResponse.NotFound:
                    response.Status = "NotFound";
                    response.StatusCode = (int)System.Net.HttpStatusCode.NotFound;
                    response.Message = Message;
                    break;
                case (int)EnumApiResponse.Success:
                    response.Status = "Success";
                    response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                    response.Message = Message;
                    break;
                case (int)EnumApiResponse.Failed:
                    response.Status = "Failed";
                    response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                    response.Message = Message;
                    break;
            }

            return response;
        }


        #region Disponse
        private bool isDisposed = false;
        ~ApiResponseBuilder()
        {
            Dispose(false);
        }
        protected void Dispose(bool disposing)
        {
            if (isDisposed)
            {
                return;
            }

            if (!isDisposed)
            {
                if (disposing)
                {
                    Response = null;
                }
            }

            // Code to dispose the un-managed resources of the class
            isDisposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }


}
