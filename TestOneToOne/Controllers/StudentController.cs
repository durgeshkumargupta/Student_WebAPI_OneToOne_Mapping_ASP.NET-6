using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestOneToOne.data;

namespace TestOneToOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly DataContext context;
        public StudentController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> Get()
        {
            
            var student = await context.Student.ToListAsync();
            foreach (Student student2 in student)
            {
                student2.Address = context.Address.Where(address => address.AddressId == student2.StudentId).FirstOrDefault();
            }
            
            return Ok(await context.Student.ToListAsync());

        }
         
        [HttpPost]
        public async Task<ActionResult> Post(Student student)
        {
            context.Student.Add(student);
            context.SaveChanges();
            return Ok(student);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var s=await context.Student.FindAsync(id);
            var a = await context.Address.FindAsync(id);
            if (s == null && a==null)
                return BadRequest("Data Not Available");

            context.Student.Remove(s);
            context.Address.Remove(a);

            context.SaveChanges();
            return Ok("Data Deleted");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id,Student student)
        {
            var s = await context.Student.FindAsync(id);
            var a = await context.Address.FindAsync(id);
            if (s == null && a == null)
                return BadRequest("Data Not Available");

            s.Name = student.Name;
            s.Age = student.Age;
            
            a.Pin=student.Address.Pin;
            a.City = student.Address.City;  

            context.SaveChanges();
            return Ok(student);

        }



    }
}
