using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIOne.Models;

namespace WebAPIOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        static List<Employee> list = new List<Employee>()
       {
           new Employee{EmployeeId=1,EName="Sam",Salary=20000},
           new Employee{EmployeeId=2,EName="Niti",Salary=30000},
           new Employee{EmployeeId=3,EName="Ritu",Salary=25000},
       };
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return list;
        }
        [HttpGet("{id}")]
        public ActionResult<Employee> Get(int id)
        {
          Employee emp = list.SingleOrDefault(x => x.EmployeeId == id);
            if(emp == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(emp);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult<Employee> Delete(int id)
        {
            Employee emp = list.SingleOrDefault(x => x.EmployeeId == id);
            if (emp == null)
            {
                return NotFound();
            }
            else
            {
                list.Remove(emp);
                return NoContent();
            }
        }
        [HttpPost]
        public ActionResult<Employee> Post(Employee newEmp)
        {
            list.Add(newEmp);
            return CreatedAtAction(nameof(Get),newEmp);
        }
        [HttpPut("{id}")]
        public ActionResult<Employee> Put(int id,Employee UpEmp)
        {
            Employee ExtEmp = list.SingleOrDefault(x => x.EmployeeId == id);
            if (ExtEmp == null)
            {
                return NotFound();
            }
            else
            {
                ExtEmp.EName = UpEmp.EName;

                ExtEmp.Salary = UpEmp.Salary;
                return NoContent();
            }
        }

    }

}
