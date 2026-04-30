using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocationSimulator.Models;


namespace LocationSimulator.Services
{
    class SignalRService
    {
        private readonly List<SimulatedStudent> _students;
        private readonly Random _rnd = new();

        public SignalRService(List<SimulatedStudent> students)
        {
            _students = students;
        }

        public async Task<HubConnection> Connect()
        {
            var connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7115/locationHub")
                .WithAutomaticReconnect()
                .Build();

            connection.On<string>("NewStudent", (studentId) =>
            {
                Console.WriteLine($"New student arrived: {studentId}");

                _students.Add(new SimulatedStudent
                {
                    Id = studentId,
                    Lat = 31.7683 + (_rnd.NextDouble() - 0.5) * 0.02,
                    Lng = 35.2137 + (_rnd.NextDouble() - 0.5) * 0.02
                });
            });

            await connection.StartAsync();

            Console.WriteLine("Connected to SignalR");

            return connection;
        }
    }
}
