import { useEffect, useState } from "react";
import { getTeacherById } from "../services/teacherService";
import { t } from "../translations/translation";

function ProfilePage() {
  const [teacher, setTeacher] = useState(null);
  const id = localStorage.getItem("teacherId");

  useEffect(() => {
    fetchData();
  }, []);

  const fetchData = async () => {
    const res = await getTeacherById(id);
    setTeacher(res.data);
  };

  if (!teacher) return <div className="loader">...</div>;

  return (
    <div>
      <h2>{t.personalDetails}</h2>

      <p>{t.id}: {teacher.teacherId}</p>
      <p>{t.firstName}: {teacher.firstName}</p>
      <p>{t.lastName}: {teacher.lastName}</p>
    </div>
  );
}

export default ProfilePage;