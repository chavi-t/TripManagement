import { useNavigate } from "react-router-dom";
import "./Home.css";
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
            text={t.login}
            onClick={() => navigate("/login")}
          />
        </div>
      </div>
    </div>
  );
}

export default Home;