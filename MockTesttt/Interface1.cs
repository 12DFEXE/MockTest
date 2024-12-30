using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MockTesttt
{
    public interface Interfaceparabooking
    {
        Task<List<Booking>> GetBookingIdsAsync
            (string? firstname = null, //Todos los parámetros tienen valores predeterminados de null, lo que significa que el llamador puede optar por no proporcionar alguno de estos valores, y el método seguirá funcionando
             string? lastname = null, 
             string? checkin = null,
             string? checkout = null); // Task indica que es un método asíncrono y el List<Booking> es el tipo de datos que se devolverá cuando la operación asíncrona se complete. Esto significa que este método devolverá una lista de objetos Booking dentro de una tarea que se puede esperar (await) de manera asíncrona

    }

    public class Booking
    {
        public int BookingId { get; set; } //{ get; set; }: Son las funciones automáticas de getter y setter.
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }//Esto significa que la propiedad tiene acceso para ser leída (get) y escrita (set) directamente desde fuera de la clase. El uso de { get; set; } es una forma simplificada de crear propiedades
                                           //en C# sin necesidad de implementar manualmente los métodos de acceso.
    }
}
