using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Collections.Generic;

class ServidorInventario2
{
    private static TcpListener listener;
    private static bool running = true;
    private const int puerto = 5001; // Puerto fijo
    private static Dictionary<TcpClient, string> clientes = new Dictionary<TcpClient, string>();

    static void Main(string[] args)
    {
        listener = new TcpListener(IPAddress.Any, puerto);
        listener.Start();

        Console.WriteLine("=== Servidor de Inventario Cliente Activo ===");
        Console.WriteLine($"Servidor iniciado en puerto {puerto}");

        // Mostrar todas las IPs locales
        string hostname = Dns.GetHostName();
        var direcciones = Dns.GetHostAddresses(hostname);
        Console.WriteLine("Direcciones IP disponibles:");
        foreach (var ip in direcciones)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
                Console.WriteLine($"  -> {ip}");
        }

        Console.WriteLine("Esperando clientes...\n");

        while (running)
        {
            TcpClient client = listener.AcceptTcpClient();
            Console.WriteLine("Cliente conectado.");

            Thread t = new Thread(ManejarCliente);
            t.Start(client);
        }
    }

    private static void ManejarCliente(object obj)
    {
        TcpClient client = (TcpClient)obj;
        NetworkStream stream = client.GetStream();

        byte[] buffer = new byte[4096];
        int bytesRead;
        string usuario = null;

        try
        {
            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                string mensaje = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();

                // Primer mensaje = nombre de usuario
                if (usuario == null)
                {
                    usuario = mensaje;
                    lock (clientes) clientes[client] = usuario;

                    Console.WriteLine($"El cliente se identificó como: {usuario}");
                    string saludo = $"Bienvenido {usuario}. Envía comandos como cpu, memoria, disco, filesystem, load, particiones, so, interfaces, procesos, hostname";
                    byte[] dataSaludo = Encoding.UTF8.GetBytes(saludo + "\n");
                    stream.Write(dataSaludo, 0, dataSaludo.Length);
                }
                else
                {
                    if (mensaje.StartsWith("RESULTADO:"))
                    {
                        // Solo mostrar resultado enviado por el cliente
                        string resultado = mensaje.Substring(10); // Quitar "RESULTADO:"
                        Console.WriteLine($"[{usuario}] respondió:\n{resultado}");
                    }
                    else
                    {
                        Console.WriteLine($"[{usuario}] solicitó: {mensaje}");

                        string[] comandosValidos = { "cpu", "memoria", "disco", "so", "hostname" };
                        if (Array.Exists(comandosValidos, c => c == mensaje.ToLower()))
                        {
                            // Indicar al cliente que ejecute el comando localmente
                            string instruccion = $"EJECUTAR:{mensaje}";
                            byte[] data = Encoding.UTF8.GetBytes(instruccion + "\n");
                            stream.Write(data, 0, data.Length);
                        }
                        else
                        {
                            byte[] data = Encoding.UTF8.GetBytes("Comando no reconocido\n");
                            stream.Write(data, 0, data.Length);
                        }
                    }
                }

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error con cliente {usuario}: {ex.Message}");
        }
        finally
        {
            client.Close();
            lock (clientes) clientes.Remove(client);
            Console.WriteLine($"Cliente {usuario} desconectado.");
        }
    }
}
