using Skrawl.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skrawl.Services
{
    public interface INoteService
    {
        Task<List<NoteDTO>> GetAll();
        Task<NoteDTO> Save(NoteDTO note);
    }
}