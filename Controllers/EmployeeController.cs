using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace coredemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
     public class EmployeeController : ControllerBase
    {
    
    private  static List<Employee>  ListOfEmployee=new List<Employee>{
        new Employee{  EmpID=1,Address="test as",DepartMentID=1,EmpName="mani"}, 
        new Employee{EmpID=2,Address="test as",DepartMentID=1,EmpName="viji"},
         new Employee  {EmpID=3,Address="test as",DepartMentID=1,EmpName="nitesh"},
         new Employee {EmpID=4,Address="test as",DepartMentID=1,EmpName="niteshmaniviji"}};
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            return ListOfEmployee;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Employee> Get(int id)
        {
             return ListOfEmployee.Where(emplohe=>emplohe.EmpID==id).FirstOrDefault();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Employee value)
        {
            value.EmpID =ListOfEmployee.Count+1;
             ListOfEmployee.Add(value);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee value)
        {
            foreach(var collection in ListOfEmployee )
            {
                if(collection.EmpID==id)
                {
                   collection.EmpName= value.EmpName;
                   collection.Address=value.Address;
                   collection.DepartMentID=value.DepartMentID;
                }

            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var employee=ListOfEmployee.Where(emplohe=>emplohe.EmpID==id).FirstOrDefault();
            if(employee!=null)
            ListOfEmployee.Remove(employee);
        }
}
}