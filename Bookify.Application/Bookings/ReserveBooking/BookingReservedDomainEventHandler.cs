using Bookify.Application.Abstractions;
using Bookify.Domain.Bookings;
using Bookify.Domain.Bookings.Events;
using Bookify.Domain.Users;
using MediatR;

namespace Bookify.Application.Bookings.ReserveBooking;

internal sealed class BookingReservedDomainEventHandler : INotificationHandler<BookingReservedDomainEvent>
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IUserRepository _userReposioty;
    private readonly IEmailService _emailservice;

    public BookingReservedDomainEventHandler(IBookingRepository bookingRepository,
                                             IUserRepository userReposioty,
                                             IEmailService emailservice)
    {
        _bookingRepository = bookingRepository;
        _userReposioty = userReposioty;
        _emailservice = emailservice;
    }

    public async Task Handle(BookingReservedDomainEvent notification, CancellationToken cancellationToken)
    {
        var booking = await _bookingRepository.GetByIdAsync(notification.BookingId);

        if (booking == null) 
        {
            return;
        }

        var user = await _userReposioty.GetByIdAsync(booking.UserId, cancellationToken);

        if(user == null) 
        {  
            return; 
        }

        await _emailservice.SendAsync(user.Email, "Booking Reserved", "You have 10 minutes to confirm this booking");
    }
}
