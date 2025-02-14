using System;

namespace Core.Featurs.DealTypes.Commands.Requests;

public class UpdateDealTypeCommand : DealTypeBaseCommand
{
    public int Id { get; set; }
}
