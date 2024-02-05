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
    public class TeacherController : ControllerBase
    {
        private ITeacherRepo _teacherRepo;

        public TeacherController(ITeacherRepo studentRepo)
        {
            _teacherRepo = studentRepo;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBy(Guid id)
        {
            Teacher? entity = new();
            if (_teacherRepo is not null)
            {
                entity = await _teacherRepo.GetById(id);
                if (entity != null)
                    return Ok(entity.ToTeacherDto());
            }
            return BadRequest("Az adatok elérhetetlenek!");
        }

        [HttpGet]
        public async Task<IActionResult> SelectAllRecordToListAsync()
        {
            List<Teacher>? entities = new();

            if (_teacherRepo != null)
            {
                entities = await _teacherRepo.FindAll().ToListAsync();
                return Ok(entities.Select(teacher => teacher.ToTeacherDto()));
            }
            return BadRequest("Az adatok elérhetetlenek!");
        }

        [HttpPut()]
        public async Task<ActionResult> UpdateTeacherAsync(TeacherDto entity)
        {
            ControllerResponse response = new();
            if (_teacherRepo is not null)
            {
                response = await _teacherRepo.UpdateAsync(entity.ToTeacher());
                if (response.HasError)
                {
                    Console.WriteLine(response.Error);
                    response.ClearAndAddError("A tanár adatainak módosítása nem sikerült!");
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
        public async Task<IActionResult> DeleteTeacherAsync(Guid id)
        {
            ControllerResponse response = new();
            if (_teacherRepo is not null)
            {
                response = await _teacherRepo.DeleteAsync(id);

                if (response.HasError)
                {
                    Console.WriteLine(response.Error);
                    response.ClearAndAddError("A tanár adatainak törlése nem sikerült!");
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
        public async Task<IActionResult> InsertTeacherAsync(TeacherDto teacher)
        {
            ControllerResponse response = new();
            if (_teacherRepo is not null)
            {
                response = await _teacherRepo.InsertAsync(teacher.ToTeacher());
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
