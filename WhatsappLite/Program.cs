using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class ClienteChatConsola
{
    private static TcpClient client;
    private static NetworkStream stream;
    private static string userName;

    static void Main(string[] args)
    {
        Console.Write("Ingrese la IP del servidor: ");
        string ip = Console.ReadLine();

        Console.Write("Ingrese el puerto: ");
        int port = int.Parse(Console.ReadLine());

        Console.Write("Ingrese su nombre de usuario: ");
        userName = Console.ReadLine();

        try
        {
            client = new TcpClient(ip, port);
            stream = client.GetStream();

            // Enviar nombre de usuario al servidor
            byte[] data = Encoding.UTF8.GetBytes(userName);
            stream.Write(data, 0, data.Length);

            Console.WriteLine($"*** Conectado al servidor {ip}:{port} como {userName} ***");

            // Iniciar hilo para escuchar mensajes
            Thread escuchar = new Thread(EscucharMensajes);
            escuchar.Start();

            // Bucle principal: leer mensajes del usuario y enviarlos
            string mensaje;
            while ((mensaje = Console.ReadLine()) != null)
            {
                if (mensaje == "/quitar")
                {
                    Console.WriteLine("*** Desconectado ***");
                    break;
                }

                byte[] msg = Encoding.UTF8.GetBytes(mensaje);
                stream.Write(msg, 0, msg.Length);
            }

            Desconectar();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error de conexión: {ex.Message}");
        }
    }

    private static void EscucharMensajes()
    {
        try
        {
            byte[] buffer = new byte[1024];
            int bytesRead;

            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
            {
                string mensaje = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine(mensaje);
            }
        }
        catch
        {
            Console.WriteLine("*** Se perdió la conexión con el servidor ***");
        }
    }

    private static void Desconectar()
    {
        try
        {
            stream?.Close();
            client?.Close();
        }
        catch { }
    }
}
