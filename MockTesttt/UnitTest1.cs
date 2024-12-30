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
            var mockService = BookingServiceMock.GetMockedService();// se linkea con el Mock y a su vez el mock esta vinculado con la interface
            var service = mockService.Object;// la var service se convierte en un objeto de la clase mockService

            // Act
            var result = await service.GetBookingIdsAsync(); //Llama de forma asíncrona al método GetBookingIdsAsync y espera su resultado, que se guarda en la variable result.

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
            Assert.That(result.Count, Is.EqualTo(1)); // Espera que solo haya una reserva en la lista que tenga "John" como nombre de pila.
            Assert.AreEqual(2, result.First().BookingId);  // Verifica que el BookingId del primer elemento sea igual a 2
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
            Assert.That(result.First().BookingId, Is.EqualTo(2));  // La re33serva con BookingId = 2 (par)

        }

        [Test]
        public async Task GetBookingIdsAsync_WithFirstnameFilter_ReturnsFilteredBookingss()
        {
            // Arrange
            var mockService = BookingServiceMock.GetMockedService();
            var service = mockService.Object;

            // Act
            var result = await service.GetBookingIdsAsync(firstname: "John");

            // Assert
            Assert.That(result.Count, Is.EqualTo(1)); // ara verificar que hay exactamente un elemento en la lista.
            Assert.Equals(2, result.First().BookingId);  // La reserva con BookingId = 2 (par)
        }

    }

}