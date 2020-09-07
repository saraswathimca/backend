using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

   // crudContext Obj = new crudContext();
    public class ValuesController : ControllerBase
    {
        crudContext Obj = new crudContext();

        #region get method
        [HttpGet("get")]
        public ActionResult get(int id)
        {
            try
            {
              
                    if (id > 0)
                    {
                        return Ok(Obj.Crudoperation.Where(z => z.EmployeeId == id).FirstOrDefault());
                    }
                   
                    
                else 
                {
                    var datas = Obj.Crudoperation.ToList();
                    return Ok(datas);
                }
                
            }
            catch (Exception e)
            {
                return Ok("error" + e.Message);
            }
        }
        #endregion

        #region post and update method
        [HttpPost("update")]
        public ActionResult update([FromBody] Crudoperation sa)
        {
            try
            {
              
                    var singleloginbyid = Obj.Crudoperation.ToList();
                    var singleloginbyids = Obj.Crudoperation.Where(z => z.EmployeeId== sa.EmployeeId).FirstOrDefault();

                    if (singleloginbyids != null)
                    {
                        
                        singleloginbyids.EmployeeFirstName = sa.EmployeeFirstName;
                        singleloginbyids.EmployeeLastName = sa.EmployeeLastName;
                        Obj.SaveChanges();
                        return Ok("updated successfully");
                    }
                    else
                    {
                        Obj.Crudoperation.Add(sa);
                        Obj.SaveChanges();
                        return Ok("Insert Successfully");
                    }
            }


            catch (Exception e)
            {
                return Ok("Error" + e.Message);
            }
        }
        #endregion


        #region delete method
        [HttpPost("delete/{id}")]
        public ActionResult delete([FromRoute] int id)
        {
            try
            {
                   // if (Obj.MasterCampus.Where(z => z.Id == id).FirstOrDefault() != null)
                    {
                        Obj.Crudoperation.Remove(Obj.Crudoperation.Where(z => z.EmployeeId == id).FirstOrDefault());
                        Obj.SaveChanges();
                    return Ok("Deleted Successfully");
                        
                    }
                    

                
               


            }
            catch (Exception e)
            {
                return Ok("Error" + e.Message);
            }

        }
        #endregion

    }
}
