using CoffeeMachine.BL.DTOs;
using CoffeeMachine.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeMachine.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private ICommandsCreatorService _commandCreationService;
        private ICommandsGetterService _commandGetterService;

        public CommandsController(ICommandsCreatorService commandCreationService, ICommandsGetterService commandGetterService)
        {
            _commandCreationService = commandCreationService;
            _commandGetterService = commandGetterService;
        }


        [HttpGet]
        public IActionResult  GetCommandsForUser(string user)
        {
            var commands = _commandGetterService.GetCommandsForUser(user);
            return Ok(commands);
        }

        [HttpPost]
        public IActionResult CreateCommand([FromBody] CommandDTOInput commandDto)
        {
            var command = _commandCreationService.CreateCommand(commandDto);
            return Ok(command);
        }
    }
}
