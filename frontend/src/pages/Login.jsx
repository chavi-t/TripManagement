import { useState } from "react";
import { useNavigate } from "react-router-dom";
import Input from "../components/Input";
import Button from "../components/Button";
import { t } from "../translations/translation";
import { getTeacherById } from "../services/teacherService";
import "../styles/Login.css";

function Login() {
  const navigate = useNavigate();

  const [id, setId] = useState("");
  const [error, setError] = useState("");

  const handleLogin = async () => {
    setError("");

    try {
      await getTeacherById(id);

      localStorage.setItem("teacherId", id);
      localStorage.setItem("role", "teacher");

      navigate("/dashboard");

    } catch (err) {
      setError(t.loginError);
    }
  };

  const handleFocus = () => {
  if (error) {
    setId("");
    setError("");
  }
};

  return (
    <div className="login-container">
      <div className="card">

        <div className="back" onClick={() => navigate("/")}>
          {t.back}
        </div>

        <h2 className="title">{t.loginTitle}</h2>

        <div className="form">

          <Input
            name="id"
            placeholder={t.id}
            value={id}
            onChange={(e) => setId(e.target.value)}
            onFocus={handleFocus}
          />

          {error && <div className="error">{error}</div>}

          <Button text={t.login} onClick={handleLogin} />

        </div>

      </div>
    </div>
  );
}

export default Login;