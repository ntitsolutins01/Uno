using System.Security.Claims;
using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using WebApp.Authorization;
using WebApp.Configuration;
using WebApp.Dto;
using WebApp.Enumerators;
using WebApp.Factory;
using WebApp.Identity;
using WebApp.Models;
using WebApp.Utility;
using static System.Reflection.Metadata.BlobBuilder;
using Claim = WebApp.Identity.Claim;

namespace WebApp.Controllers
{
    public class BookController : BaseController
    {
        #region Parametros

        private readonly ILog _logger;

        #endregion

        #region Constructor

        public BookController(IOptions<UrlSettings> appSettings, ILog logger)
        {
            _logger = logger;
            ApplicationSettings.WebApiUrl = appSettings.Value.WebApiBaseUrl;
        }

        #endregion

        #region Main Methods
        
        public IActionResult Index(int? crud, int? notify, string message = null)
        {
            try
            {
                _logger.Info($"User.Identity.Name : {User.Identity.Name}");

                SetNotifyMessage(notify, message);
                SetCrudMessage(crud);

                var genres = new SelectList(ApiClientFactory.Instance.GetGenres(), "Genre", "Genre");
                var languages = new SelectList(ApiClientFactory.Instance.GetLanguages(), "Code", "Language");
                var books = ApiClientFactory.Instance.GetBooks();

                return View(new BookModel() { Books = books, ListGenre = genres, ListLanguage = languages});
            }
            catch (Exception e)
            {
                _logger.Error($"Book.Index: {e.StackTrace}");
                return RedirectToRoute(new
                {
                    controller = "Home",
                    action = "Error",
                    message = e.Message,
                    stackTrace = e.StackTrace
                });
            }
        }

        [ClaimsAuthorize(ClaimType.Book, Claim.Read)]
        [HttpPost]
        public async Task<IActionResult> Index(int? crud, int? notify, IFormCollection collection,
            string message = null)
        {
            SetNotifyMessage(notify, message);
            SetCrudMessage(crud);

            var searchFilter = new BooksFilterDto()
            {
                Genre = collection["ddlGenre"].ToString(),
                Code = collection["ddlLanguage"].ToString()
            };

            var response = await ApiClientFactory.Instance.GetBooksByFilter(searchFilter);

            var genres = new SelectList(ApiClientFactory.Instance.GetGenres(), "Genre", "Genre", searchFilter.Genre);
            var languages = new SelectList(ApiClientFactory.Instance.GetLanguages(), "Code", "Language", searchFilter.Code);

            var model = new BookModel()
            {
                Books = response.Books,
                SearchFilter = searchFilter,
                ListGenre = genres,
                ListLanguage = languages
            };

            return View(model);
        }

        [ClaimsAuthorize(ClaimType.Book, Claim.Create)]
        public ActionResult Create(int? crud, int? notify, string message = null)
        {
            SetNotifyMessage(notify, message);
            SetCrudMessage(crud);

            return View();
        }

        [ClaimsAuthorize(ClaimType.Book, Claim.Create)]
        [HttpPost]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                var command = new BookModel.CreateUpdateBookCommand
                {
                    Title = collection["title"].ToString(),
                    Author = collection["author"].ToString(),
                    Description = collection["description"].ToString(),
                    Genre = collection["genre"].ToString(),
                    Language = collection["ddlLanguage"].ToString(),
                };

                await ApiClientFactory.Instance.CreateBook(command);

                return RedirectToAction(nameof(Index), new { crud = (int)EnumCrud.Created });
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [ClaimsAuthorize(ClaimType.Book, Claim.Update)]
        public async Task<ActionResult> Update(IFormCollection collection)
        {
            var command = new BookModel.CreateUpdateBookCommand
            {
                Id = Convert.ToInt32(collection["updateBookId"]),
                Title = collection["title"].ToString(),
                Author = collection["author"].ToString(),
                Description = collection["description"].ToString(),
                Genre = collection["genre"].ToString(),
                Language = collection["ddlLanguageUpdate"].ToString(),
            };

            await ApiClientFactory.Instance.UpdateBook(command.Id, command);

            return RedirectToAction(nameof(Index), new { crud = (int)EnumCrud.Updated });
        }

        [ClaimsAuthorize(ClaimType.Book, Claim.Delete)]
        public ActionResult Delete(int id)
        {
            try
            {
                ApiClientFactory.Instance.DeleteBook(id);
                return RedirectToAction(nameof(Index), new { crud = (int)EnumCrud.Deleted });
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [ClaimsAuthorize(ClaimType.Book, Claim.Update)]
        public ActionResult Rent(int id)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                var command = new BookModel.CreateBookRentalCommand()
                {
                    BookId = id,
                    RentalDate = DateTime.Now.ToString("yyyy-MM-dd"),
                    UserId = userId
                };

                ApiClientFactory.Instance.RentBook(command);
                return RedirectToAction(nameof(Index), new { notify = (int)EnumNotify.Success, message = "Book successfully rented" });
            }
            catch(Exception e)
            {
                return RedirectToAction(nameof(Index), new { notify = (int)EnumNotify.Error, message = e.Message });
            }
        }

        #endregion

        #region Get Methods

        [HttpGet]
        [ClaimsAuthorize(ClaimType.Book, Claim.Read)]
        public async Task<JsonResult> GetBookById(int id)
        {
            try
            {
                var book = ApiClientFactory.Instance.GetBookById(id);
                var languages = new SelectList(ApiClientFactory.Instance.GetLanguages(), "Code", "Language", book.Code);

                var result = new BookModel();
                result.Book = book;
                result.ListLanguage = languages;

                return await Task.FromResult(Json(result));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(Json(ex.Message));
            }
        }

        #endregion

    }
}