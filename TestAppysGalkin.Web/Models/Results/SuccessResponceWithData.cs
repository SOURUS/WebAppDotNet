using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestAppysGalkin.Web.Models.Results
{
    public class SuccessResponceWithData : JsonBaseResponse
    {
        public SuccessResponceWithData(object data) : base()
        {
            Data = data;
            Success = true;
        }
        public object Data { get; set; }
    }
}