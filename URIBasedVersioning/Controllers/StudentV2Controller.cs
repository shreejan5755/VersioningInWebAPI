using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using URIBasedVersioning.Models;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace URIBasedVersioning.Controllers
{
    public class StudentV2Controller : ApiController
    {
        List<StudentV2> students = new List<StudentV2>()
        {
            new StudentV2(){
                Id = 1,
                FirstName = "Tony",
                LastName = "Nevile"
            },
            new StudentV2(){
                Id = 2,
                FirstName = "Garry",
                LastName = "Rodger"
            },
            new StudentV2(){
                Id = 3,
                FirstName = "Sydney",
                LastName = "White"
            }
        };

       // [Route("api/v2/students")]
        public IEnumerable<StudentV2> Get()
        {
            return students;
        }

       // [Route("api/v2/students/{id}")]
        public StudentV2 Get(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }
    }
}
