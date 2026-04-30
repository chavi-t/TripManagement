import { useNavigate } from "react-router-dom";
import "../styles/Home.css";
import { t } from "../translations/translation";
import Button from "../components/Button";

function Home() {
  const navigate = useNavigate();

  return (
    <div className="home-container">
      <div className="overlay">
        <h1 className="title">{t.welcome}</h1>

        <h2 className="subtitle">{t.school}</h2>

        <div className="buttons">
          <Button
            text={t.register}
            onClick={() => navigate("/register")}
          />

          <Button
            text={t.loginTeacher}
            onClick={() => navigate("/login")}
          />
           <Button
            text={t.StudentMap}
            onClick={() => navigate("/tracking")}
          />
        </div>
      </div>
    </div>
  );
}

export default Home;