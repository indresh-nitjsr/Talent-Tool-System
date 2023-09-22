using TalentToolSystem.Services.Search.DTO;

namespace TalentToolSystem.Services.Search.Services
{
    public interface ISearchService
    {
        public List<ResponseDTO?> SearchCandidates(RequestDTO requestDTO);
    }
}
