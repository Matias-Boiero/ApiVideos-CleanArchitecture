using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using MediatR;

namespace CleanArchitecture.Application.Features.Videos.Querys.GetVideosList
{
    public class GeVideosListQueryHandler : IRequestHandler<GeVideosListQuery, List<VideosVM>>
    {
        private readonly IVideoRepository _videoRepository;
        private readonly IMapper _mapper;

        public GeVideosListQueryHandler(IVideoRepository videoRepository, IMapper mapper)
        {
            _videoRepository = videoRepository;
            _mapper = mapper;
        }
        public async Task<List<VideosVM>> Handle(GeVideosListQuery request, CancellationToken cancellationToken)
        {
            var videoList = await _videoRepository.GetVideoByUserName(request._UserName);
            return _mapper.Map<List<VideosVM>>(videoList);
        }
    }
}
