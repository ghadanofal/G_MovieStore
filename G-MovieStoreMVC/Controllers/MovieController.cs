using G_MovieStoreMVC.Data;
using G_MovieStoreMVC.Models.Entity;
using G_MovieStoreMVC.Repositories.Abstract;
using G_MovieStoreMVC.Repositories.Implementation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace G_MovieStoreMVC.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService movieService;
        private readonly IFileService fileService;
        private readonly IGenreService genService;
        public MovieController(IGenreService genService, IMovieService MovieService,
                               IFileService fileService)
        {
            this.movieService = MovieService;
            this.fileService = fileService;
            this.genService = genService;
        }
        public IActionResult Add()
        {
            var model = new Movie();
            model.GenreList = genService.List().Select(a => new SelectListItem { 
                Text = a.GenreName, 
                Value = a.Id.ToString() 
            });
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Movie model)
        {
            model.GenreList = genService.List().Select(a => new SelectListItem {
                Text = a.GenreName, 
                Value = a.Id.ToString() });
            if (!ModelState.IsValid)
                return View(model);
            if (model.ImageFile != null)
            {
                var fileReult = this.fileService.SaveImage(model.ImageFile);
                if (fileReult.Item1 == 0)
                {
                    TempData["msg"] = "File could not saved";
                    return View(model);
                }
                var imageName = fileReult.Item2;
                model.ImageURL = imageName;
            }
            var result = movieService.Add(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(Add));
            }
            else
            {
                TempData["msg"] = "Error on server side";
                return View(model);
            }
        }

        public IActionResult Edit(int id)
        {
            var model = movieService.GetById(id);
            var selectedGenres = movieService.GetGenreByMovieId(model.Id);
            MultiSelectList multiGenreList = new MultiSelectList(genService.List(), "Id", "GenreName", selectedGenres);
            model.MultiGenreList = multiGenreList;
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Movie model)
        {
            var selectedGenres = movieService.GetGenreByMovieId(model.Id);
            MultiSelectList multiGenreList = new MultiSelectList(genService.List(), "Id", "GenreName", selectedGenres);
            model.MultiGenreList = multiGenreList;
            if (!ModelState.IsValid)
                return View(model);
            if (model.ImageFile != null)
            {
                var fileReult = this.fileService.SaveImage(model.ImageFile);
                if (fileReult.Item1 == 0)
                {
                    TempData["msg"] = "File could not saved";
                    return View(model);
                }
                var imageName = fileReult.Item2;
                model.ImageURL = imageName;
            }
            var result = movieService.Update(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(MovieList));
            }
            else
            {
                TempData["msg"] = "Error on server side";
                return View(model);
            }
        }

        public IActionResult MovieList()
        {
            var data = this.movieService.List();
            return View(data);
        }

        public IActionResult Delete(int id)
        {
            var result = movieService.Delete(id);
            return RedirectToAction(nameof(MovieList));
        }

    }
}
