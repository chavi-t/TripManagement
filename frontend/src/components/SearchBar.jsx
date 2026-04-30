import Input from "./Input";
import Button from "./Button";

function SearchBar({ value, onChange, onSearch, placeholder, loading }) {
  return (
    <div className="search-bar">

      <Input
        value={value}
        onChange={onChange}
        placeholder={placeholder}
      />

      <Button
        text={loading ? "..." : "🔍"}
        onClick={onSearch}
      />

    </div>
  );
}

export default SearchBar;