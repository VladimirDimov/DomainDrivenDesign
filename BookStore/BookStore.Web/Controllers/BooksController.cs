using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Application.Features.Books.Queries.Details;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookStore.Web.Controllers
{
    public class BooksController : ApiController
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<BooksController> _logger;

        [HttpGet]
        [Route("Details")]
        public ActionResult Details([FromQuery] BookDetailsQuery queryModel)
        {
            var result = this.Mediator.Send(queryModel);

            return this.Ok(result);
        }
    }
}
