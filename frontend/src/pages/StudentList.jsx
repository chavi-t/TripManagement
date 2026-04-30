import { useState } from "react";
import { useEffect } from "react";
import { t } from "../translations/translation";
import SearchBar from "../components/SearchBar";
import { getAllStudents, getStudentById } from "../services/studentService";
import Loader from "../components/Loader";


function StudentList() {
  const [students, setStudents] = useState([]);
  const [query, setQuery] = useState("");
  const [loading, setLoading] = useState(false);

 const fetchAll = async () => {
  try {
    setLoading(true);
    const res = await getAllStudents();
    setStudents(res.data);
  } catch (err) {
    console.log(err);
  } finally {
    setLoading(false);
  }
};

  const handleSearch = async () => {
  const cleanQuery = query.trim();

  if (!cleanQuery) return fetchAll();

  try {
    setLoading(true);

    const res = await getStudentById(cleanQuery);

    setStudents([res.data]);

  } catch (err) {
    console.log(err);
    setStudents([]); 

  } finally {
    setLoading(false);
  }
};
useEffect(() => {
  fetchAll();
}, []);

  return (
    <div>

      <h2>{t.students}</h2>

      <SearchBar
        value={query}
        onChange={(e) => setQuery(e.target.value)}
        onSearch={handleSearch}
        placeholder={t.searchStudent}
        loading={loading}
      />

  {loading ? (
  <Loader />
) : students.length === 0 ? (
  <p className="no-results">{t.noResults}</p>
) : (
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
)}

    </div>
  );
}

export default StudentList;