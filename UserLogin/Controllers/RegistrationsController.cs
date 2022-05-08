using UserLogin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UserLogin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationsController : ControllerBase
    {
        private readonly RegContext _db;
        public RegistrationsController(RegContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<Registration> Get()
        {
            var data = _db.Registration.ToList();
            return data;
        }
        [HttpPost]
        [Route("create")]
        public IActionResult Create(Registration User)
        {
            try
            {
                _db.Registration.Add(User);
                _db.SaveChanges();
                return Ok("Data Added Successfully");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status404NotFound, "Failed to Add data");
            }
            return Ok(User);
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update(Registration User)
        {
            try
            {

                _db.Registration.Update(User);
                _db.SaveChanges();
                return Ok("Data Updated Successfully");

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status404NotFound, "Data Not Matched");
            }

        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            try
            {
                var data = _db.Registration.FirstOrDefault(e => e.UID == id);
                _db.Registration.Remove(data);
                _db.SaveChanges();
                return Ok("Data Deleted Successfully");
            }
           
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status404NotFound, "ID Not Matched");
            }

        }

    }
}