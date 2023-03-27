using BTS.Dtos;
using BTS.Entities;
using BTS.Entities.ApplicationDbContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BTS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ChecklistController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public ChecklistController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Checklist>>> GetChecklist()
        {
            var checklists = await _dbContext.Checklists.ToListAsync();

            return Ok(checklists);
        }

        [HttpPost]
        public async Task<ActionResult<Checklist>> Create(ChecklistDto checklistDto)
        {
            var checklist = new Checklist
            {
                Name = checklistDto.Name,
            };

            await _dbContext.Checklists.AddAsync(checklist);
            await _dbContext.SaveChangesAsync();

            return Ok(checklist);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id)
        {
            var checklist = _dbContext.Checklists.Find(id);

            if (checklist == null)
            {
                return BadRequest("Checklist not found");
            }

             _dbContext.Checklists.Remove(checklist);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
