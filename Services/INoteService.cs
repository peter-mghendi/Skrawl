using Skrawl.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skrawl.Services
{
    public interface INoteService
    {
        Task<List<NoteDTO>> GetAllAsync();
        Task<NoteDTO> SaveAsync(NoteDTO note);
        Task<NoteDTO> DeleteAsync(long id);
    }
}