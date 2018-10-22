#undef LocalServer
#undef SchoolServer
#define UnoEuroServer

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApiSimpleForStudents.Models;

namespace WebApiSimpleForStudents.Controllers
{
#if (LocalServer)
    [EnableCors(origins: "http://localhost:62109", headers: "*", methods: "*")]
#endif

#if (SchoolServer)
    [EnableCors(origins: "http://ltpe3.web.techcollege.dk/", headers: "*", methods: "*")]
#endif

//#if (UnoEuroServer)
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    [EnableCors(origins: "*", headers: "Content-Type", methods: "GET,POST,PUT,DELETE,OPTIONS")]
//#endif

    public class StudentNameController : ApiController
    {
        private DatabaseContect db = new DatabaseContect();

        // GET api/values
        //public IEnumerable<string> Get()
        //{
        //    //return new string[] { "value1", "value2" };

        //    List<StudentName> StudentNames = new List<StudentName>();
        //    string[] jsonString = new string[StudentNames.Count];

        //    int IndexCounter = 0;
        //    foreach (StudentName StudentName_Object in StudentNames)
        //    {
        //        var ListItem = new
        //        {
        //            StudentNameID = StudentName_Object.StudentNameID,
        //            StudentFirstAndLastName = StudentName_Object.StudentFirstAndLastName
        //        };
        //        jsonString[IndexCounter++] = St
        //    }
        //}
//#if (LocalServer)
//        [EnableCors(origins: "http://localhost:62109", headers: "*", methods: "GET")]
//#endif

//#if (SchoolServer)
//    [EnableCors(origins: "http://ltpe3.web.techcollege.dk/", headers: "*", methods: "*")]
//#endif

//#if (UnoEuroServer)
//    [EnableCors(origins: "*.*", headers: "*", methods: "GET")]
//#endif
        public List<Object> Get()
        {
            List<object> jSonList = new List<object>();
            List<StudentName> StudentNames = new List<StudentName>();

            StudentNames = db.StudentNames.ToList();

            foreach (StudentName StudentName_Object in StudentNames)
            {
                var ListItem = new
                {
                    StudentNameID = StudentName_Object.StudentNameID,
                    StudentFirstAndLastName = StudentName_Object.StudentFirstAndLastName
                };
                jSonList.Add(ListItem);
            }
            return (jSonList);
        }

        // GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        public object Get(int id)
        {
            object json_Object = new object();
            StudentName StudentName_Object = db.StudentNames.Find(id);

            json_Object = StudentName_Object;
            
            return (json_Object);
        }

        // POST api/values
        //public void Post([FromBody]string value)
        //{
        //}
        //#if (LocalServer)
        //        [EnableCors(origins: "http://localhost:62109", headers: "*", methods: "POST")]
        //#endif

        //#if (SchoolServer)
        //    [EnableCors(origins: "http://ltpe3.web.techcollege.dk/", headers: "*", methods: "*")]
        //#endif

        //#if (UnoEuroServer)
        //    [EnableCors(origins: "*.*", headers: "*", methods: "POST")]
        //#endif
        [HttpPost]
        //[Route("")]
        public int Post(dynamic json_Object)
        {
            StudentName StudentName_Object = new StudentName();
            int NumberOfStudentNamesSaved;

            StudentName_Object.StudentFirstAndLastName = json_Object.StudentFirstAndLastName;

            db.StudentNames.Add(StudentName_Object);
            NumberOfStudentNamesSaved = db.SaveChanges();

            if (1 == NumberOfStudentNamesSaved)
            {
                //return (true);
                return (StudentName_Object.StudentNameID);
            }
            else
            {
                //return (false);
                return (0);
            }
        }

        // PUT api/values/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}
//#if (LocalServer)
//        [EnableCors(origins: "http://localhost:62109", headers: "*", methods: "PUT")]
//#endif

//#if (SchoolServer)
//    [EnableCors(origins: "http://ltpe3.web.techcollege.dk/", headers: "*", methods: "*")]
//#endif

//#if (UnoEuroServer)
//    [EnableCors(origins: "*.*", headers: "*", methods: "PUT")]
//#endif
        public bool Put(int id, dynamic json_Object)
        {
            StudentName StudentName_Object = db.StudentNames.Find(id);
            int NumberOfStudentNamesSaved;

            if (null != StudentName_Object)
            {
                StudentName_Object.StudentFirstAndLastName = json_Object.StudentFirstAndLastName;
                NumberOfStudentNamesSaved = db.SaveChanges();
                if (1 == NumberOfStudentNamesSaved)
                {
                    return (true);
                }
                else
                {
                    return (false);
                }
            }
            else
            {
                return (false);
            }
        }

        // DELETE api/values/5
        //public void Delete(int id)
        //{
        //}
//#if (LocalServer)
//        [EnableCors(origins: "http://localhost:62109", headers: "*", methods: "DELETE")]
//#endif

//#if (SchoolServer)
//    [EnableCors(origins: "http://ltpe3.web.techcollege.dk/", headers: "*", methods: "*")]
//#endif

//#if (UnoEuroServer)
//    [EnableCors(origins: "*.*", headers: "*", methods: "DELETE")]
//#endif
        public bool Delete(int id)
        {
            StudentName StudentName_Object = db.StudentNames.Find(id);
            int NumberOfStudentNamesDeleted;

            if (null != StudentName_Object)
            {
                db.StudentNames.Remove(StudentName_Object);
                NumberOfStudentNamesDeleted = db.SaveChanges();
                if (1 == NumberOfStudentNamesDeleted)
                {
                    return (true);
                }
                else
                {
                    return (false);
                }
            }
            else
            {
                return (false);
            }
        }
    }
}
