using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace obl_opg_5
{
    public class ClientHandler
    {
        public static void HandleClient(TcpClient client)
        {
            NetworkStream ns = client.GetStream();
            StreamReader reader = new StreamReader(ns);
            StreamWriter writer = new StreamWriter(ns);
            writer.AutoFlush = true;

            bool keepListening = true;

            string? message = reader.ReadLine();

            JsonModel? request = JsonSerializer.Deserialize<JsonModel>(message);
            Console.WriteLine($"Received: {message}");

            if (request.Method?.ToLower() == "add")
            {
                int addNumbers = (request.Number1 + request.Number2);
                JsonModel response = new JsonModel
                {
                    Method = "Add",
                    Number1 = request.Number1,
                    Number2 = request.Number2,
                    Result = addNumbers,
                };
                string resultAdd = JsonSerializer.Serialize(response);
                writer.Write(resultAdd);

            }

        }
    }
}
