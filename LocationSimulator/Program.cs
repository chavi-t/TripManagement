using LocationSimulator.NewFolder2;
using LocationSimulator.Models;
using LocationSimulator.Services;



    var students = new List<SimulatedStudent>();
    var http = new HttpClient();

    var api = new ApiService(http);
    var sim = new SimulationService(students);
    var signalR = new SignalRService(students);

    Console.WriteLine("Simulator started...");

    var data = await api.GetStudents();
    students.AddRange(data.Select(s => new SimulatedStudent
    {
        Id = s.studentId,
        Lat = 31.7683,
        Lng = 35.2137
    }));

    await signalR.Connect();

    while (true)
    {
        sim.MoveAll();

        foreach (var s in students)
        {
            var payload = sim.BuildPayload(s);
            await api.SendLocation(payload);

            Console.WriteLine($"{s.Id}: {s.Lat}, {s.Lng}");
        }

        await Task.Delay(5000);
    }
