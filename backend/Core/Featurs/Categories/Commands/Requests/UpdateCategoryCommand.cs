using Core.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Featurs.Categories.Commands.Requests
{
    public class UpdateCategoryCommand : CategoryBaseCommand
    {
        public long Id { get; set; }
    }
}
