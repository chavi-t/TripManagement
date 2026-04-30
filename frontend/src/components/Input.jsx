import "../styles/Input.css";

function Input({ label, value, name, onChange, type = "text", placeholder, onFocus }) {
  return (
    <div className="input-group">
      {label && <label>{label}</label>}

      <input
        type={type}
        value={value}
        name={name}
        onChange={onChange}
        placeholder={placeholder}
        onFocus={onFocus}
      />
    </div>
  );
}

export default Input;