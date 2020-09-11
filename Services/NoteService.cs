using Skrawl.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skrawl.Services
{
    public class NoteService : INoteService
    {
        private IHttpService _httpService;

        public NoteService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<IEnumerable<NoteDTO>> GetAll()
        {
            return await _httpService.Get<IEnumerable<NoteDTO>>("/notes");
        }
    }
}