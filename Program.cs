namespace ConsoleApp1
{
    public interface INotificable
    {
        void Enviar(string mensaje);
    }

    public abstract class NotificationBase : INotificable
    {
        public string Destinatario { get; set; }

        public NotificationBase(string destinatario)
        {
            Destinatario = destinatario;
        }

        public virtual void Enviar(string mensaje)
        {
            Console.WriteLine($"Enviando mensaje a {Destinatario}: {mensaje}...");
        }
    }

    public class EmailNotificacion : NotificationBase
    {
        public EmailNotificacion(string email) : base(email) { }
        public override void Enviar(string mensaje)
        {
            Console.WriteLine($"📧 Enviando email a {Destinatario}: {mensaje}...");
        }
    }

    public class SmsNotificacion : NotificationBase
    {
        public SmsNotificacion(string sms) : base(sms) { }
        public override void Enviar(string mensaje)
        {
            Console.WriteLine($"📧 Enviando sms a {Destinatario}: {mensaje}...");
        }
    }

    public class PushNotificacion : NotificationBase
    {
        public PushNotificacion(string deviceId) : base(deviceId) { }
        public override void Enviar(string mensaje)
        {
            Console.WriteLine($"📧 Enviando notificación a {Destinatario}: {mensaje}");
        }
    }

    public class Log
    {
        public string Tipo { get; set; }
        public string Destinatario { get; set; }
        public string Mensaje { get; set; }
        public DateTime Fecha { get; set; }
    }

    internal class Program
    {
        static void Main()
        {
            List<Log> logs = new List<Log>();
            List<INotificable> notificaciones = new List<INotificable>
            {
                new EmailNotificacion("user@example.com"),
                new SmsNotificacion("+5491122334455"),
                new PushNotificacion("DeviceXYZ"),
            };

            while (true)
            {
                Console.WriteLine("Por favor ingresa el mensaje que deseas enviar (escribe 'salir' para finalizar):");
                var mensaje = Console.ReadLine();

                if (mensaje?.ToLower() == "salir")
                    break;

                foreach (var notificacion in notificaciones)
                {
                    notificacion.Enviar(mensaje);

                    var log = new Log()
                    {
                        Tipo = notificacion.GetType().Name,
                        Mensaje = mensaje,
                        Fecha = DateTime.Now,
                        Destinatario = ((NotificationBase)notificacion).Destinatario,
                    };

                    logs.Add(log);
                }
            }

            Console.WriteLine("\n--- Historial de mensajes enviados ---");
            foreach (var log in logs)
            {
                Console.WriteLine($"[LOG] {log.Fecha:G} | Tipo: {log.Tipo} | Destinatario: {log.Destinatario} | Mensaje: {log.Mensaje}");
            }

            Console.WriteLine("Programa finalizado. Presiona una tecla para salir...");
            Console.ReadKey();
        }
    }
}
