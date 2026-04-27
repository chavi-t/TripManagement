import api from "./api";

export const registerTeacher = (data) => {
  return api.post("/Teacher", data);
};