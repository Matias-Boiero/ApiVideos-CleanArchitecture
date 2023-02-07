using MediatR;

namespace CleanArchitecture.Application.Features.Videos.Querys.GetVideosList
{
    public class GeVideosListQuery : IRequest<List<VideosVM>>
    {
        public string? _UserName { get; set; }

        public GeVideosListQuery(string username)
        {
            //en caso que no exista lanzo una excepcion
            _UserName = username ?? throw new ArgumentNullException(nameof(username));
        }
    }
}
