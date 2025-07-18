/*using UnityEngine;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;

public class TcpServerUnity : MonoBehaviour
{
    private TcpListener server;
    private Thread serverThread;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        serverThread = new Thread(new ThreadStart(StartServer));
        serverThread.IsBackground = true;
        serverThread.Start();
    }
    void StartServer()
    {
        server = new TcpListener(IPAddress.Any, 8080);
        server.Start();
        //Debug.Log("O Servidor está ouvindo da porta 8080");

        while (true)
        {
            TcpClient client = server.AcceptTcpClient();
            NetworkStream stream = client.GetStream();
            
            byte[] buffer = new byte[1024];
            int len = stream.Read(buffer, 0, buffer.Length);
            string msg = Encoding.UTF8.GetString(buffer, 0, len);
            Debug.Log($"[Servidor] Mensagem recebida: {msg}");
            
            stream.Close();
            client.Close();
        }
    }

    void OnApplicationQuit()
    {
        server?.Stop();
        serverThread?.Abort();
    }
}*/

