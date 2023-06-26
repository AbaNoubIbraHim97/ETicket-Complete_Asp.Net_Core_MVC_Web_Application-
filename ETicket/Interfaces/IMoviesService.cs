using ETicket.Models;
using ETicket.Models.DTO;
using System.Linq.Expressions;

namespace ETicket.Interfaces
{
    public interface IMoviesService : IBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);
        Task<NewMovieDropdownsModel> GetNewMovieDropdownsValues();
        Task AddNewMovieAsync(NewMovieModel data);
        Task UpdateMovieAsync(NewMovieModel data);
        Task DeleteMovieAsync(int id);



    }
}
