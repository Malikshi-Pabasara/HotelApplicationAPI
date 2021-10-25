using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HotelApplication.Data;
using HotelApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelApplication.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly HotelContext _context;
        private readonly IMapper _mapper;
        public ReservationRepository(HotelContext context, IMapper mapper) //Dependency Injection
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ReservationModel>> GetAllReservationsAsync()
        {
            var records = await _context.Reservations.ToListAsync();
            return _mapper.Map<List<ReservationModel>>(records); //Auto Map the record
        }

        public async Task<ReservationModel> GetReservationByIdAsync(int reservationId)
        {
            var reservation = await _context.Reservations.FindAsync(reservationId);
            return _mapper.Map<ReservationModel>(reservation);
        }

        public async Task<int> AddReservationAsync(ReservationModel reservationModel)
        {
            var reservation = new Reservation()
            {
                PropertyId = reservationModel.PropertyId,
                RoomId = reservationModel.RoomId,
                ContactId = reservationModel.ContactId,
                ReservationNo = reservationModel.ReservationNo,
                ArrivalDate = reservationModel.ArrivalDate,
                DepartureDate = reservationModel.DepartureDate,
                Notes = reservationModel.Notes
            };

            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            return reservation.ReservationId;
        }
        public async Task UpdateReservationAsync(int reservationId, ReservationModel reservationModel)
        {
            var reservation = new Reservation()
            {
                ReservationId = reservationId,
                PropertyId = reservationModel.PropertyId,
                RoomId = reservationModel.RoomId,
                ContactId = reservationModel.ContactId,
                ReservationNo = reservationModel.ReservationNo,
                ArrivalDate = reservationModel.ArrivalDate,
                DepartureDate = reservationModel.DepartureDate,
                Notes = reservationModel.Notes
            };

            _context.Reservations.Update(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReservationAsync(int reservationId)
        {
            var reservation = new Reservation()
            {
                ReservationId = reservationId
            };

            _context.Reservations.Remove(reservation);

            await _context.SaveChangesAsync();
        }
    }
}
