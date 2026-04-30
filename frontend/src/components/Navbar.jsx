import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import ProfileDropdown from "./ProfileDropdown";
import { getTeacherById } from "../services/teacherService";
import { t } from "../translations/translation";
import "../styles/Navbar.css";

function Navbar() {
  const navigate = useNavigate();
  const [open, setOpen] = useState(false);
  const [teacher, setTeacher] = useState(null);

  const teacherId = localStorage.getItem("teacherId");

  useEffect(() => {
    if (teacherId) fetchTeacher();
  }, [teacherId]);

  const fetchTeacher = async () => {
    try {
      const res = await getTeacherById(teacherId);
      setTeacher(res.data);
    } catch (err) {
      console.log(err);
    }
  };


  const firstLetter = teacher?.firstName?.charAt(0) || "";
  return (
    <div className="navbar">

      <div className="nav-links">
        <span onClick={() => navigate("/dashboard/students")}>
          {t.students}
        </span>

        <span onClick={() => navigate("/dashboard/teachers")}>
          {t.teachers}
        </span>
      </div>

      <div className="profile" onClick={() => setOpen(!open)}>
        <div className="avatar">{firstLetter}</div>

        <div className="profile-name">
          {teacher ? teacher.firstName : ""}
        </div>

        {open && (
          <div className="dropdown-wrapper">
            <ProfileDropdown />
          </div>
        )}
      </div>

    </div>

  );
}

export default Navbar;