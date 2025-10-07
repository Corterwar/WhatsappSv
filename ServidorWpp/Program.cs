//Incluimos las librerias necesarias para el servidor web socket
using System;                           // Librería base de .NET (manejo general del sistema)
using System.Collections.Generic;       // Permite usar colecciones genéricas (List, Dictionary)
using System.Net;                       // Permite trabajar con direcciones IP
using System.Net.Sockets;               // Permite crear servidores y clientes TCP/UDP
using System.Threading;                 // Permite manejar múltiples hilos de ejecución
using System.Text;                      // Permite convertir texto a bytes y viceversa
// Clase principal que define el servidor de chat
class ChatServer
{
    private static TcpListener server; // Variable para escuchar las peticiones de los clientes (servidor TCP)
    private static List<TcpClient> clients = new List<TcpClient>(); // Lista que contiene todos los clientes conectados
    private static Dictionary<TcpClient, string> clientNames = new Dictionary<TcpClient, string>(); // Diccionario que asocia cada cliente con un nombre (como una base de datos simple)

    static void Main(string[] args)
    {
        int port = 5000; // Puerto en el que se ejecutará el servidor
        server = new TcpListener(IPAddress.Any, port); // Crea el servidor para aceptar conexiones desde cualquier IP
        server.Start(); // Inicia la escucha de conexiones entrantes

        // Muestra información del servidor
        Console.WriteLine($"Servidor iniciado en dirección: {GetLocalIPAddress()}");
        Console.WriteLine($"Servidor iniciado en puerto: {port}");

        // Bucle infinito que acepta clientes y los maneja en hilos separados
        while (true)    // Escucha continuamente las peticiones de nuevos clientes
        {
            // Espera (bloquea) hasta que un cliente se conecte
            TcpClient client = server.AcceptTcpClient();

            // Agrega el cliente a la lista de clientes de forma segura
            lock (clients) clients.Add(client); // "lock" evita que otros hilos modifiquen la lista al mismo tiempo

            // Obtiene la dirección IP y el puerto del cliente conectado
            IPEndPoint remoteEndPoint = client.Client.RemoteEndPoint as IPEndPoint;
            Console.WriteLine($"Cliente conectado desde {remoteEndPoint.Address}:{remoteEndPoint.Port}");

            // Crea un nuevo hilo para manejar la comunicación con este cliente
            Thread thread = new Thread(ManejarCliente);
            thread.Start(client); // Inicia el hilo y le pasa el cliente como parámetro
        }
    }

    // Método que se ejecuta en un hilo separado para cada cliente
    private static void ManejarCliente(object obj)
    {
        TcpClient client = (TcpClient)obj; // Convierte el objeto recibido en un TcpClient
        NetworkStream stream = client.GetStream(); // Obtiene el flujo de datos entre cliente y servidor

        byte[] buffer = new byte[1024]; // Buffer para recibir datos
        int bytesRead; // Variable para guardar la cantidad de bytes leídos

        try
        {
            // El primer mensaje que envía el cliente se considera su nombre de usuario
            bytesRead = stream.Read(buffer, 0, buffer.Length);
            string userName = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim(); // Convierte los bytes a texto
            lock (clientNames) clientNames[client] = userName; // Asigna el nombre al cliente en el diccionario

            Console.WriteLine($"Usuario asignado: {userName}");

            // Notifica a todos los demás clientes que un nuevo usuario se ha unido
            Broadcast($"*** {userName} se ha unido al chat ***", client);

            // Bucle que escucha continuamente los mensajes del cliente
            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
            {
                // Convierte el mensaje recibido a texto
                string message = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();

                // Si el mensaje comienza con "/", se trata de un comando
                if (message.StartsWith("/"))
                {
                    ProcesarComando(message, client); // Procesa el comando del usuario
                }
                else
                {
                    // Muestra el mensaje en consola y lo reenvía a todos los usuarios
                    Console.WriteLine($"{userName}: {message}");
                    Broadcast($"{userName}: {message}", client);
                }
            }
        }
        catch
        {
            // Si ocurre un error (por ejemplo, el cliente se desconecta), se informa en la consola
            if (clientNames.ContainsKey(client))
                Console.WriteLine($"{clientNames[client]} se ha desconectado.");
        }
        finally
        {
            // Limpieza final: elimina el cliente de las listas y notifica su salida
            lock (clients) clients.Remove(client); // Elimina de la lista de clientes
            if (clientNames.ContainsKey(client))
            {
                // Notifica a los demás usuarios que este cliente ha salido
                Broadcast($"*** {clientNames[client]} ha salido del chat ***", client);
                clientNames.Remove(client); // Elimina su nombre del diccionario
            }
            client.Close(); // Cierra la conexión TCP del cliente
        }
    }

    // Método que analiza los comandos enviados por los usuarios
    private static void ProcesarComando(string comando, TcpClient client)
    {
        // Obtiene el nombre del usuario o "Desconocido" si no se encuentra
        string user = clientNames.ContainsKey(client) ? clientNames[client] : "Desconocido";

        // Comando para listar usuarios conectados
        if (comando.Equals("/Listar", StringComparison.OrdinalIgnoreCase))
        {
            string lista;
            lock (clientNames)
            {
                // Construye una lista de los nombres de los usuarios conectados
                lista = "Usuarios conectados:\n - " + string.Join("\n - ", clientNames.Values);
            }
            EnviarPrivado($"*** {lista} ***", client); // Envía la lista al usuario que lo solicitó
        }
        // Comando para desconectarse del servidor
        else if (comando.Equals("/Quit", StringComparison.OrdinalIgnoreCase))
        {
            EnviarPrivado("*** Te has desconectado del servidor ***", client); // Mensaje de despedida
            client.Close(); // Cierra la conexión
        }
        // Si el comando no se reconoce, se informa al usuario
        else
        {
            EnviarPrivado($"*** Comando no reconocido: {comando} ***", client);
        }
    }

    // Envía un mensaje privado a un solo cliente
    private static void EnviarPrivado(string mensaje, TcpClient client)
    {
        try
        {
            byte[] data = Encoding.UTF8.GetBytes(mensaje); // Convierte el texto en bytes
            client.GetStream().Write(data, 0, data.Length); // Envía los bytes por el flujo de red
        }
        catch
        {
            // Si ocurre un error (por ejemplo, el cliente ya cerró la conexión), se ignora
        }
    }

    // Envía un mensaje a todos los clientes conectados
    private static void Broadcast(string message, TcpClient sender)
    {
        byte[] data = Encoding.UTF8.GetBytes(message); // Convierte el mensaje a bytes
        lock (clients) // Bloquea la lista mientras se envía a todos
        {
            foreach (var client in clients)
            {
                try
                {
                    client.GetStream().Write(data, 0, data.Length); // Envía el mensaje a cada cliente
                }
                catch
                {
                    // Si algún cliente no responde, se ignora el error
                }
            }
        }
    }

    // Método auxiliar para obtener la IP local de la máquina donde corre el servidor
    private static string GetLocalIPAddress()
    {
        string localIP = "127.0.0.1"; // Valor por defecto (localhost)
        foreach (var ip in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
        {
            // Busca la primera dirección IPv4 válida del equipo
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                localIP = ip.ToString();
                break;
            }
        }
        return localIP; // Devuelve la IP encontrada
    }
}
