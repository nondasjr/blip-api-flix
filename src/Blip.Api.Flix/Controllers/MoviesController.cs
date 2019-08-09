using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blip.Api.Flix.Data.Context;
using Blip.Api.Flix.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blip.Api.Flix.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private readonly SwitchContext _switchContext;
        public MoviesController(SwitchContext switchContext)
        {
            _switchContext = switchContext;
        }
        /// <summary>
        /// Method responsible for searching videos list
        /// </summary>
        /// <param name="context"></param>
        /// <returns>[{
        ///           "id": 1,
        ///           "name": "Artes Marciais",
        ///           "sinopse": "filme artes marciais.",
        ///           "slug": "artes-marciais",
        ///           "subcategoriesId": 1,
        ///           "subcategories": null
        ///           }]</returns>
        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return _switchContext.Movies.AsEnumerable();
        }

        /// <summary>
        /// Method responsible for fetching data from a video
        /// </summary>
        /// <param name="context">movie format on slug</param>
        /// <returns>{
        ///           "id": 1,
        ///           "name": "Artes Marciais",
        ///           "sinopse": "filme artes marciais.",
        ///           "slug": "artes-marciais",
        ///           "subcategoriesId": 1,
        ///           "subcategories": null
        ///           }</returns>
        [HttpGet("{movie}")]
        public Movie Get(string movie)
        {
            return _switchContext.Movies.FirstOrDefault(x => x.Slug == movie);
        }

        
    }
}
