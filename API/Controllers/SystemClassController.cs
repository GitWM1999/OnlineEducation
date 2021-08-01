using Education.DTO.Class;
using Education.Service.ClassListSer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Education.API.Controllers
{
    [Route("api/[controller]")]
    public class SystemClassController : Controller
    {
        private IClassListService _classListService;

        public SystemClassController(IClassListService classListService)
        {
            _classListService = classListService;
        }
        [HttpGet]
        [Route("GetSystemClass")]
        public IActionResult GetSystemClass(int TypeId, int SecondId)
        {
            List<ClassListOutput> ls = _classListService.GetSystemClass(TypeId, SecondId);
            return Ok(ls);
        }
    }
}
