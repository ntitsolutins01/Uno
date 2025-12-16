using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebApp.Configuration;
using WebApp.Dto;
using WebApp.Enumerators;
using WebApp.Factory;
using WebApp.Models;
using WebApp.Utility;

namespace WebApp.Controllers
{
    /// <summary>
    /// Controle do Genero 
    /// </summary>
    public class GenreController : BaseController
    {
        #region Parametros

        private readonly ILog _logger;

        #endregion

        #region Constructor

        /// <summary>
        /// Construtor da página
        /// </summary>
        /// <param name="appSettings">configurações de urls do sistema</param>
        /// <param name="logger">Log de mensagens da aplicação</param>
        public GenreController(IOptions<UrlSettings> appSettings,
            ILog logger)
        {
            _logger = logger;
            ApplicationSettings.WebApiUrl = appSettings.Value.WebApiBaseUrl;
        }

        #endregion

        #region Main Methods

        /// <summary>
        ///  Listagem do Genero 
        /// </summary>
        /// <param name="crud">paramentro que indica o tipo de ação realizado</param>
        /// <param name="notify">parametro que indica o tipo de notificação realizada</param>
        /// <param name="message">mensagem apresentada nas notificações e alertas gerados na tela</param>
        public IActionResult Index(int? crud, int? notify, string message = null)
        {
            try
            {
                _logger.Info($"Usuario Logado em Genre.Index User.Identity.Name : {User.Identity.Name}");

                SetNotifyMessage(notify, message);
                SetCrudMessage(crud);
                var response = ApiClientFactory.Instance.GetGenresAll();

                return View(new GenreModel() { Genres = response });
            }
            catch (Exception e)
            {
                _logger.Error($"Genre.Index: {e.StackTrace}");
                return RedirectToRoute(new
                {
                    controller = "Home",
                    action = "Error",
                    message = e.Message,
                    stackTrace = e.StackTrace
                });
            }
        }

        /// <summary>
        /// Tela para Inclusão do Genero 
        /// </summary>
        /// <param name="crud">paramentro que indica o tipo de ação realizado</param>
        /// <param name="notify">parametro que indica o tipo de notificação realizada</param>
        /// <param name="message">mensagem apresentada nas notificações e alertas gerados na tela</param>
        /// <returns></returns>
        public ActionResult Create(int? crud, int? notify, string message = null)
        {
            SetNotifyMessage(notify, message);
            SetCrudMessage(crud);


            return View();
        }

        /// <summary>
        /// Ação de Inclusão do Genero 
        /// </summary>
        /// <param name="collection">coleção de dados para inclusao do Genero </param>
        /// <returns>retorna mensagem de inclusao através do parametro crud</returns>
        [HttpPost]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                var command = new GenreModel.CreateUpdateGenreCommand
                {
                    Name = collection["name"].ToString()
                };

                await ApiClientFactory.Instance.CreateGenre(command);

                return RedirectToAction(nameof(Index), new { crud = (int)EnumCrud.Created });
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        /// <summary>
        /// Ação de Alteração do Genero 
        /// </summary>
        /// <param name="collection">coleção de dados para alteração do Genero</param>
        /// <returns>retorna mensagem de alteração através do parametro crud</returns>
        public async Task<ActionResult> Update(IFormCollection collection)
        {
            var command = new GenreModel.CreateUpdateGenreCommand
            {
                Id = Convert.ToInt32(collection["updateGenreId"]),
                Name = collection["name"].ToString(),
            };

            await ApiClientFactory.Instance.UpdateGenre(command.Id, command);

            return RedirectToAction(nameof(Index), new { crud = (int)EnumCrud.Updated });
        }

        /// <summary>
        /// Ação de Exclusão do Genero 
        /// </summary>
        /// <param name="id">identificador do Genero </param>
        /// <returns>retorna mensagem de exclusão através do parametro crud</returns>
        public ActionResult Delete(int id)
        {
            try
            {
                ApiClientFactory.Instance.DeleteGenre(id);
                return RedirectToAction(nameof(Index), new { crud = (int)EnumCrud.Deleted });
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        #endregion

        #region Get Methods

        /// <summary>
        /// Busca Genero  por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<GenresDto> GetGenreById(int id)
        {
            var result = ApiClientFactory.Instance.GetGenreById(id);

            return Task.FromResult(result);
        }
    }

    #endregion


}
