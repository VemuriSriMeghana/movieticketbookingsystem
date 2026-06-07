﻿using MOVIETICKETBOOKINGSYSTEM.Exceptions;
using MOVIETICKETBOOKINGSYSTEM.Interfaces;
using MOVIETICKETBOOKINGSYSTEM.Models;
using MOVIETICKETBOOKINGSYSTEM.Services;

namespace MOVIETICKETBOOKINGSYSTEM;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Program Started");
        try
        {
            Movie movie = new Movie(1, "OG", "Telugu", 180);

            Theater theater = new Theater(1, "PSX", "Hyderabad");

            Show show = new Show(1, movie, theater, DateTime.Now.AddHours(2));

            Booking booking = new Booking(101, "Neelapu", show, 4, 800);

            IPaymentService paymentService = new UpiPaymentService();
            INotificationService notificationService = new EmailNotificationService();

            FileService fileService = new FileService();

            BookingService bookingService = new BookingService(paymentService, notificationService, fileService);

            bookingService.BookTicket(booking);
            fileService.DisplayBookingHistory();

        }
        catch (BookingException ex)
        {
            Console.WriteLine($"Booking Error : {ex}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"System Error: {ex}");
        }
        finally
        {
            Console.WriteLine("\nApplication Closed");
        }

    }
}
