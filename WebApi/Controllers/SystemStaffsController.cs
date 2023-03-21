﻿using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemStaffsController : ControllerBase
    {
        ISystemStaffService _systemStaffService;
        public SystemStaffsController(ISystemStaffService systemStaffService)
        {
            _systemStaffService = systemStaffService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _systemStaffService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _systemStaffService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(SystemStaff systemStaff)
        {
            var result = _systemStaffService.Add(systemStaff);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(SystemStaff systemStaff)
        {
            var result = _systemStaffService.Update(systemStaff);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(SystemStaff systemStaff)
        {
            var result = _systemStaffService.Delete(systemStaff);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
