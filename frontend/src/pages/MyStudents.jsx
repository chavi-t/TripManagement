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
            {students.map((s) => (
                <div key={s.studentId}>
                    {s.firstName} {s.lastName}
                </div>
            ))}
        </div>
    );
}

export default MyStudents;