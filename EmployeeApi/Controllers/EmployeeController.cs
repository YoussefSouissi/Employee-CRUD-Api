using EmployeeApi.Models;
using EmployeeApi.Models.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace EmployeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Employee>> GetAll()=>EmployeeService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployee(int id)
        {
            var employee =  EmployeeService.GetById(id);
            if(employee == null)
                return NotFound();
                return employee;
            
        }
        [HttpPost]
      public ActionResult AddEmployee(Employee employee)
        {
            EmployeeService.add(employee);
            return CreatedAtAction(nameof(AddEmployee), employee);

        }
        [HttpPut("{id}")]
        public ActionResult updateEmployee(int id , Employee employee)
        {
            if (id!=employee.Id)
                return BadRequest();
            var existingEmployee = EmployeeService.GetById(id);
            if (existingEmployee == null)
                return NotFound();
            EmployeeService.Update(employee);
            return NoContent();

        }
        [HttpDelete("{id}")]
        public ActionResult DeleteEmployee(int id)
        {
             var emp = EmployeeService.GetById(id);
            if (emp is null)
                return NotFound();
            EmployeeService.delete(id);
            return NoContent();
        }


    }
   
}
