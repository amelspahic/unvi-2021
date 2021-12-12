using Library.Core.Common.Interfaces;
using Library.Core.Services;
using Library.Infrastructure.Database;

namespace Library.WebAPI.Extensions
{
    public static class ServicesConfiguration
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddScoped<ILibraryDbContext>(provider => provider.GetService<LibraryDbContext>());
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IBorrowService, BorrowService>();
            services.AddScoped<IStudentService, StudentService>();
        }
    }
}
