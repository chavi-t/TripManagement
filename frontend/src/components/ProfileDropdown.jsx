import { useNavigate } from "react-router-dom";
import { t } from "../translations/translation";
import "../styles/ProfileDropdown.css";

function ProfileDropdown() {
  const navigate = useNavigate();
  const logout = () => {
    localStorage.clear();
    navigate("/");
  };

  return (
    <div className="dropdown">
      <div onClick={() => navigate("/dashboard/profile")}>
        {t.personalDetails}
      </div>

      <div onClick={() => navigate("/dashboard/my-students")}>
        {t.myStudents}
      </div>

      <div onClick={logout}>
        {t.logout}
      </div>
    </div>
  );
}

export default ProfileDropdown;