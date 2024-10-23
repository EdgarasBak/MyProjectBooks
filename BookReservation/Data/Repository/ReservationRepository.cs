using Database.Models;
using Database.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Shered.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly LibraryDbContext _context;

        public ReservationRepository(LibraryDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ReservationDTO>> GetAllReservationsAsync()
        {
            return await _context.Reservations
                .Include(r => r.Book)
                .Select(r => new ReservationDTO
            {
                BookId = r.BookId,
                BookName = r.Book.Name,
                Days = r.Days,
                QuickPickUp = r.QuickPickUp,
                TotalCost = r.TotalCost
            }).ToListAsync();
        }
        public async Task<ReservationDTO> GetReservationByIdAsync(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null) return null;

            return new ReservationDTO
            {
                BookId = reservation.BookId,
                Days = reservation.Days,
                QuickPickUp = reservation.QuickPickUp,
                TotalCost = reservation.TotalCost
            };
        }
        public async Task AddReservationAsync(Reservation reservation)
        {
            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateReservationAsync(Reservation reservation)
        {
            _context.Reservations.Update(reservation);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteReservationAsync(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
                await _context.SaveChangesAsync();
            }
        }
    }
}
