using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace CoffeeMachine.API.Middlewares
{
    public class ErrorResponse
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.InternalServerError;

        public string Message { get; set; } = "An unexpected error occurred.";

        public string ToJsonString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
