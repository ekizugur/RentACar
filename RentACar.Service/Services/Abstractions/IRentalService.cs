using RentACar.Data.DTOs;
using RentACar.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Service.Services.Abstractions
{
    public interface IRentalService
    {
        Task Rent(CarRentalDto carRentalDto);
        Task<Car> GetCarById(Guid carId);
        Task<List<CarRentalDto>> GetAllRentalsAsync();
        Task<bool> isAvailable(Guid carId, DateTime RentACar, DateTime EndTime);
        Task<List<CarRentalDto>> GetRentalsByUserId(Guid userId);
        Task<bool> RentalCancellation(Guid id);
        Task RentalControl();
        Task RentalRememberEmail();
        Task<CarRentalDto> RentalCancellationRequest(Guid id);
        Task<List<CarRentalDto>> GetRefundRequestsAsync();
    }
}
