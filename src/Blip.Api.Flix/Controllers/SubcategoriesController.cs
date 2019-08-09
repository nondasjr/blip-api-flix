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
    public class SubcategoriesController : Controller
    {
        private readonly SwitchContext _switchContext;
        public SubcategoriesController(SwitchContext switchContext)
        {
            _switchContext = switchContext;
        }
        // GET api/subcategories
        [HttpGet]
        public IEnumerable<Subcategory> Get()
        {
            return _switchContext.Subcategories.AsEnumerable();
        }


        [HttpGet("{id}")]
        public Subcategory Get(int id)
        {
            return _switchContext.Subcategories.FirstOrDefault(x => x.Id == id);
        }

        
        
    }
}
