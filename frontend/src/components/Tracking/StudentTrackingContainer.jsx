import { useEffect, useState } from "react";
import * as signalR from "@microsoft/signalr";
import MapComponent from "../Map/MapComponent";

function StudentTrackingContainer() {
    const [students, setStudents] = useState([]);

    const updateStudentLocation = (update) => {
        setStudents((prev) => {
            const exists = prev.find((s) => s.id === update.id);

            if (exists) {
                return prev.map((s) =>
                    s.id === update.id
                        ? { ...s, lat: update.lat, lng: update.lng }
                        : s
                );
            } else {
                return [...prev, update];
            }
        });
    };

    useEffect(() => {
        const connection = new signalR.HubConnectionBuilder()
            .withUrl("https://localhost:7115/locationHub")
            .withAutomaticReconnect()
            .build();

        connection.start()
            .then(() => {
                console.log("SignalR Connected");
            })
            .catch((err) => console.error("Connection error:", err));

        connection.on("ReceiveLocation", (data) => {
            console.log("Received:", data);
            updateStudentLocation(data);
        });

        return () => {
            connection.stop();
        };
    }, []);

    return <MapComponent students={students} />;
}

export default StudentTrackingContainer;