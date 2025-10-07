import socket
import threading
import time

class ClienteChatConsola:
    def __init__(self, username):
        self.username = username
        self.client = None
        self.running = True
        self.connected = False

    def conectar(self, ip, port):
        while not self.connected and self.running:
            try:
                self.client = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
                self.client.connect((ip, port))
                self.client.send(self.username.encode("utf-8"))
                print(f"*** Conectado al servidor {ip}:{port} como {self.username} ***")
                self.connected = True

                # Hilo para escuchar mensajes
                threading.Thread(target=self.escuchar_mensajes, daemon=True).start()
            except Exception as e:
                print(f"No se pudo conectar al servidor: {e}")
                ip = input("Ingrese nuevamente la IP del servidor: ")
                port = int(input("Ingrese nuevamente el puerto: "))

    def escuchar_mensajes(self):
        try:
            while self.running and self.connected:
                try:
                    data = self.client.recv(1024)
                    if not data:
                        print("*** Servidor ha cerrado la conexion ***")
                        self.connected = False
                        break
                    print(data.decode("utf-8"))
                except (ConnectionResetError, OSError):
                    print("*** Se perdio la conexion con el servidor ***")
                    self.connected = False
                    break
        except Exception as e:
            print(f"Error en hilo de escucha: {e}")
            self.connected = False

    def enviar_mensajes(self):
        while self.running:
            try:
                mensaje = input()
                if mensaje == "/quitar":
                    print("*** Desconectado ***")
                    self.running = False
                    break

                if self.connected:
                    try:
                        self.client.send(mensaje.encode("utf-8"))
                    except (BrokenPipeError, ConnectionResetError):
                        print("*** No se pudo enviar el mensaje. Servidor desconectado ***")
                        self.connected = False
            except EOFError:
                self.running = False
                break

    def desconectar(self):
        try:
            if self.client:
                self.client.close()
        except Exception:
            pass
        finally:
            self.running = False
            self.connected = False


if __name__ == "__main__":
    username = input("Ingrese su nombre de usuario: ")
    cliente = ClienteChatConsola(username)

    ip = input("Ingrese la IP del servidor: ")
    port = int(input("Ingrese el puerto: "))
    cliente.conectar(ip, port)

    # Bucle principal para enviar mensajes
    cliente.enviar_mensajes()
    cliente.desconectar()
