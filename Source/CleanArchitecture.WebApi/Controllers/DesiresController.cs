using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Application.Commands.Desire.CreateDesire;
using CleanArchitecture.Application.Commands.Desire.DeleteDesire;
using CleanArchitecture.Application.Dto;
using CleanArchitecture.Application.Quieries.Desire;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PushNotificationService.Application.Desires.Command.UpdateDesire;
using static CleanArchitecture.Application.Quieries.Desire.GetDesireQuery;

namespace CleanArchitecture.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesiresController : ApiController
    {
        public DesiresController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAsync(string userId)
        {
            return Ok(await _mediator.Send(new GetDesireQuery() { UserId = userId }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutReminder(Guid id, DesireDto desire)
        {
            await _mediator.Send(new UpdateDesireCommand { Dto = desire, DesireId = id });

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDevice(Guid deviceId)
        {
            return Ok(await _mediator.Send(new DeleteDesireCommand { DesireId = deviceId }));
        }

        [HttpPost]
        public async Task<ActionResult<DesireDto>> PostReminder(DesireDto desire)
        {
            return Ok(await _mediator.Send(new CreateDesireCommand { Dto = desire }));
        }
    }
}
