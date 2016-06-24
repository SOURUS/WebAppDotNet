using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestAppysGalkin.Web.Models.Results
{
    public class SuccessResponce : JsonBaseResponse
    {
        public SuccessResponce(string text) : base()
        {
            Text = text;
            Success = true;
        }
        public string Text { get; set; }
    }
}