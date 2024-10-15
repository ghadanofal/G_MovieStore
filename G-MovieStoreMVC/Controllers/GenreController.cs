using G_MovieStoreMVC.Models.DTO;
using G_MovieStoreMVC.Models.Entity;
using G_MovieStoreMVC.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
namespace G_MovieStoreMVC.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;
        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(GenreVM genreVM)
        {
            if (!ModelState.IsValid)
                return View(genreVM);
            var genre = new Genre
            {
                GenreName = genreVM.GenreName,
            };
            var result = _genreService.Add(genre);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(Add));
            }
            else
            {
                TempData["msg"] = "Error on server side";
                return View(genre);
            }
        }
        public IActionResult Edit(int id)
        {
            var genre = _genreService.GetById(id);
            if (genre == null)
            {
                return NotFound();
            }
            var viewModel = new GenreVM
            {

                GenreName = genre.GenreName
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Update(Genre model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = _genreService.Update(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(GenreList));
            }
            else
            {
                TempData["msg"] = "Error on server side";
                return View(model);
            }
        }
        public IActionResult GenreList()
        {
            // Fetch the list of Genre entities
            var data = this._genreService.List().ToList();

            // Convert the List<Genre> to List<GenreVM>
            var genreVMList = data.Select(g => new GenreVM
            {
                Id = g.Id,
                GenreName = g.GenreName
            }).ToList();

            // Pass the List<GenreVM> to the view
            return View(genreVMList);
        }
        public IActionResult Delete(int id)
        {
            var result = _genreService.Delete(id);
            return RedirectToAction(nameof(GenreList));
        }
    }
}