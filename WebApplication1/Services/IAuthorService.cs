using AuthorsAPI.DTO;

namespace AuthorsAPI.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorReadDto>> GetAllAuthorsAsync();
        Task<AuthorReadDto> GetAuthorByIdAsync(int id);
        Task<AuthorReadDto> CreateAuthorAsync(AuthorCreateDto authorCreateDto);
        Task UpdateAuthorAsync(int id, AuthorUpdateDto authorUpdateDto);
        Task DeleteAuthorAsync(int id);
    }
}
