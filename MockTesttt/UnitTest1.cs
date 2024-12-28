using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace MockTesttt
{
    public class BookingServiceTestsBookingServiceTests
    {
        [Test]
        public async Task GetBookingIdsAsync_WithNoFilters_ReturnsAllBookings()
        {
            // Arrange
            var mockService = BookingServiceMock.GetMockedService();
            var service = mockService.Object;

            // Act
            var result = await service.GetBookingIdsAsync();

            // Assert
            Assert.That(result.Count, Is.EqualTo(4));  // Verifica que hay 4 reservas
            Assert.IsTrue(result.Any(b => b.BookingId == 1)); // Verifica que hay una reserva con BookingId 1
            Assert.IsTrue(result.Any(b => b.BookingId == 2)); // Verifica que hay una reserva con BookingId 2
            Assert.IsTrue(result.Any(b => b.BookingId == 3)); // Verifica que hay una reserva con BookingId 3
            Assert.IsTrue(result.Any(b => b.BookingId == 4)); // Verifica que hay una reserva con BookingId 4
        }

        [Test]
        public async Task GetBookingIdsAsync_WithFirstnameFilter_ReturnsFilteredBookings()
        {
            // Arrange
            var mockService = BookingServiceMock.GetMockedService();
            var service = mockService.Object;

            // Act
            var result = await service.GetBookingIdsAsync(firstname: "John");

            // Assert
            Assert.That(result.Count, Is.EqualTo(1)); // ara verificar que hay exactamente un elemento en la lista.
            Assert.Equals(1, result.First().BookingId);  // La reserva con BookingId = 2 (par)
        }

        [Test]
        public async Task GetBookingIdsAsync_WithLastnameFilter_ReturnsFilteredBookings()
        {
            // Arrange
            var mockService = BookingServiceMock.GetMockedService();
            var service = mockService.Object;

            // Act
            var result = await service.GetBookingIdsAsync(lastname: "Doe");

            // Assert
            Assert.That(result.Count, Is.EqualTo(1));  // Verifica que solo se devuelve una reserva (simulada)
            Assert.That(result.First().BookingId, Is.EqualTo(2));  // La reserva con BookingId = 2 (par)

        }
    }

}