using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_Practice.Data;
using API_Practice.Models;
using API_Practice.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using AutoMapper;


namespace API_Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        ApplicationDbContext db;
        IMapper mapper;

        public EmpController(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("AddEmp")]
        public IActionResult AddEmp(EmpDTO dto)
         {
            //var e = new Emp()
            //{
            //    ename = dto.ename, 
            //    esalary = dto.esalary,
            //    mid = dto.mid
            //};


            var e = mapper.Map<Emp>(dto);


            db.emps.Add(e);
            db.SaveChanges();
            return Ok(new { message = "Successfully Added" });
        }


        [HttpGet]
        [Route("FetchEmp")]
        public IActionResult FetchEmp()
        {
            //  Fetching => Entity to DTO

            var data = db.emps.Include(x=> x.manager).ToList();

            //var data = db.emps.Include(x => x.manager)
            //    .Select(x => new EmpDTO2
            //    {
            //        eid = x.eid,
            //        ename = x.ename,
            //        esalary = x.esalary,
            //        mid = x.mid,
            //        mname = x.manager.mname != null? x.manager.mname:"No"
            //    }).ToList();

            var res = mapper.Map<List<EmpDTO2>>(data);

            return Ok(res);
        }
    }
}
