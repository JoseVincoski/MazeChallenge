using MazeGeneratorLib;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MazeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MazeGenerationController : ControllerBase
    {
        private readonly IGenerator _mazeGenService;
        public MazeGenerationController(IGenerator veiculosService)
        {
            _mazeGenService = veiculosService;
        }

        [HttpPost]
        [SwaggerOperation("Generates a file with the maze information")]
        [SwaggerResponse(StatusCodes.Status200OK, "Retorna dados salvos do veículo", typeof(ActionResult<bool>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Erro ao inserir veículo", typeof(ActionResult<bool>))]
        public async Task<IActionResult> GenerateMaze(int mazeHeight, int mazeWidth)
        {
            var generator = new MazeGenerator(_mazeGenService, mazeHeight, mazeWidth);
            var generatedMaze = generator.GetMaze();

            return Created("", null);
        }
    }
}