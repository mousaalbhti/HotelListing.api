using HotelListing.api.Data;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelListing.api.Controllers;

[Route("api/[controller]")]
[ApiController]

public class HotelsController : ControllerBase

{
    private static List<Hotel> hotels = new List<Hotel>
    {
        new Hotel { Id =1, Name = "best hotel", Adress = "amman", Ratting = "5" },
        new Hotel { Id =2, Name = "best 2", Adress = "amman", Ratting = "4.5" }
    };

    // GET: api/<HotelController>
    [HttpGet]
    public  ActionResult <IEnumerable<Hotel>> Get()
    {
        return Ok(hotels);
    }

    // GET api/<HotelController>/5
    [HttpGet("{id}")]
    public ActionResult<Hotel> Get(int id)
    {
        var hotel = hotels.FirstOrDefault(h => h.Id == id);
        if (hotel == null)
        {
            return NotFound();
        }
       return Ok(hotel); 
    }

    // POST api/<HotelController>
    [HttpPost]
    public ActionResult<Hotel> Post([FromBody] Hotel NewHotel)
    {
        if (hotels.Any(h=>h.Id==NewHotel.Id))
        {
            return BadRequest("ID alredy exsist");
        }
        hotels.Add(NewHotel);
        return CreatedAtAction(nameof(Get), new { id = NewHotel.Id }, NewHotel);
    }

    // PUT api/<HotelController>/5
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] Hotel UpdatedHotel)
    {
        var ExistingHotel = hotels.FirstOrDefault(h => h.Id == id);
        if (ExistingHotel == null)
        {
            return NotFound();
        }
        ExistingHotel.Id = UpdatedHotel.Id;
        ExistingHotel.Name = UpdatedHotel.Name; 
        ExistingHotel.Adress = UpdatedHotel.Adress;
        ExistingHotel.Ratting = UpdatedHotel.Ratting;
        return NoContent();
    }

    // DELETE api/<HotelController>/5
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var hotel = hotels.FirstOrDefault(h => h.Id == id);
        if (hotel == null)
        {
            return NotFound();
        }
        hotels.Remove(hotel);
        return NoContent(); 
    }
}
