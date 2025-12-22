using System.Net.Sockets;
using System.Text.Json;
using NewsApp.BLL.Network;
using NewsApp.Common;
using NewsApp.DAL;
using NewsApp.Data;

namespace NewsApp.BLL
{
    public class HandlerClientRequest
    {
        private readonly TcpClient _client;
        private readonly ServerSocket _serverSocket;
        private readonly NetworkStream _networkStream;
        private readonly StreamReader _streamReader;
        private readonly StreamWriter _streamWriter;

        private bool isConnected = true;

        // Các Repository làm việc với database
        private readonly IAccountRepository _accountRepository;
        private readonly ArticleRepository _articleRepository;

        private readonly UserRepository _userRepository;

        private readonly CategoryRepository _categoryRepository;
        private readonly CommentRepository _commentRepository;

        public HandlerClientRequest(TcpClient client, ServerSocket serverSocket)
        {
            _client = client;
            _serverSocket = serverSocket;
            _networkStream = _client.GetStream();
            _streamReader = new StreamReader(_networkStream);
            _streamWriter = new StreamWriter(_networkStream) { AutoFlush = true };
            _accountRepository = new AccountRepository();
            _articleRepository = new();
            _userRepository = new();
            _categoryRepository = new();
            _commentRepository = new();
        }

        // Hàm xử lý request của client
        public void HandleRequest()
        {
            try
            {
                while (isConnected && _client.Connected)
                {
                    string? request = _streamReader.ReadLine();
                    if (request == null)
                    {
                        Disconnect();
                        _serverSocket.Log($"[Client - INFO] Client {_client.Client.RemoteEndPoint} đã ngắt kết nối.");
                        break;
                    }

                    Packet? packet = JsonSerializer.Deserialize<Packet>(request);
                    if (packet == null)
                    {
                        _serverSocket.Log("[Client - ERROR] Request không hợp lệ.");
                        continue;
                    }


                    string clientEndPoint = _client.Client.RemoteEndPoint?.ToString() ?? "Unknown";
                    string displayUser = "Guest";


                    if (!string.IsNullOrEmpty(_currentUsername))
                    {
                        displayUser = _currentUsername;
                    }

                    else if (packet.Command == MessageProtocol.RequestCommand.LOGIN)
                    {
                        try
                        {
                            var accLogin = JsonSerializer.Deserialize<Account>(packet.Payload);
                            displayUser = $"{accLogin?.Username} (Login Request)";
                        }
                        catch { }
                    }
                    else if (packet.Command == MessageProtocol.RequestCommand.REGISTER)
                    {
                        try
                        {
                            var accReg = JsonSerializer.Deserialize<RegisterModel>(packet.Payload);
                            displayUser = $"{accReg?.Username} (Register Request)";
                        }
                        catch { }
                    }


                    string logMessage = $"[Request] [{clientEndPoint}] User: {displayUser} -> Command: {packet.Command}";

                    _serverSocket.Log(logMessage);

                    ProcessRequest(packet);
                }
            }
            catch (IOException ioe)
            {
                _serverSocket.Log($"[Client - ERROR] {ioe.Message}");
                Disconnect();
            }
        }
    }
