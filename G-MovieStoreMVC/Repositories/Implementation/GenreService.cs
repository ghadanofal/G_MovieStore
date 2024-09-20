using G_MovieStoreMVC.Data;
using G_MovieStoreMVC.Models.Entity;
using G_MovieStoreMVC.Repositories.Abstract;

namespace G_MovieStoreMVC.Repositories.Implementation
{
    public class GenreService : IGenreService
    {
        private readonly ApplicationDbContext context;

        public GenreService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public bool Add(Genre model)
        {
            try
            {
                context.Genres.Add(model);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var data = this.GetById(id);
                if (data == null)
                    return false;
                context.Genres.Remove(data);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Genre GetById(int id)
        {
            return context.Genres.Find(id);
        }

        public IQueryable<Genre> List()
        {
            var data = context.Genres.AsQueryable();
            return data;
        }

        public bool Update(Genre model)
        {
            try
            {
                context.Genres.Update(model);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
    }