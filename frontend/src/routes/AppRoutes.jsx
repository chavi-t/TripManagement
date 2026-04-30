import { Routes, Route } from "react-router-dom";
// Pages
import Home from "../pages/Home";
import Login from "../pages/Login";
import Register from "../pages/Register";
import ProtectedRoute from "../components/ProtectedRoute";
import DashboardLayout from "../pages/TeacherDashboard";
import StudentList from "../pages/StudentList";
import TeacherList from "../pages/TeacherList";
import ProfilePage from "../pages/ProfilePage";
import MyStudents from "../pages/MyStudents";
import MapComponent from "../components/Map/MapComponent";
import StudentTrackingContainer from "../components/Tracking/StudentTrackingContainer";

function AppRoutes() {
  return (
    <Routes>

      <Route path="/" element={<Home />} />
      <Route path="/login" element={<Login />} />
      <Route path="/register" element={<Register />} />
      <Route path="/map" element={<MapComponent />} />
      <Route path="/tracking" element={<StudentTrackingContainer />} />

      <Route
        path="/dashboard"
        element={
          <ProtectedRoute>
            <DashboardLayout />
          </ProtectedRoute>
        }
      >
        <Route path="students" element={<StudentList />} />
        <Route path="teachers" element={<TeacherList />} />
        <Route path="profile" element={<ProfilePage />} />
        <Route path="my-students" element={<MyStudents />} />
      </Route>
    </Routes>
  );
}

export default AppRoutes;