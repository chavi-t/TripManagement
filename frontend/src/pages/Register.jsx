import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import Confetti from "react-confetti";
import Input from "../components/Input";
import Button from "../components/Button";
import { t } from "../translations/translation";
import "../styles/Register.css";
import { getClasses } from "../services/classService";
import { registerStudent } from "../services/studentService";
import { registerTeacher } from "../services/teacherService";

function Register() {
  const navigate = useNavigate();

  const [role, setRole] = useState("student");
  const [classes, setClasses] = useState([]);

  const [formData, setFormData] = useState({
    id: "",
    firstName: "",
    lastName: "",
    classId: ""
  });

  const [success, setSuccess] = useState(false);

  // API
  const fetchClasses = async () => {
    try {
      const res = await getClasses();
      setClasses(res.data);
    } catch (error) {
      console.log(error.response?.data || error.message);
    }
  };

  useEffect(() => {
    fetchClasses();
  }, []);

  //HELPERS
  const buildPayload = () => {
    if (role === "student") {
      return {
        studentId: formData.id,
        firstName: formData.firstName,
        lastName: formData.lastName,
        classId: Number(formData.classId)
      };
    }

    return {
      teacherId: formData.id,
      firstName: formData.firstName,
      lastName: formData.lastName,
      classId: Number(formData.classId)
    };
  };

  //HANDLERS 
  const handleChange = (e) => {
    setFormData((prev) => ({
      ...prev,
      [e.target.name]: e.target.value
    }));
  };

  const handleSubmit = async () => {
    if (
      !formData.id ||
      !formData.firstName ||
      !formData.lastName ||
      !formData.classId
    ) {
      alert({text: t.required});
      return;
    }

    const dataToSend = buildPayload();

    try {
      await (role === "student"
        ? registerStudent(dataToSend)
        : registerTeacher(dataToSend));

      setSuccess(true);

      setTimeout(() => {
        navigate("/");
      }, 5000);

    } catch (error) {
      console.log(error.response?.data || error.message);
    }
  };

  return (
    <div className="register-container">
      <div className="card">

        {success && (
          <>
            <Confetti
              width={window.innerWidth}
              height={window.innerHeight}
            />

            <div className="success-message">
              <span>{t.success}</span>
            </div>
          </>
        )}

        <div className="back" onClick={() => navigate("/")}>
          {t.back}
        </div>

        <h2 className="title">{t.register}</h2>

        <div className="role-toggle">
          <button
            className={role === "student" ? "active" : ""}
            onClick={() => setRole("student")}
          >
            {t.student}
          </button>

          <button
            className={role === "teacher" ? "active" : ""}
            onClick={() => setRole("teacher")}
          >
            {t.teacher}
          </button>
        </div>

        <div className="form">

          <Input
            name="id"
            placeholder={t.id}
            value={formData.id}
            onChange={handleChange}
          />

          <Input
            name="firstName"
            placeholder={t.firstName}
            value={formData.firstName}
            onChange={handleChange}
          />

          <Input
            name="lastName"
            placeholder={t.lastName}
            value={formData.lastName}
            onChange={handleChange}
          />

          <select
            name="classId"
            value={formData.classId}
            onChange={handleChange}
          >
            <option value="">{t.selectClass}</option>

            {classes.map((c) => (
              <option key={c.id} value={c.id}>
                {c.name}
              </option>
            ))}
          </select>

          <Button text={t.register} onClick={handleSubmit} />

        </div>
      </div>
    </div>
  );
}

export default Register;