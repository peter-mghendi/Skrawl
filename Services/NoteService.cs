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

        public async Task<List<NoteDTO>> GetAllAsync()
        {
            return (await _httpService.GetAsync<IEnumerable<NoteDTO>>(_notesUrl)).ToList();
        }

        public async Task<NoteDTO> SaveAsync(NoteDTO note) 
        {
            if (note.Id < 0) 
                return await _httpService.PostAsync<NoteDTO>(_notesUrl, note);
            
            await _httpService.PutAsync($"{_notesUrl}/{note.Id}", note);
            return note;
        }

        
        public async Task<NoteDTO> DeleteAsync(long id)
        {
            return await _httpService.DeleteAsync<NoteDTO>($"{_notesUrl}/{id}");
        }
    }
}