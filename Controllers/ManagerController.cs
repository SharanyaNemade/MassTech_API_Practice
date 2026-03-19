using API_Practice.Data;
using API_Practice.Models;
using API_Practice.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace API_Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        ApplicationDbContext db;

        IMapper mapper;
        public ManagerController(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("AddManager" )]
        public async  Task<IActionResult> AddManager(ManagerDTO dto)
        {
            var m = new Manager()
                {
                    mname = dto.mname
                };
            await db.manager.AddAsync(m);
            await db.SaveChangesAsync();
            return Ok(new { message = "Add Success" });
        }


        [HttpGet]
        [Route("Fetch")]
        public IActionResult FetchManagers()
        {
            // Saving => DTO to Entity

            var data = db.manager.ToList();

            //var data = db.manager
            //    .Select(x=>new ManagerDTO
            //    {
            //        mid = x.mid,
            //        mname = x.mname
            //    }).ToList();

            var res = mapper.Map<List<ManagerDTO>>(data);
            return Ok(res);
        }
    }
}
