using Microsoft.AspNetCore.Mvc;
using SqlQueryPractice.Models;

namespace SqlQueryPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PracticeController : ControllerBase
    {
        private readonly SqlPracticeContext _context;

        public PracticeController(SqlPracticeContext context)
        {
            _context = context;
        }

        [HttpGet("Select")]
        public ActionResult Select()
        {
            //List namefirst, namelast of all student.
            /*var result = _context.Students.Select(student => new
            {
                student.Namefirst,
                student.Namelast,
                student.Dob,
                student.EmailId
            });*/



            //Display student information of the ID is 12.
            //var result = _context.Students.FirstOrDefault(s => s.Id == 12);



            //List namefirst, namelast, and emailID of student whose student namefirstis ‘Nitish’.
            /*var result = _context.Students
                .Where(s => s.Namefirst == "Nitish")
                .Select(s => new
            {
                s.Namefirst,
                s.Namelast,
                s.EmailId,
            });*/



            //List all students having ID greater than equal to 12.
            //var result = _context.Students.Where(s => s.Id > 12);



            //List namefirst, namelast of all students in ascending order of namefirst.
            //var result = _context.Students.OrderBy(s => s.Namefirst);



            //List namefirst, namelast, DOB, and emailID for the first 5 students.
            /*var result = _context.Students
                .Take(5)
                .Select(s => new
                {
                    s.Namefirst,
                    s.Namelast,
                    s.Dob,
                    s.EmailId
                });*/



            //Display student information of the studentID is either 1, 2, 5 or 7
            //select * from students where id in (1,2,5,7)
            //var result = _context.Students.Where(s => new[] { 1, 2, 5, 7 }.Contains(s.Id));



            //List namefirst, namelast, and emailID of student whose studentID is not5, 10, 15, display first 7 rows only.
            //select top(7) namefirst, nameLast, emailId from student where id not in (5,10,15)
            /*var result = _context.Students
                .Where(s => !new[] { 5, 10, 15 }.Contains(s.Id))
                .Take(7);*/



            //List all student_phone number in ascending order of phone number.
            //select number from student_Phone order by number
            /*var result = _context.StudentPhones
                .OrderBy(s => s.Number)
                .Select(s => s.Number);*/



            //Display the student_address whose studentID is either 2, 4, 6 or 10 in descending order of studentID
            //select address from student_address where studentID in (2,4,6,10) order by studentID desc
            /*var result = _context.StudentAddresses
                .Where(s => new[] { 2, 4, 6, 10 }.Contains(s.Id))
                .OrderByDescending(s => s.StudentId)
                .Select(s => s.Address);
            return Ok(result);*/

            return Ok();
        }

        [HttpGet("Aggregate")]
        public ActionResult AggregateFunctions()
        {
            //Get student namefirst with how many characters are there in their namefirst.
            //select namefirst, len(namefirst) from student
            /*var results = _context.Students
                .Select(s => new
                {
                    s.Namefirst,
                    lenght = s.Namefirst != null ? s.Namefirst.Length : 0
                });*/


            //Get student details whose namefirst is having 4 characters only
            //select* from student where len(nameFirst) = 4
            /* var results = _context.Students
                .Where(s => s.Namefirst.Length == 4)
                .Select(s => new
                {
                    s.Namefirst,
                    s.Namelast
                });*/



            //Get the ASCII value of the 3rd character of namefirst column.
            //select nameFirst, ASCII(SUBSTRing(nameFirst, 3,1)) from student
            /*var results = _context.Students
                .Select(s => new
                {
                    s.Namefirst,
                    ASCII = (int)s.Namefirst[2]
                }); */



            //Get all student whose DOB is in the month of ‘October’
            //select * from student where month(DOB) = 10 
            //var results = _context.Students
            //    .Where(s => s.Dob.Value.Month == 10);



            //Count total number of students.
            //select count(*) from student
            //var results = _context.Students.Count();



            //Count total number of students who are born in 1986
            //select * from student where YEAR(DOB) = 1986
            //var results = _context.Students
            //    .Where(s => s.Dob.Value.Year == 1986);





            return Ok(results);

            //return Ok();
        }




    }
}
