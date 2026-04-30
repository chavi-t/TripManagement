import Navbar from "../components/Navbar";
import { Outlet } from "react-router-dom";
import "../styles/dashboard.css";

function DashboardLayout() {
  return (
    <div className="dashboard-container">
      <Navbar />
      <div className="dashboard-content">
        <Outlet />
      </div>
    </div>
   
  );
}

export default DashboardLayout;