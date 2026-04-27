import "./Input.css";

function Input({ label, value, name, onChange, type = "text", placeholder }) {
  return (
    <div className="input-group">
      {label && <label>{label}</label>}

      <input
        type={type}
        value={value}
        name={name}
        onChange={onChange}
        placeholder={placeholder}
      />
    </div>
  );
}

export default Input;