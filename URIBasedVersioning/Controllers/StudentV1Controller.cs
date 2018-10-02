using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using URIBasedVersioning.Models;
using RouteAttribute = System.Web.Http.RouteAttribute;
//using RouteAttribute = System.Web.Http.RouteAttribute;

namespace URIBasedVersioning.Controllers
{
    public class StudentV1Controller : ApiController
    {
        List<StudentV1> students = new List<StudentV1>()
        {
            new StudentV1(){
                Id = 1,
                Name = "Tony"
            },
            new StudentV1(){
                Id = 2,
                Name = "Garry"
            },
            new StudentV1(){
                Id = 3,
                Name = "Sydney"
            }
        };

       // [Route("api/v1/students")]
        public IEnumerable<StudentV1> Get()
        {
            return students;
        }

        //[Route("api/v1/students/{id}")]
        public StudentV1 Get(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }

       
    }
}
