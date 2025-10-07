using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Whatsappv2
{
    public class ClienteChat2
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
            byte[] buffer = new byte[4096];
            int bytesRead;

            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                string mensaje = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();

                if (mensaje.StartsWith("EJECUTAR:"))
                {
                    string comando = mensaje.Substring(8).Trim().ToLower();
                    string resultado = EjecutarComandoLocal(comando);

                    // Enviar resultado con prefijo
                    byte[] data = Encoding.UTF8.GetBytes("RESULTADO:" + resultado + "\n");
                    stream.Write(data, 0, data.Length);
                }

                else
                {
                    Console.WriteLine(mensaje); // Mostrar saludo o respuestas
                }
            }
        }



        private string EjecutarComandoLocal(string comando)
        {
            switch (comando)
            {
                case "cpu": return EjecutarComandoShell("wmic cpu get name");
                case "memoria": return EjecutarComandoShell("wmic OS get TotalVisibleMemorySize,FreePhysicalMemory /Value");
                case "disco": return EjecutarComandoShell("wmic logicaldisk get Caption,FreeSpace,Size");
                case "so": return Environment.OSVersion.ToString();
                case "hostname": return Dns.GetHostName();
                default: return "Comando no reconocido";
            }
        }



        private string EjecutarComandoShell(string comando)
        {
            try
            {
                string shell = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "cmd.exe" : "/bin/bash";
                string args = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "/C " + comando : "-c \"" + comando + "\"";

                var psi = new ProcessStartInfo
                {
                    FileName = shell,
                    Arguments = args,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                var process = Process.Start(psi);
                string result = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                return string.IsNullOrWhiteSpace(result) ? "Sin resultados" : result.Trim();
            }
            catch (Exception ex)
            {
                return $"Error ejecutando comando - {ex.Message}";
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
