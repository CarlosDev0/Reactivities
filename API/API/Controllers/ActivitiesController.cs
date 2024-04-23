﻿using Application.Activities;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        //private readonly DataContext _context;
        private readonly IMediator _mediator;
        public ActivitiesController(IMediator mediator)
        {
            _mediator = mediator;
            //_context = context;
        }

        

        //public ActivitiesController(DataContext context)
        //{
        //    _context = context;
        //}
        [HttpGet]  //api/activities
        public async Task<ActionResult<List<Activity>>> GetActivities(CancellationToken ct)
        {
            //return await _context.Activities.ToListAsync();
            return await Mediator.Send(new List.Query(), ct);
        }
        [HttpGet("{id}")]  //api/activities/fdfdfaddfad
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            //return await _context.Activities.FindAsync(id);
            return await Mediator.Send(new Details.Query {Id = id });
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity(Activity activity)
        {
            //return Ok(await Mediator.Send(new Create.Command { Activity = activity }));
            await Mediator.Send(new Create.Command { Activity = activity });
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditActivity(Guid id, Activity activity)
        {
            //return Ok(await Mediator.Send(new Create.Command { Activity = activity }));
            activity.Id = id;
            await Mediator.Send(new Edit.Command { Activity = activity });
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(Guid id)
        {
            await Mediator.Send(new Delete.Command { Id = id });
            return Ok();
        }
    }
}