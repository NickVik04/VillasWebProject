using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VillasWebProject.Models;
using VillasWebProject.Models.DTOs;

namespace VillasWebProject.Data
{
    public static class VillaStore
    {
        public static List<VillaDTO> VillaList = new List<VillaDTO>{
                new VillaDTO{ID = 1, Name = "Pool View"},
                new VillaDTO{ID = 2, Name = "Beach View"}
            };
    }
}