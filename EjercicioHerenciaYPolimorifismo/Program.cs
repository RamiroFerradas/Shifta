using NotificationsApp.Models;
using NotificationsApp.Notifications;

namespace NotificationsApp
{
    internal class Program
    {
        static void Main()
        {
            List<Log> logs = new List<Log>();
            List<INotificable> notifications = new List<INotificable>
            {
                new EmailNotification("usuario@ejemplo.com"),
                new SmsNotification("+5491122334455"),
                new PushNotification("DispositivoXYZ"),
                new SlackNotification("general")
            };

            while (true)
            {
                Console.WriteLine("Por favor, ingresa el mensaje que deseas enviar (escribí 'salir' para terminar):");
                var mensaje = Console.ReadLine();

                if (mensaje?.ToLower() == "salir")
                    break;

                foreach (var notification in notifications)
                {
                    notification.Send(mensaje);

                    logs.Add(new Log
                    {
                        Type = notification.GetType().Name,
                        Recipient = notification.Recipient,
                        Message = mensaje,
                        Date = DateTime.Now
                    });
                }
            }

            Console.WriteLine("\n--- Historial de mensajes enviados ---");
            foreach (var log in logs)
            {
                Console.WriteLine($"[LOG] {log.Date:G} | Tipo: {log.Type} | Destinatario: {log.Recipient} | Mensaje: {log.Message}");
            }

            Console.WriteLine("Programa finalizado. Presioná una tecla para salir...");
            Console.ReadKey();
        }
    }
}
