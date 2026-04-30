import { useEffect, useState } from "react";
import { getMyStudents } from "../services/teacherService";
import { t } from "../translations/translation";


function MyStudents() {
    const [students, setStudents] = useState([]);
    const teacherId = localStorage.getItem("teacherId");

    useEffect(() => {
        fetchData();
    }, []);

    const fetchData = async () => {
        const res = await getMyStudents(teacherId);
        setStudents(res.data);
    };

    return (
        <div>
            <h2>{t.myStudents}</h2>
           <table className="table">
    <thead>
      <tr>
        <th>{t.id}</th>
        <th>{t.fullName}</th>
        <th>{t.class}</th>
      </tr>
    </thead>

    <tbody>
      {students.map((s) => (
        <tr key={s.studentId}>
          <td>{s.studentId}</td>
          <td>{s.fullName}</td>
          <td>{s.classId}</td>
        </tr>
      ))}
    </tbody>
  </table>
        </div>
    );
}

export default MyStudents;