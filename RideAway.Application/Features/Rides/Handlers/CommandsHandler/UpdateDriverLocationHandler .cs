﻿using MediatR;
using RideAway.Application.Features.Rides.Commands;
using RideAway.Application.IRepositories;
using RideAway.Domain.Entities;

namespace RideAway.Application.Features.Rides.Handlers.Commands
{
    public class UpdateDriverLocationHandler : IRequestHandler<UpdateDriverLocationCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDriverLocationHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateDriverLocationCommand request, CancellationToken cancellationToken)
        {
            var driver = await _unitOfWork.UserRepository.GetByIdAsync(request.driverLocationUpdateDTO.DriverId);

            if (driver == null)
                throw new Exception("Driver not found.");

            // CurrentLocation as a
            driver.CurrentLocation = request.driverLocationUpdateDTO.CurrentLocation;

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
