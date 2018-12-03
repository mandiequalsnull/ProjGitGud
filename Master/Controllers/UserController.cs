using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using User.Models;

namespace User.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UserController: ControllerBase {
        private readonly UserContext _context;

        public UserController(UserContext context) {
            _context = context;

            if (_context.Users.Count() == 0) {
                // Create a new User if collection is empty,
                // which means you can't delete all Users.
                _context.Users.Add(new Models.User {
                    id = 123, username = "mandi", password = "123", isAdmin = true
                });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult < List < Models.User >> GetAll() {
            return _context.Users.ToList();
        }

        [HttpGet("{id}", Name = "GetUser")]
        public ActionResult < Models.User > GetById(long id) {
            var item = _context.Users.Find(id);
            if (item == null) {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Create(Models.User item) {
            _context.Users.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetUser", new {
                id = item.id
            }, item);
        }


    }
}