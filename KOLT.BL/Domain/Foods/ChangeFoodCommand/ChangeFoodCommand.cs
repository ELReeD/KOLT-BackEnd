using KOLT.DTO;
using MediatR;

namespace KOLT.BL.Domain.Foods.ChangeFoodCommand
{
    public class ChangeFoodCommand : FoodDTO, IRequest
    {
    }
}
