using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webb_Labb2.DAL;
using Webb_Labb2.DAL.Models;

namespace Webb_Labb2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DifficultyController : ControllerBase
    {
        private readonly DifficultyStorage _difficultyStorage;

        public DifficultyController([FromServices] DifficultyStorage difficultyStorage)
        {
            _difficultyStorage = difficultyStorage;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var difficulties = _difficultyStorage.GetAllDifficulties();
            return difficulties.Count > 0 ? Ok(difficulties) : NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var difficulty = _difficultyStorage.GetDifficulty(id);
            return difficulty is not null ? Ok(difficulty) : NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Difficulty difficulty)
        {
            _difficultyStorage.CreateDifficulty(difficulty);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Difficulty difficulty)
        {
            _difficultyStorage.UpdateDifficulty(id, difficulty);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _difficultyStorage.DeleteDifficulty(id);
            return Ok();
        }
    }
}
