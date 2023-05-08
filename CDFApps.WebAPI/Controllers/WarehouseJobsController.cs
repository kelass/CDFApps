using CDFApps.Data;
using CDFApps.Domain.dbModels;
using CDFApps.Domain.Dto;
using CDFApps.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace CDFApps.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseJobsController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        public WarehouseJobsController(UnitOfWork unitOfWork)
        {
           _unitOfWork = unitOfWork;
        }
        [HttpPost]
        public async Task<ActionResult<WarehouseJobs>> Create(WarehouseJobsDto warehousejob)
        {
           var entity = await _unitOfWork.WarehouseJobsRepository.Create(warehousejob);
           await _unitOfWork.SaveAsync();
           return Ok(entity);
        }
        [HttpGet]
        public async Task<ActionResult<List<WarehouseJobs>>> Select()
        {
            List<WarehouseJobs> warehousejobs = await _unitOfWork.WarehouseJobsRepository.Select();
            return Ok(warehousejobs);
        }
    }
}
