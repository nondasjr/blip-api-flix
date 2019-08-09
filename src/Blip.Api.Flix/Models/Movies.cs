using System;
using Microsoft.EntityFrameworkCore;

namespace Blip.Api.Flix.Models
{
    public class Movie
    {
        /// <summary>
        /// Movie primary key
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Movie name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Movie sinopse description
        /// </summary>
        public string Sinopse { get; set; }
        /// <summary>
        /// Movie name on slug
        /// </summary>
        public string Slug { get; set; }
        /// <summary>
        /// Associated subcategory id
        /// </summary>
        public int SubcategoriesId { get; set; }
        /// <summary>
        /// Associated subcategory
        /// </summary>
        public virtual Subcategory Subcategories { get; set; }

    }
}
