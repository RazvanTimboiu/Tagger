using System;
using System.Collections.Generic;
using System.Text;
using Application.DTO;
using MediatR;

namespace Application.Dataset.Queries
{
    public class GetAllQuery : IRequest<User>
    {
    }
}
