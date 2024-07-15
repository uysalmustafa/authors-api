using AutoMapper;
using AuthorsAPI.DTO;
using AuthorsAPI.Models;
using Microsoft.EntityFrameworkCore;
using AuthorsAPI.Context;

namespace AuthorsAPI.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly AuthorsDbContext _context;
        private readonly IMapper _mapper;

        public AuthorService(AuthorsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AuthorReadDto>> GetAllAuthorsAsync()
        {
            var authors = await _context.Authors.Include(a => a.Books).ToListAsync();
            return _mapper.Map<IEnumerable<AuthorReadDto>>(authors);
        }

        public async Task<AuthorReadDto> GetAuthorByIdAsync(int id)
        {
            var author = await _context.Authors.Include(a => a.Books).FirstOrDefaultAsync(a => a.Id == id);
            if (author == null) throw new KeyNotFoundException("Author not found");
            return _mapper.Map<AuthorReadDto>(author);
        }

        public async Task<AuthorReadDto> CreateAuthorAsync(AuthorCreateDto authorCreateDto)
        {
            var author = _mapper.Map<Author>(authorCreateDto);
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return _mapper.Map<AuthorReadDto>(author);
        }

        public async Task UpdateAuthorAsync(int id, AuthorUpdateDto authorUpdateDto)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null) throw new KeyNotFoundException("Author not found");

            _mapper.Map(authorUpdateDto, author);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAuthorAsync(int id)
        {
            var author = await _context.Authors.Include(a => a.Books).FirstOrDefaultAsync(a => a.Id == id);
            if (author == null) throw new KeyNotFoundException("Author not found");
            if (author.Books.Any()) throw new InvalidOperationException("Cannot delete author with existing books");

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
        }
    }
}
