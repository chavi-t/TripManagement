import api from "./api";

export const registerStudent = (data) => {
  return api.post("/Student", data);
};