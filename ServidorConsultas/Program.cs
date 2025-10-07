using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;

class ServidorInventario
{
    private static TcpListener listener;
    private static bool running = true;
    private const int puerto = 5001; // Puerto fijo

    static void Main(string[] args)
    {
        listener = new TcpListener(IPAddress.Any, puerto);
        listener.Start();

        Console.WriteLine("=== Servidor de Inventario HW/SW ===");
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

                if (usuario == null)
                {
                    usuario = mensaje;
                    Console.WriteLine($"El cliente se identificó como: {usuario}");
                    string saludo = $"Bienvenido {usuario}, puedes usar comandos como info, cpu, memoria, disco, etc.\n";
                    byte[] dataSaludo = Encoding.UTF8.GetBytes(saludo);
                    stream.Write(dataSaludo, 0, dataSaludo.Length);
                }
                else
                {
                    string comando = mensaje.ToLower();
                    Console.WriteLine($"[{usuario}] pidió: {comando}");

                    string respuesta = EjecutarComando(comando);

                    byte[] data = Encoding.UTF8.GetBytes(respuesta + "\n");
                    stream.Write(data, 0, data.Length);
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
            Console.WriteLine($"Cliente {usuario} desconectado.");
        }
    }

    private static string EjecutarComando(string comando)
    {
        switch (comando)
        {
            case "info":
                return ObtenerInfoGeneral();

            case "cpu":
                return ObtenerCPU();

            case "memoria":
                return ObtenerMemoria();

            case "disco":
                return ObtenerDisco();

            case "filesystem":
                return ObtenerFileSystem();

            case "load":
                return ObtenerLoadAverage();

            case "particiones":
                return ObtenerParticiones();

            case "so":
                return $"Sistema operativo - {RuntimeInformation.OSDescription}";

            case "interfaces":
                return ObtenerInterfaces();

            case "procesos":
                return ObtenerProcesos();

            case "hostname":
                return $"Hostname - {Dns.GetHostName()}";

            default:
                return "Comando no reconocido. Usa: info, cpu, memoria, disco, filesystem, load, particiones, so, interfaces, procesos, hostname";
        }
    }

    // =============================
    // Métodos multiplataforma
    // =============================

    private static string ObtenerInfoGeneral()
    {
        // Combina todas las secciones usando los métodos revisados
        return $"{ObtenerCPU()}\n\n{ObtenerMemoria()}\n\n{ObtenerDisco()}\n\n{ObtenerFileSystem()}\n\n{ObtenerLoadAverage()}\n\n{ObtenerInterfaces()}\n\nSistema operativo - {RuntimeInformation.OSDescription}\nHostname - {Dns.GetHostName()}";
    }


    private static string ObtenerCPU()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            return $"Procesadores - {Environment.ProcessorCount} núcleos lógicos";
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            return EjecutarComandoShell("cat /proc/cpuinfo | grep 'model name' | uniq");
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            return EjecutarComandoShell("sysctl -n machdep.cpu.brand_string");
        }
        return $"Procesadores - {Environment.ProcessorCount}";
    }

    private static string ObtenerMemoria()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            try
            {
                string ramInfo = EjecutarComandoShell("wmic OS get TotalVisibleMemorySize,FreePhysicalMemory /Value").Replace("=", " - ");
                string cacheInfo = EjecutarComandoShell("wmic cpu get L2CacheSize,L3CacheSize /Value").Replace("=", " - ");
                return $"RAM (KB)\n{ramInfo}\nCache CPU (KB)\n{cacheInfo}";
            }
            catch (Exception ex)
            {
                return $"Error obteniendo memoria en Windows - {ex.Message}";
            }
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            return EjecutarComandoShell("free -h");
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            return EjecutarComandoShell("vm_stat");
        }
        return "Memoria no disponible.";
    }

    private static string ObtenerDisco()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            string salida = EjecutarComandoShell("wmic logicaldisk get Caption,FreeSpace,Size");
            var lineas = salida.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var sb = new StringBuilder();

            // Ignorar encabezado
            for (int i = 1; i < lineas.Length; i++)
            {
                var partes = lineas[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (partes.Length >= 3)
                {
                    // Reemplazamos ":" por "" para evitar conflicto en el cliente
                    string unidad = partes[0].Replace(":", "");
                    sb.AppendLine($"[DISCO] Unidad - {unidad}  Espacio libre - {partes[1]}  Tamaño - {partes[2]}");
                }
            }
            return sb.Length == 0 ? "Sin resultados" : sb.ToString();
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            return EjecutarComandoShell("df -h --total");
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            return EjecutarComandoShell("df -h");
        }
        return "Estado de disco no disponible.";
    }

    private static string ObtenerFileSystem()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            string salida = EjecutarComandoShell("wmic logicaldisk get Caption,FileSystem");
            var lineas = salida.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var sb = new StringBuilder();

            // Ignorar encabezado
            for (int i = 1; i < lineas.Length; i++)
            {
                var partes = lineas[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (partes.Length >= 2)
                {
                    string unidad = partes[0].Replace(":", "");
                    sb.AppendLine($"[FILESYSTEM] Unidad - {unidad}  FileSystem - {partes[1]}");
                }
            }
            return sb.Length == 0 ? "Sin resultados" : sb.ToString();
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            return EjecutarComandoShell("df -T");
        }
        return "Filesystem no disponible.";
    }



    private static string ObtenerLoadAverage()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            return EjecutarComandoShell("cat /proc/loadavg");
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            return EjecutarComandoShell("uptime");
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            try
            {
                return EjecutarComandoShell("wmic cpu get loadpercentage /value").Replace("=", " - ");
            }
            catch (Exception ex)
            {
                return $"Error obteniendo carga en Windows - {ex.Message}";
            }
        }
        return "Load Average no disponible en este SO.";
    }

    private static string ObtenerParticiones()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            return EjecutarComandoShell("lsblk");
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            return EjecutarComandoShell("wmic partition get Name,Size").Replace("=", " - ");
        }
        return "Particiones no disponibles.";
    }

    private static string ObtenerInterfaces()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            string salida = EjecutarComandoShell("ipconfig");
            var lineas = salida.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var sb = new StringBuilder();
            foreach (var linea in lineas)
            {
                sb.AppendLine(linea.Replace(":", " - ").Trim());
            }
            return sb.ToString();
        }
        else
        {
            return EjecutarComandoShell("ip address");
        }
    }


    private static string ObtenerProcesos()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            return EjecutarComandoShell("tasklist");
        }
        else
        {
            return EjecutarComandoShell("ps -e");
        }
    }

    // Ejecuta un comando de consola y devuelve la salida
    private static string EjecutarComandoShell(string comando)
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

            Process process = Process.Start(psi);
            string result = process.StandardOutput.ReadToEnd();
            return string.IsNullOrWhiteSpace(result) ? "Sin resultados" : result.Trim();
        }
        catch (Exception ex)
        {
            return $"Error ejecutando comando - {ex.Message}";
        }
    }
}
