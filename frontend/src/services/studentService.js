import api from "./api";

export const registerStudent = (data) => {
  return api.post("/Student", data);
};
export const getAllStudents = () =>
  api.get("/Student");

export const getStudentById = (id) =>
  api.get(`/Student/${id}`);

