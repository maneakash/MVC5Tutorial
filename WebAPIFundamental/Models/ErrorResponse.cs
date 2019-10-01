using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIFundamental.Models
{
    public class ErrorResponse
    {
        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
    }
}