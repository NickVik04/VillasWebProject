using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VillasWebProject.Data;
using VillasWebProject.Models;
using VillasWebProject.Models.DTOs;

namespace VillasWebProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VillaController : ControllerBase
    {

        private readonly ApplicationDbContext _villaService;
        public VillaController(ApplicationDbContext dbContext){
            _villaService = dbContext;
        }

        [HttpGet]
        public IActionResult GetVillas()
        {
            return Ok(_villaService.VillaDetails.ToList());
        }

        [HttpGet("{ID}")]
        public ActionResult<VillaDTO> GetVillas(int ID)
        {
            if (ID == 0)
            {
                return BadRequest();
            }
            var VillName = _villaService.VillaDetails.FirstOrDefault(vo => vo.ID == ID);
            if (VillName == null)
            {
                return NotFound("ID/Name does not exist");
            }
            return Ok(VillName);
        }

        [HttpPost]
        public ActionResult<VillaDTO> PostVilla(Villa Villa)
        {

            if (Villa == null)
            {
                return BadRequest("Villa cant be NULL");
            }
            if (Villa.Name == "")
            {
                return BadRequest("Name cannot be NULL");
            }
            if (_villaService.VillaDetails.ToList().Count == 0)
            {
                Villa.ID = 1;
            }
            else
            {

                Villa.ID = _villaService.VillaDetails.OrderByDescending(Vo => Vo.ID).FirstOrDefault().ID + 1;
            }
            _villaService.VillaDetails.Add(Villa);
            _villaService.SaveChanges();
            return Ok();
        } 

        [HttpDelete("{ID}")]
        public IActionResult DeleteVilla(int ID)
        {

            if (ID == 0)
            {
                return BadRequest();
            }

            var villa = _villaService.VillaDetails.FirstOrDefault(u => u.ID == ID);
            if (villa == null)
            {
                return NotFound("Villa Not Found");
            }
            _villaService.VillaDetails.Remove(villa);
            return NoContent();
        }

        [HttpPut]
        public IActionResult PutVilla(int ID, [FromBody] VillaDTO villa){

            if (ID == 0 || villa == null)
            {
                return BadRequest();
            }

            var existingVilla = _villaService.VillaDetails.FirstOrDefault(vo => vo.ID == ID);

            if (existingVilla == null){
                return BadRequest();
            }

            existingVilla.Name = villa.Name;
            existingVilla.occupancy = villa.occupancy;
            existingVilla.sqft = villa.sqft;

            return NoContent();
        }


    }
}
