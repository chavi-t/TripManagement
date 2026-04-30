import { MapContainer, TileLayer, Marker, Popup } from "react-leaflet";
import "leaflet/dist/leaflet.css";
import L from "leaflet";
import { Tooltip } from "react-leaflet";
import "../../styles/map.css";

delete L.Icon.Default.prototype._getIconUrl;
L.Icon.Default.mergeOptions({
    iconRetinaUrl: require("leaflet/dist/images/marker-icon-2x.png"),
    iconUrl: require("leaflet/dist/images/marker-icon.png"),
    shadowUrl: require("leaflet/dist/images/marker-shadow.png"),
});

function MapComponent({ students }) {
    const center = [31.7683, 35.2137]; // ירושלים

    return (
        <div style={{ height: "500px", width: "100%" }}>
            <MapContainer center={center} zoom={13} style={{ height: "100%" }}>

                {/* מפה */}
                <TileLayer
                    url="https://{s}.basemaps.cartocdn.com/light_all/{z}/{x}/{y}{r}.png"
                />

                {/* הצגת תלמידות */}
                {students.map((student) => (
                    <Marker key={student.id} position={[student.lat, student.lng]}>
                        <Tooltip
                            permanent
                            direction="top"
                            offset={[65, -10]}
                            className="student-label"
                        >
                            {student.id}
                        </Tooltip>
                    </Marker>
                ))}

            </MapContainer>
        </div>
    );
}

export default MapComponent;