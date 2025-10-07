using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Whatsappv2
{
    public class ClienteChat
    {
        private TcpClient client;
        private NetworkStream stream;
        private Thread threadEscucha;

        public string UserName { get; private set; }
        public bool Conectado => client != null && client.Connected;

        // Eventos para notificar
        public event Action<string> OnMensajeRecibido;
        public event Action<string> OnError;

        public void Conectar(string ip, int puerto, string userName)
        {
            try
            {
                client = new TcpClient(ip, puerto);
                stream = client.GetStream();
                UserName = userName;

                // Enviar nombre de usuario al servidor
                byte[] data = Encoding.UTF8.GetBytes(UserName);
                stream.Write(data, 0, data.Length);

                // Hilo para escuchar mensajes
                threadEscucha = new Thread(EscucharMensajes);
                threadEscucha.IsBackground = true;
                threadEscucha.Start();
            }
            catch (SocketException)
            {
                OnError?.Invoke("No se pudo conectar al servidor. Verifica que esté en ejecución, la IP y el puerto sean correctos.");
            }
            catch (Exception ex)
            {
                OnError?.Invoke($"Error inesperado: {ex.Message}");
            }

        }

        public void EnviarMensaje(string mensaje)
        {
            if (!Conectado) return;

            try
            {
                byte[] data = Encoding.UTF8.GetBytes(mensaje);
                stream.Write(data, 0, data.Length);

                // Si el cliente se desconecta con /quitar, cerramos también
                if (mensaje.Trim().Equals("/quitar", StringComparison.OrdinalIgnoreCase))
                {
                    Desconectar();
                    OnError?.Invoke("Te has desconectado del servidor.");
                }
            }
            catch (Exception ex)
            {
                OnError?.Invoke($"Error al enviar mensaje: {ex.Message}");
                Desconectar();
            }
        }

        private void EscucharMensajes()
        {
            try
            {
                byte[] buffer = new byte[1024];
                int bytesRead;

                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    string mensaje = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    OnMensajeRecibido?.Invoke(mensaje);
                }
            }
            catch
            {
                OnError?.Invoke("Se perdió la conexión con el servidor.");
                Desconectar();
            }
        }

        public void Desconectar()
        {
            try
            {
                stream?.Close();
                client?.Close();
                client = null;
                stream = null;
            }
            catch { }
        }
    }
}
