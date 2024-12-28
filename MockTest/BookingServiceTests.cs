using MockTest;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MockTest
{
    public class BookingServiceTestsBookingServiceTests
{
    [Fact]
    public async Task GetBookingIdsAsync_WithNoFilters_ReturnsAllBookings()
    {
        // Arrange
        var mockService = BookingServiceMock.GetMockedService();
        var service = mockService.Object;

        // Act
        var result = await service.GetBookingIdsAsync();

        // Assert
        Assert.Equal(4, result.Count);  // Verifica que hay 4 reservas
        Assert.Contains(result, b => b.BookingId == 1);
        Assert.Contains(result, b => b.BookingId == 2);
        Assert.Contains(result, b => b.BookingId == 3);
        Assert.Contains(result, b => b.BookingId == 4);
    }

    [Fact]
    public async Task GetBookingIdsAsync_WithFirstnameFilter_ReturnsFilteredBookings()
    {
        // Arrange
        var mockService = BookingServiceMock.GetMockedService();
        var service = mockService.Object;

        // Act
        var result = await service.GetBookingIdsAsync(firstname: "John");

        // Assert
        Assert.Single(result); // Verifica que solo se devuelve una reserva (simulada)
        Assert.Equal(2, result.First().BookingId);  // La reserva con BookingId = 2 (par)
    }

    [Fact]
    public async Task GetBookingIdsAsync_WithLastnameFilter_ReturnsFilteredBookings()
    {
        // Arrange
        var mockService = BookingServiceMock.GetMockedService();
        var service = mockService.Object;

        // Act
        var result = await service.GetBookingIdsAsync(lastname: "Doe");

        // Assert
        Assert.Single(result); // Verifica que solo se devuelve una reserva (simulada)
        Assert.Equal(1, result.First().BookingId);  // La reserva con BookingId = 1 (impar)
    }
}
}