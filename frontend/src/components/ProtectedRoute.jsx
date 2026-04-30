import { Navigate } from "react-router-dom";

function ProtectedRoute({ children }) {
  const teacherId = localStorage.getItem("teacherId");
  const role = localStorage.getItem("role");

  if (!teacherId || role !== "teacher") {
    return <Navigate to="/login" />;
  }

  return children;
}

export default ProtectedRoute;