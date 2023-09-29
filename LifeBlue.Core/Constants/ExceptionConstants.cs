using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LifeBlue.Core.Constants
{
    public static class ExceptionConstants
    {
        public const string ContentType = "application/json";
        public const string ErrorMessage = "An error occurred.";
        public const string AllowOriginHeader = "Access-Control-Allow-Origin";
        public const string AllowOriginHeaderValue = "*";
        public const int ErrorStatusCode = (int) HttpStatusCode.InternalServerError;
        public const string UnauthorizedMessage = "Unauthorized User";
    }
}
