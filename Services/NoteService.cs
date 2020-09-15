using Skrawl.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skrawl.Services
{
    public class NoteService : INoteService
    {
        private const string _notesUrl = "api/me/notes";

        private IHttpService _httpService;

        public NoteService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<List<NoteDTO>> GetAll()
        {
            return (await _httpService.Get<IEnumerable<NoteDTO>>(_notesUrl)).ToList();
        }

        public async Task<NoteDTO> Save(NoteDTO note) 
        {
            if (note.Id < 0) 
                return await _httpService.Post<NoteDTO>(_notesUrl, note);
            
            await _httpService.Put($"{_notesUrl}/{note.Id}", note);
            return note;
        }
    }
}