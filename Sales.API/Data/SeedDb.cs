using Sales.Shared.Entities;

namespace Sales.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCountriesAync();
            await CheckCategoriesAync();
        }

        private async Task CheckCountriesAync()
        {
            if (!_context.Countries.Any())
            {
                _context.Countries.Add(new Country { Name = "México" });
                _context.Countries.Add(new Country { Name = "Rusia" });
                _context.Countries.Add(new Country { Name = "China" });
                _context.Countries.Add(new Country { Name = "Irán" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckCategoriesAync()
        {
            if (!_context.Categories.Any())
            {
                _context.Categories.Add(new Category { Name = "Ropa" });
                _context.Categories.Add(new Category { Name = "Juguetes" });
                _context.Categories.Add(new Category { Name = "Calzado" });
                _context.Categories.Add(new Category { Name = "Comida" });
                await _context.SaveChangesAsync();
            }
        }
    }
}
