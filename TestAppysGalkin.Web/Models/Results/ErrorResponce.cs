using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestAppysGalkin.Web.Models.Results
{
    public class ErrorResponce : JsonBaseResponse
    {
        public ErrorResponce(string msg)
        {
            Success = false;
            Message = msg;
        }

        private ErrorResponce() { }
        public string Message { get; set; }
    }
}