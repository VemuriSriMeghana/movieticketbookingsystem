using System.Diagnostics;
using System.IO;

namespace MOVIETICKETBOOKINGSYSTEM.Services;

public class FileService
{
    private readonly string _filePath;

    public FileService()
    {
        Directory.CreateDirectory("Bookings");

        _filePath = Path.Combine("Bookings", "booking.txt");
    }

    public void SaveBooking(string bookingrecord)
    {
        File.AppendAllText(_filePath, bookingrecord + Environment.NewLine);

    }

    public void DisplayBookingHistory()
    {
        if (File.Exists(_filePath))
        {
            Console.WriteLine("\nBooking History");

            string content = File.ReadAllText(_filePath);

            Console.WriteLine(content);

        }
        else

        {

            Console.WriteLine("No Booking History Found");

        }


    }


}