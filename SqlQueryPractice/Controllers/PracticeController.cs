using Microsoft.AspNetCore.Mvc;
using SqlQueryPractice.Models;
using System.Text.RegularExpressions;

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



            //Count total number of students whose namefirst starts with the letter ‘B’
            //select * from student where namefirst like 'B%'
            //var results = _context.Students
            //    .Where(s => s.Namefirst.StartsWith("B"));



            //Display studentID and count the student who are having more than two phones.
            //select studentID, count(studentID) as numberOfPhones from student_phone group by studentID having count(number) > 2
            //var results = _context.StudentPhones
            //    .GroupBy(s => s.StudentId)
            //    .Where(g => g.Count() > 2)
            //    .Select(g => new
            //    {
            //        StudentId = g.Key,
            //        Number = g.Count()
            //    });



            //Count unique universities from student_qualifications table.
            //select distinct university from student_qualifications
            //var results = _context.StudentQualifications
            //    .Select(q => q.University)
            //    .Distinct();



            //Display the university name and the count of those students who have done ‘BE’
            //SELECT university, COUNT(university) FROM student_qualifications WHERE name = 'BE' GROUP BY university;
            //var results = _context.StudentQualifications
            //    .Where(q => q.Name == "BE")
            //    .GroupBy(q => q.University)
            //    .Select(g => new
            //    {
            //        Uni = g.Key,
            //        Count = g.Count()
            //    });



            //Find the maximum marks student got in ‘BE’
            //select max(marks) from student_qualifications where name = 'BE'
            //var results = _context.StudentQualifications
            //    .Where(q => q.Name == "BE")
            //    .Max(q => q.Marks);



            //Count how many course_batches have started on ’2016-02-01’
            //select * from course_batches where starton = '2016-02-01'
            //var results = _context.CourseBatches
            //    .Where(c => c.Starton.ToString() == "2016-02-01");


            //return Ok(results);

            return Ok();
        }

        [HttpGet("Joins")]
        public ActionResult Joins()
        {
            //Display all student and with their address from student and student_address tables
            //select nameFirst, address from student join student_address on student.ID = studentID
            //var results = _context.Students
            //    .Join(_context.StudentAddresses,
            //        student => student.Id,
            //        studentAddress => studentAddress.StudentId,
            //        (student, studentAddress) => new
            //        {
            //            student.Namefirst,
            //            studentAddress.Address
            //        });




            //Display (namefirst, namelast, emailID, and student_qualification details) from student and student_qualification relations
            //select nameFirst, nameLast, emailId, university, marks, [year] from student s join student_qualifications sq on s.ID = sq.studentID
            //var results = _context.Students
            //    .Join(_context.StudentQualifications,
            //    s => s.Id,
            //    sq => sq.StudentId,
            //    (s, sq) => new
            //    {
            //        s.Namefirst,
            //        s.Namelast,
            //        s.EmailId,
            //        sq.University,
            //        sq.Marks,
            //        sq.Year
            //    });



            //Display (namefirst, namelast, emailID, college, and university) who have studied in 'Yale University'. (Use student, and student_qualification relation)
            //select nameFirst, nameLast, emailId, college, university from student join student_qualifications on student.Id = student_qualifications.studentID where university = 'Yale University'
            //var results = _context.Students
            //    .Join(_context.StudentQualifications,
            //        s => s.Id,
            //        sq => sq.StudentId,
            //        (s, sq) => new
            //        {
            //            s.Namefirst,
            //            s.Namelast,
            //            s.EmailId,
            //            sq.College,
            //            sq.University
            //        })
            //    .Where(r => r.University == "Yale University");
            //var results = _context.Students
            //    .SelectMany(s => s.StudentQualifications
            //    .Where(sq => sq.StudentId == s.Id && sq.University == "Yale University")
            //    .Select(sq => new
            //    {
            //        s.Namefirst,
            //        s.Namelast,
            //        s.EmailId,
            //        sq.College,
            //        sq.University
            //    }));



            //Display all student details his phone details and his qualification details. (Use student, student_phone and student_qualification relation)
            //select s.*, p.number, q.college, q.name, q.university, q.marks, q.year from student s join student_phone p on s.ID = p.studentID join student_qualifications q on s.ID = q.studentID
            //var results = (from s in _context.Students
            //               join sp in _context.StudentPhones on s.Id equals sp.StudentId
            //               join sq in _context.StudentQualifications on s.Id equals sq.StudentId
            //               select new
            //               {
            //                   s.Id,
            //                   s.Namefirst,
            //                   s.Namelast,
            //                   s.EmailId,
            //                   s.Dob,
            //                   sp.Number,
            //                   sq.Name,
            //                   sq.College,
            //                   sq.University,
            //                   sq.Marks,
            //                   sq.Year
            //               }).ToList();




            //Display (studentID, namefirst, namelast, name, college, university, and marks) whose name is ‘BE’.(Use student, and student_qualification relation
            //select s.Id, s.Namefirst, s.namelast, sq.name, sq.college, sq.university, sq.marks from student s join student_qualifications sq on s.Id = sq.studentID where sq.name = 'BE'
            //var results = (from s in _context.Students
            //               join sq in _context.StudentQualifications on s.Id equals sq.StudentId
            //               where sq.Name == "BE"
            //               select new
            //               {
            //                   s.Id,
            //                   s.Namefirst,
            //                   s.Namelast,
            //                   sq.Name,
            //                   sq.College,
            //                   sq.University,
            //                   sq.Marks
            //               });



            //Display student information along with his batch details who have joined in “Batch1”.
            //select s.*, cb.* from student s join batch_students sb on s.ID = sb.studentID join course_batches cb on sb.batchID = cb.ID where cb.name = 'Batch1'
            //var results = (from s in _context.Students
            //               join sb in _context.BatchStudents on s.Id equals sb.StudentId
            //               join cb in _context.CourseBatches on sb.BatchId equals cb.Id
            //               where cb.Name == "Batch1"
            //               select new
            //               {
            //                   s.Id,
            //                   s.Namefirst,
            //                   cb.Name,
            //                   cb.Starton
            //               });



            //Display module names for “PG-DAC” course.
            //select m.name from course c join course_modules cm on c.Id = cm.courseID join modules m on cm.moduleID = m.ID where c.name = 'PG-DAC'
            //var results = (from c in _context.Courses
            //               join cm in _context.CourseModules on c.Id equals cm.CourseId
            //               join m in _context.Modules on cm.ModuleId equals m.Id
            //               where c.Name == "PG-DAC"
            //               select new
            //               {
            //                   m.Name
            //               });






            return Ok(results);
        }
    }
}
