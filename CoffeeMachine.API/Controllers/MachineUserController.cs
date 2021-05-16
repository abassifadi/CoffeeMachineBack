using CoffeeMachine.BL.DTO;
using CoffeeMachine.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeMachine.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachineUserController : ControllerBase
    {
        private IMachineUserCreatorService _creatorService;
        private IMachineUserGetterService _getterService;

        public MachineUserController(IMachineUserCreatorService creatorService , IMachineUserGetterService getterService)
        {
            _creatorService = creatorService;
            _getterService = getterService;
        }

        [HttpPost]
        public void RegisterUser([FromBody] MachineUserDTO user)
        {
            _creatorService.RegisterUser(user);
        }

        [HttpGet]
        public bool ChechIfUserIdentifierExisting(string identifier)
        {
            return _getterService.IsUserIdentifierExisting(identifier);
        }
    }
}
