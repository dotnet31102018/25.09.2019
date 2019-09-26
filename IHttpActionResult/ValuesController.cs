using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class FoodController : ApiController
    {
        // just for demo
        private static List<Food> foods = new List<Food>();
        private static int counter = 0;
        static FoodController()
        {
            foods.Add(new Food() { Id = 1, Name = "Chips" });
            foods.Add(new Food() { Id = 2, Name = "Burger" });
            foods.Add(new Food() { Id = 3, Name = "Pizza" });
            counter = foods.Count;
        }

        /// <summary>
        /// Get all food items - GET main route
        /// </summary>
        /// <returns>IHttpActionResult</returns>
        [ResponseType(typeof(Food))]
        [HttpGet]
        public IHttpActionResult Get()
        {
            if (foods.Count == 0)
            {
                return NotFound();
            }
            return Ok(foods);
        }

        /// <summary>
        /// Get aspecific food item
        /// </summary>
        /// <returns>IHttpActionResult</returns>
        [ResponseType(typeof(Food))]
        [Route("api/food/{id}", Name = "GeById")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            Food food = foods.FirstOrDefault(f => f.Id == id);
            if (food == null)
            {
                return NotFound();
            }
            return Ok(food);
        }

        [ResponseType(typeof(void))]
        [HttpPut]
        public IHttpActionResult PutFood(int id, [FromBody] Food food)
        {
            if (food.Id == 0)
            {
                return BadRequest(ModelState);
            }

            if (foods.FirstOrDefault(f => f.Id == id) == null)
            {
                return NotFound();
            }
            else
            {
                // update
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Foods
        [ResponseType(typeof(Food))]
        public IHttpActionResult PostFood([FromBody] Food food)
        {
            // after POST return the URL of the 

            food.Id = ++counter;
            foods.Add(food);

            //  use - return CreatedAtRoute( ... );
            return CreatedAtRoute("GeById", new { id = food.Id }, food);
        }
    }
}
