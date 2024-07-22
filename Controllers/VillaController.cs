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
        [HttpGet]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas(){
            return Ok(VillaStore.VillaList);
        }

         [HttpGet("{ID}")]
        public ActionResult<VillaDTO> GetVillas(int ID){
            if(ID == 0){
                return BadRequest();
            }
            var VillName = VillaStore.VillaList.FirstOrDefault(vo => vo.ID == ID);
            if(VillName == null){
                return NotFound("ID/Name does not exist");
            }
            return Ok(VillName);
        }

        [HttpPost]
        public ActionResult<VillaDTO> PostVilla(VillaDTO Villa){

            if(Villa == null){
                return BadRequest("Villa cant be NULL");
            }
            if(Villa.Name == ""){
                return BadRequest("Name cannot be NULL");
            }
            VillaStore.VillaList.Add(Villa);

            return Ok();


        }

        
    }
}