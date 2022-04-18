using MassTransit;
using Models;
using MediatR;

using System.Threading.Tasks;
using AutoMapper;
using System;

namespace NotificationService
{
    public class ProviderNotificationConsumer : IConsumer<ProviderNotificationDTO>
    {
        public static string received;

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProviderNotificationConsumer(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// To consume the Providers list for notification from Admin
        /// </summary>
        /// <param name="context"></param>
        public async Task Consume(ConsumeContext<ProviderNotificationDTO> context)
        {
            var command = _mapper.Map<ProviderNotificationDTO>(context.Message);
            var result = await _mediator.Send(command);
        }

    }
}
