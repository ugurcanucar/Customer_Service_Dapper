using Customer_Service.Application.Interfaces;
using MediatR;

namespace Customer_Service.Application.Mediatr.Commands.City.Handlers;

public class DeleteCityHandler : IRequestHandler<DeleteCityCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCityHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Cities.DeleteAsync(request.Id);
    }
}