using MazeGeneratorLib;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Diagnostics;
using System.Text.Json;

namespace MazeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MazeGenerationController : ControllerBase
    {
        private readonly JsonSerializerOptions serializerOptions;
        public MazeGenerationController()
        {
            serializerOptions = new JsonSerializerOptions();
            serializerOptions.Converters.Add(new TwoDimensionalIntArrayJsonConverter());
        }

        [HttpPost("GetMaze")]
        [SwaggerOperation("Generates and returns a Maze of given Height and Width")]
        [SwaggerResponse(StatusCodes.Status200OK, "Maze successfuly generated and returned", typeof(ActionResult<bool>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Error while generating maze", typeof(ActionResult<bool>))]
        public async Task<IActionResult> GenerateMaze([FromQuery] int mazeHeight, [FromQuery] int mazeWidth, [FromQuery] int? mazeSeed)
        {
            var timer = Stopwatch.StartNew();
            var generator = new MazeGenerator(new MazeGeneratorLib.V3.MazeGenV3(mazeSeed), mazeHeight, mazeWidth);
            var generatedMaze = generator.GetMaze();

            var response = JsonSerializer.Serialize(generatedMaze, serializerOptions);
            timer.Stop();
            Console.WriteLine("Ticks: "+ timer.ElapsedTicks);
            Console.WriteLine("Milis: "+ timer.ElapsedMilliseconds);

            return Ok(response);
        }
    }
}