using Kreata.Backend.Repos;
using Kreta.Shared.Dtos;
using Kreta.Shared.Extensions;
using Kreta.Shared.Models;
using Kreta.Shared.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kreata.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParentController : ControllerBase
    {
        private IParentRepo _parentRepo;

        public ParentController(IParentRepo studentRepo)
        {
            _parentRepo = studentRepo;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBy(Guid id)
        {
            Parent? entity = new();
            if (_parentRepo is not null)
            {
                entity = await _parentRepo.GetById(id);
                if (entity != null)
                    return Ok(entity.ToParentDto());
            }
            return BadRequest("Az adatok elérhetetlenek!");
        }

        [HttpGet]
        public async Task<IActionResult> SelectAllRecordToListAsync()
        {
            List<Parent>? entities = new();

            if (_parentRepo != null)
            {
                entities = await _parentRepo.FindAll().ToListAsync();
                return Ok(entities.Select(parent => parent.ToParentDto()));
            }
            return BadRequest("Az adatok elérhetetlenek!");
        }

        [HttpPut()]
        public async Task<ActionResult> UpdateParentAsync(ParentDto entity)
        {
            ControllerResponse response = new();
            if (_parentRepo is not null)
            {
                response = await _parentRepo.UpdateAsync(entity.ToParent());
                if (response.HasError)
                {
                    Console.WriteLine(response.Error);
                    response.ClearAndAddError("A szülő adatainak módosítása nem sikerült!");
                    return BadRequest(response);
                }
                else
                {
                    return Ok(response);
                }
            }
            response.ClearAndAddError("Az adatok frissítés nem lehetséges!");
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParentAsync(Guid id)
        {
            ControllerResponse response = new();
            if (_parentRepo is not null)
            {
                response = await _parentRepo.DeleteAsync(id);

                if (response.HasError)
                {
                    Console.WriteLine(response.Error);
                    response.ClearAndAddError("A szülő adatainak törlése nem sikerült!");
                    return BadRequest(response);
                }
                else
                {
                    return Ok(response);
                }
            }
            response.ClearAndAddError("Az adatok törlése nem lehetséges!");
            return BadRequest(response);
        }

        [HttpPost()]
        public async Task<IActionResult> InsertTeacherAsync(ParentDto parent)
        {
            ControllerResponse response = new();
            if (_parentRepo is not null)
            {
                response = await _parentRepo.InsertAsync(parent.ToParent());
                if (response.HasError)
                {
                    Console.WriteLine(response.Error);
                }
                else
                {
                    return Ok(response);
                }
            }
            response.ClearAndAddError("Az új adatok mentése nem lehetséges!");
            return BadRequest(response);
        }
    }
}
