using Database.Models;
using Shered.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repository.Interface
{
    public interface IReservationRepository
    {
        Task<IEnumerable<ReservationDTO>> GetAllReservationsAsync();
        Task<ReservationDTO> GetReservationByIdAsync(int id);
        Task AddReservationAsync(Reservation reservation);
        Task UpdateReservationAsync(Reservation reservation);
        Task DeleteReservationAsync(int id);
    }
}
