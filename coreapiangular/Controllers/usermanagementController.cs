using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;

using coreapiangular.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace coreapiangular.Controllers
{
    //[Route("api/[controller]")]
    [Route("usermanagement")]
    [ApiController]
    public class usermanagementController : ControllerBase
    {
        private readonly string _uploadDir = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
        public usermanagementController()
        {
            if(!Directory.Exists(_uploadDir))
            {
                Directory.CreateDirectory(_uploadDir);
            }
        }
        Userdbcls obj=new Userdbcls();
        // GET: api/<usermanagementController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<usermanagementController>/5
        [HttpGet]
        [Route("gettabwithid/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Usercls getemployee = obj.selectprofiledb(id);
            var fileUrl = Path.Combine(Directory.GetCurrentDirectory(), "uploads",
                getemployee.photo);
            byte[] imageBytes=await System.IO.File.ReadAllBytesAsync(fileUrl);
            string base64String=Convert.ToBase64String(imageBytes);
            getemployee.photo = base64String;
            return Ok(getemployee);
        }

        // POST api/<usermanagementController>
        [HttpPost]
        [Route("inserttab")]
        public async Task<IActionResult> Post([FromForm] UsercreateDTO createdto)         
        {
            Usercls usercls = new Usercls();

            if(createdto.path ==null || createdto.path.Length ==0)
            {
                return BadRequest("no file uploaded.");
            }
            if(!createdto.path.ContentType.StartsWith("image/"))
            {
                return BadRequest("only image files are allowed.");
            }
            var filepath = Path.Combine(_uploadDir, createdto.path.FileName);

            using (var stream = new FileStream(filepath, FileMode.Create))
            {
                await createdto.path.CopyToAsync(stream);
            }
            usercls.name = createdto.name;
            usercls.age = createdto.age;
            usercls.addr = createdto.addr;
            usercls.email = createdto.email;
            usercls.photo = createdto.path.FileName;
            usercls.uname = createdto.uname;
            usercls.password = createdto.password;
           obj.insertdb(usercls);
            return await Task.Run(() => Ok(new { message = "Registered Successfully" }));
        }
        [HttpPost]
        [Route("logintab")]
       public async Task<IActionResult> PostLogin([FromBody] userloginDTo createdto)
        {
            Usercls usercls = new Usercls();
            usercls.uname=createdto.uname;
            usercls.password=createdto.password;
            string cid = obj.logindb(usercls);
            if(cid=="1")
            {
                string uid=obj.getuserid(usercls);
                return await Task.Run(() => Ok(new { userid =uid }));

                //return await Task.Run(() => Ok(new { message = "Success" }));
            }
            else
            {
                return await Task.Run(() => Ok(new { message = "Invalid Login" }));
            }
        }


        // PUT api/<usermanagementController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<usermanagementController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
