using System.Collections.Generic;
using System.Threading.Tasks;
using HotelApplication.Models;

namespace HotelApplication.Repository
{
    public interface IReservationRepository
    {
        Task<List<ReservationModel>> GetAllReservationsAsync();
        Task<ReservationModel> GetReservationByIdAsync(int reservationId);
        Task<int> AddReservationAsync(ReservationModel reservationModel);
        Task UpdateReservationAsync(int reservationId, ReservationModel reservationModel);
        Task DeleteReservationAsync(int reservationId);
    }
}
