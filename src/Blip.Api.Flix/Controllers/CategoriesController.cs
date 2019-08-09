using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Blip.Api.Flix.Data.Context;
using Blip.Api.Flix.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SlugGenerator;

namespace Blip.Api.Flix.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly SwitchContext _switchContext;
        public CategoriesController(SwitchContext switchContext)
        {
            _switchContext = switchContext;
        }
        /// <summary>
        /// Method responsible for searching categories list
        /// </summary>
        /// <param name="context"></param>
        /// <returns>[{
        ///             "id": 1,
        ///             "name": "Ação",
        ///             "description": "Filmes de ação",
        ///             "slug": "acao",
        ///             "subcategories": null
        ///           }]</returns>
        [HttpGet]
        public IEnumerable<Categorie> Get()
        {
            return _switchContext.Categories.AsEnumerable();
        }

        /// <summary>
        /// Method responsible for fetching data from a video
        /// </summary>
        /// <param name="context">category format on slug</param>
        /// <returns>{
        ///           "id": 1,
        ///           "name": "Ação",
        ///           "description": "Filmes de ação",
        ///           "slug": "acao",
        ///           "subcategories": null
        ///           }</returns>
        [HttpGet("{category}")]
        public Categorie Get(string category)
        {
            var slug = category.GenerateSlug();
            return _switchContext.Categories.FirstOrDefault(c => c.Slug == slug);
        }
        /// <summary>
        /// Method responsible for fetching data from a video
        /// </summary>
        /// <param name="context">category-slug/subcategories format on slug</param>
        /// <returns>{
        ///           "id": 1,
        ///           "name": "Ação",
        ///           "description": "Filmes de ação",
        ///           "slug": "acao",
        ///           "subcategories": null
        ///           }</returns>
        [HttpGet("{category}/subcategories")]
        public IEnumerable<Subcategory> GetSubcategoryByCategory(string category)
        {
            var slug = category.GenerateSlug();
            return _switchContext.Subcategories
                                .Where(s =>
                                    s.Category.Slug == slug
                                ).AsEnumerable();
        }
        /// <summary>
        /// Method responsible for fetching data from a video
        /// </summary>
        /// <param name="context">category-slug/subcategories/subcategory_slug format on slug</param>
        /// <returns>
        /// [{
        ///   "id": 1,
        ///   "name": "Artes Marciais",
        ///   "description": "Esta categoria reúne filmes sobre Artes marciais.",
        ///   "slug": "artes-marciais",
        ///   "categoryId": 1,
        ///   "category": null,
        ///   "movies": null
        ///      }]</returns>
        ///
        [HttpGet("{category}/subcategories/{subcategory}")]
        public IEnumerable<Subcategory> GetSubcategoryById(string category, string subcategory)
        {

            var slug = subcategory.GenerateSlug();
            var slugCategory = category.GenerateSlug();

            var _subcategory = _switchContext.Subcategories
                                    .Where( s =>
                                        s.Category.Slug == slugCategory
                                        && s.Slug.Contains( slug)
                                    ).AsEnumerable();

            return _subcategory;
        }
        /// <summary>
        /// Method responsible for fetching data from a video
        /// </summary>
        /// <param name="context">category-slug/subcategories/subcategory_slug/movies format on slug</param>
        /// <returns>
        /// [{
        /// "id": 1,
        /// "name": "Artes Marciais",
        /// "sinopse": "filme artes marciais.",
        /// "slug": "artes-marciais",
        /// "subcategoriesId": 1,
        /// "subcategories": null
        ///    }]</returns>
        [HttpGet("{category}/subcategories/{subcategory}/movies")]
        public IEnumerable<Movie> GetMovisBySubcatgory(string category, string subcategory)
        {

            var slugSubcategory = Regex.Replace(subcategory, @"\-+", " ").GenerateSlug();
            var slugCategory = Regex.Replace(category, @"\-+", " ").GenerateSlug();

            var moveis = _switchContext.Movies
                            .Where(m =>
                                m.Subcategories.Slug == slugSubcategory
                                && m.Subcategories.Category.Slug == slugCategory
                            ).AsEnumerable();

            return moveis;
        }
    }
}
