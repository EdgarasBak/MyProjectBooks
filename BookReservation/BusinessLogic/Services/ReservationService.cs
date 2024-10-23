using BusinessLogic.Services.Interface;
using Database.Models;
using Database.Repository.Interface;
using Shared;
using Shered.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IBookRepository _bookRepository;
        private decimal TwentyPercentDiscount = 0.8m;
        private decimal TenPercentDiscount = 0.9m;
        private decimal ServiceFee = 3m;
        private decimal QuickPickupFee = 5m;

        public ReservationService(IReservationRepository reservationRepository, IBookRepository bookRepository)
        {
            _reservationRepository = reservationRepository;
            _bookRepository = bookRepository;
        }
        public async Task<IEnumerable<ReservationDTO>> GetAllReservationsAsync()
        {
            return await _reservationRepository.GetAllReservationsAsync();
        }
        public async Task<ReservationDTO> GetReservationByIdAsync(int id)
        {
            return await _reservationRepository.GetReservationByIdAsync(id);
        }
        public async Task<ReservationDTO> AddReservationAsync(ReservationDTO reservationDto)
        {
            var book = await _bookRepository.GetBookByIdAsync(reservationDto.BookId);
            if (book == null) throw new ArgumentException("Book not found.");

            BookType selectedType = reservationDto.SelectedType;

            var reservation = new Reservation
            {
                BookId = reservationDto.BookId,
                Days = reservationDto.Days,
                QuickPickUp = reservationDto.QuickPickUp,
                TotalCost = CalculateTotalCost(reservationDto.Days, selectedType, reservationDto.QuickPickUp)
            };

            await _reservationRepository.AddReservationAsync(reservation);

            return new ReservationDTO
            {
                BookId = reservation.BookId,
                BookName = book.Name,
                Days = reservation.Days,
                QuickPickUp = reservation.QuickPickUp,
                TotalCost = reservation.TotalCost,
                SelectedType = selectedType
            };
        }
        public async Task DeleteReservationAsync(int id)
        {
            var reservation = await _reservationRepository.GetReservationByIdAsync(id);
            if (reservation == null)
            {
                throw new ArgumentException("Reservation not found.");
            }

            await _reservationRepository.DeleteReservationAsync(id);
        }
        private decimal CalculateTotalCost(int days, BookType Type, bool quickPickUp)
        {
            decimal dailyRate = Type == BookType.Audiobook ? 3m : 2m;
            decimal totalCost = dailyRate * days;

            if (days > 10)
            {
                totalCost *= TwentyPercentDiscount;
            }
            else if (days > 3)
            {
                totalCost *= TenPercentDiscount;
            }
            totalCost += ServiceFee;

            if (quickPickUp)
            {
                totalCost += QuickPickupFee;
            }
            return totalCost;
        }
    }
}
