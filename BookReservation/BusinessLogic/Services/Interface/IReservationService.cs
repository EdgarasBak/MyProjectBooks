using Database.Models;
using Shered.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Interface
{
    public interface IReservationService
    {
        Task<IEnumerable<ReservationDTO>> GetAllReservationsAsync();
        Task<ReservationDTO> GetReservationByIdAsync(int id);
        Task<ReservationDTO> AddReservationAsync(ReservationDTO reservationDto);
        Task DeleteReservationAsync(int id);
    }
}
