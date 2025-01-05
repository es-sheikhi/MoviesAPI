using MoviesAPI.Data;
using MoviesAPI.Models;
using MoviesAPI.Repositories.Interfaces;

namespace MoviesAPI.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool CreateCategory(Category category)
        {
            category.DateOfCreation = DateTime.Now;
            _context.Categories.Add(category);
            return Save();
        }

        public bool DeleteCategory(Category category)
        {
            _context.Categories.Remove(category);
            return Save();
        }

        public bool ExistCategory(int id)
        {
            return _context.Categories.Any(c => c.Id == id);
        }

        public bool ExistCategory(string name)
        {
            return _context.Categories.Any(c => c.Name == name);
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.OrderBy(c=>c.Name).ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.FirstOrDefault(c => c.Id == id);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public bool UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            return Save();
        }
    }
}
