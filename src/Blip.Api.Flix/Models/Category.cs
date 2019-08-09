using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Blip.Api.Flix.Models
{
    public class Categorie
    {
        /// <summary>
        /// Category id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Category name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Category description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Category name slug
        /// </summary>
        public string Slug { get; set; }
        /// <summary>
        /// Collection associated subcategory
        /// </summary>
        public virtual ICollection<Subcategory> Subcategories { get; set; }


    }
}
