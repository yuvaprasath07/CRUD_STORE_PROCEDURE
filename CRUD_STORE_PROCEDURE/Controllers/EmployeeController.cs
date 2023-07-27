using BusinessLayer;
using EntityDb;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_STORE_PROCEDURE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IBusinessLayre _businessLayre;
        public EmployeeController(IBusinessLayre businessLayre)
        {
            _businessLayre = businessLayre;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_businessLayre.GetAll());
        }

        [HttpGet("GetSptable")]

        public IActionResult GetSp()
        {
            return Ok(_businessLayre.getEmploye());
        }

        [HttpPost("AddEmployees")]
        public IActionResult PostSp(PostEmployee postDatas)
        {
            return Ok(_businessLayre.addEmployee(postDatas));
        }

        [HttpPut("UpdateEmployee")]
        public IActionResult updateSp(EmployeeModel updateemployee)
        {
            return Ok(_businessLayre.UpdateEmployee(updateemployee));
        }

        [HttpDelete("DeleteEmploye")]
        public IActionResult DeleteSp(int id)
        {
            return Ok(_businessLayre.deleteEmployee(id));
        }

    }
}
