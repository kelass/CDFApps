using CDFApps.Data;
using CDFApps.Domain.dbModels;
using CDFApps.Domain.Dto;
using CDFApps.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace CDFApps.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoxesController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        public BoxesController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        public async Task<ActionResult<Boxes>> Create(BoxesDto box)
        {
           var entity = await _unitOfWork.Boxes.Create(box);
           await _unitOfWork.SaveAsync();
           return Ok(entity);

        }
        [HttpGet]
        public async Task<ActionResult<List<Boxes>>> Select()
        {
            var boxes =await _unitOfWork.Boxes.Select();
            return Ok(boxes);
        }

        [HttpPut]
        public async Task<ActionResult<List<Boxes>>> Scan([FromBody] string BoxReference)
        {
            var scan = await _unitOfWork.Boxes.Scan(BoxReference);
            if (scan == true)
            await _unitOfWork.SaveAsync();


            List<Boxes> boxes = await _unitOfWork.Boxes.SelectReceivedBoxes();
            return Ok(boxes);
            
            
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<Boxes>> Update([FromBody] UpdateBox box)
        {
            var update = await _unitOfWork.Boxes.Update(box);
            if (update != null)
                await _unitOfWork.SaveAsync();

            return Ok(update);


        }
        [HttpGet("{Id}")]
        public async Task<ActionResult> GetById(Guid Id)
        {
            Boxes? box = await _unitOfWork.Boxes.GetById(Id);
            return Ok(box);
        }
    }
}
