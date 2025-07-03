using UnityEngine;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;

public class TcpServidor : MonoBehaviour
{
    private TcpListener server;
    private Thread serverThread;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    /*void Start()
    {
        serverThread = new Thread(ThreadStart(StartServer));
        serverThread.IsBackground = true;
        serverThread.Start();
    }
    void StartServer()
    {
        server = new TcpListener(IPAdress.Any, 8080);
        server.Start();
        Debug.Log("O Servidor está ouvindo da porta 8080");

        while (true)
        {
            TcpClient client = server.AcceptTcpClient;
        }
    }*/
}
