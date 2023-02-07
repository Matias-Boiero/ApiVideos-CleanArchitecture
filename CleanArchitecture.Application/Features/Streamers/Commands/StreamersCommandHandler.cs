using AutoMapper;
using CleanArchitecture.Application.Contracts.Models;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Contracts.Services;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Streamers.Commands
{
    public class StreamersCommandHandler : IRequestHandler<StreamersCommand, int>
    {
        private readonly IStreamerRepository _streamerRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger _logger;

        public StreamersCommandHandler(IStreamerRepository streamerRepository, IMapper mapper,
            IEmailService emailService, ILogger logger)
        {
            _streamerRepository = streamerRepository;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<int> Handle(StreamersCommand request, CancellationToken cancellationToken)
        {
            var streamerEntity = _mapper.Map<Streamer>(request);
            var newStreamer = await _streamerRepository.AddAsync(streamerEntity);

            _logger.LogInformation($"Streamer {newStreamer.Id} fue creado exitosamente");
            await SendEmail(newStreamer);
            return newStreamer.Id;
        }

        // Correo electronico 
        private async Task SendEmail(Streamer streamer)
        {
            var email = new Email
            {
                EmailTo = "diez.guitarras@gmail.com",
                Subject = "Mensaje de alerta",
                Body = "La compañia de streamer se creo correctamente"
            };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al enviar el email de {streamer.Id}");
            }

        }
    }
}
