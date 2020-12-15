using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Application.Dataset.Queries;
using Application.DTO;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Tagger.Controllers
{
    public class DatasetController: BaseController
    {
        [Authorize]
        [HttpGet("dataset/creator/{id}")]
        public async Task<ActionResult<List<Dataset>>> GetDatasetById(int id)
        {

            var result = await Mediator.Send(new GetByIdQuery {DatasetId = id});
            return Ok(result);

            

        }
    }
}
