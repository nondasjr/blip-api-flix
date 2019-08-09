using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Blip.Api.Flix.Models
{
    public class Subcategory
    {
        /// <summary>
        /// Subcategory primary key
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Subcategory name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Subcategory description 
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Subcategory name on slug
        /// </summary>
        public string Slug { get; set; }
        /// <summary>
        /// Categori id associated 
        /// </summary>
        public int CategoryId { get; set; }
        /// <summary>
        /// Categori associated
        /// </summary>
        public virtual Categorie Category { get; set; }
        /// <summary>
        /// Collection associated movies
        /// </summary>
        public virtual ICollection<Movie> Movies { get; set; }

    }
}
