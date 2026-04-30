using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocationSimulator.Models;


namespace LocationSimulator.NewFolder2
{
    class SimulationService
    {
        private readonly List<SimulatedStudent> _students;
        private readonly Random _rnd = new();

        public SimulationService(List<SimulatedStudent> students)
        {
            _students = students;
        }

        public void MoveAll()
        {
            foreach (var s in _students)
            {
                MoveStudent(s);
            }
        }

        private void MoveStudent(SimulatedStudent s)
        {
            double move = 0.0005;

            s.Lat += (_rnd.NextDouble() - 0.5) * move;
            s.Lng += (_rnd.NextDouble() - 0.5) * move;
        }

        public object BuildPayload(SimulatedStudent s)
        {
            return new
            {
                ID = s.Id,
                Coordinates = new
                {
                    Longitude = ToDms(s.Lng),
                    Latitude = ToDms(s.Lat)
                },
                Time = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ")
            };
        }

        private object ToDms(double value)
        {
            var degrees = (int)value;
            var minutesFull = (value - degrees) * 60;
            var minutes = (int)minutesFull;
            var seconds = (minutesFull - minutes) * 60;

            return new
            {
                Degrees = degrees.ToString("00"),
                Minutes = minutes.ToString("00"),
                Seconds = seconds.ToString("00")
            };
        }
    }
}
