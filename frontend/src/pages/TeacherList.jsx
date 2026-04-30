import { useState } from "react";
import { useEffect } from "react";
import Input from "../components/Input";
import Button from "../components/Button";
import { t } from "../translations/translation";
import SearchBar from "../components/SearchBar";
import {getAllTeachers, getTeacherById } from "../services/teacherService";
import Loader from "../components/Loader";

function TeacherList() {
  const [query, setQuery] = useState("");
  const [teachers, setTeachers] = useState([]);
  const [loading, setLoading] = useState(false);


 const fetchAll = async () => {
  try {
    setLoading(true);
    const res = await getAllTeachers();
    setTeachers(res.data);
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

    const res = await getTeacherById(cleanQuery);

    setTeachers([res.data]);

  } catch (err) {
    console.log(err);
    setTeachers([]); 

  } finally {
    setLoading(false);
  }
};
  useEffect(() => {
  fetchAll();
}, []);

  return (
    <div>

      <h2>{t.teachers}</h2>

 <SearchBar
        value={query}
        onChange={(e) => setQuery(e.target.value)}
        onSearch={handleSearch}
        placeholder={t.searchTeacher}
        loading={loading}
      />


    {loading ? (
  <Loader />
) : teachers.length === 0 ? (
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
      {teachers.map((tch) => (
        <tr key={tch.teacherId}>
          <td>{tch.teacherId}</td>
          <td>{tch.fullName}</td>
          <td>{tch.classId}</td>
        </tr>
      ))}
    </tbody>
  </table>
)}
    </div>
  );
}

export default TeacherList;