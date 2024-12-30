using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MockTesttt
{

    public class BookingServiceMock

    {
        public static Mock<Interfaceparabooking> GetMockedService()
        {
            // Crear un mock de IBookingService
            var mockService = new Mock<Interfaceparabooking>();

            // Configurar que cuando se llame a GetBookingIdsAsync se devuelvan IDs de reserva
            mockService.Setup(service => service.GetBookingIdsAsync(It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync((string firstname, string lastname, string checkin, string checkout) =>
                {
                    var bookings = new List<Booking>
                    {
                new Booking { BookingId = 1 },
                new Booking { BookingId = 2, Firstname = "John", Lastname = "Doe" },
                new Booking { BookingId = 3 },
                new Booking { BookingId = 4 },
                    };





                    // Filtrar las reservas por los parámetros opcionales 
                    

                    if (!string.IsNullOrEmpty(firstname))
                    {
                        bookings = bookings.Where(b => b.Firstname == firstname).ToList();
                    }
                    
                    
                    


                    if (!string.IsNullOrEmpty(lastname))
                    {
                        bookings = bookings.Where(b => b.Lastname == lastname).ToList();
                    }

                    // Puedes añadir filtros adicionales por checkin, checkout, etc.

                    return bookings;
                });

            return mockService;
        }

    }
}