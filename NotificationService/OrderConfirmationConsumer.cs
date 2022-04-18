using AutoMapper;
using MassTransit;
using MediatR;
using Models;
using System;
using System.Threading.Tasks;

namespace NotificationService
{
    [Serializable]
    public class OrderConfirmationConsumer : IConsumer<ServiceRequestDetails>
    {
        public static string received;

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OrderConfirmationConsumer(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// To consume the service request details (booking confirmation) for notification from Order management service
        /// </summary>
        /// <param name="context"></param>
        public async Task Consume(ConsumeContext<ServiceRequestDetails> context)
        {
            /*var receivedmessage = ((MassTransit.Context.ConsumeContextScope<ServiceRequestDetails>)context).Message;
            JavaScriptSerializer js = new JavaScriptSerializer();
            received = js.Serialize(receivedmessage);*/
            var command = _mapper.Map<ServiceRequestDetails>(context.Message);
            var result = await _mediator.Send(command);
        }
    }
}
