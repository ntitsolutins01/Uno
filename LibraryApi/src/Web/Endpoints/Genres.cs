using LibraryApi.Application.Genres.Commands.CreateGenre;
using LibraryApi.Application.Genres.Commands.DeleteGenre;
using LibraryApi.Application.Genres.Commands.UpdateGenre;
using LibraryApi.Application.Genres.Queries;
using LibraryApi.Application.Genres.Queries.GetGenreById;
using LibraryApi.Application.Genres.Queries.GetGenresAll;

namespace DnaBrasilApi.Web.Endpoints;
/// <summary>
/// Api de Genre
/// </summary>
public class Genres : EndpointGroupBase
{
    #region MapEndpoints

    /// <summary>
    /// Mapeamento dos Endpoints
    /// </summary>
    /// <param name="app">Objeto usado para configurar as rotas e os http pipelines</param>
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetGenresAll)
            .MapPost(CreateGenre)
            .MapPut(UpdateGenre, "{id}")
            .MapDelete(DeleteGenre, "{id}")
            .MapGet(GetGenreById, "{id}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de Genero
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão de Genero</param>
    /// <returns>Retorna Id de novo Genero</returns>
    public async Task<int> CreateGenre(ISender sender, CreateGenreCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de Genero
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração de Genero</param>
    /// <param name="command">Objeto de alteração da Genero</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateGenre(ISender sender, int id, UpdateGenreCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para exclusão de Genero
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusão da Genero</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteGenre(ISender sender, int id)
    {
        return await sender.Send(new DeleteGenreCommand(id));
    }
    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca todos os Genero cadastrados
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de Genero</returns>
    public async Task<List<GenresDto>> GetGenresAll(ISender sender)
    {
        return await sender.Send(new GetGenresAllQuery());
    }

    /// <summary>
    /// Endpoint que busca um único Genero
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de Genero a ser buscado</param>
    /// <returns>Retorna o objeto de Genero </returns>
    public async Task<GenresDto> GetGenreById(ISender sender, int id)
    {
        return await sender.Send(new GetGenreByIdQuery() { Id = id });
    }
    #endregion
}
