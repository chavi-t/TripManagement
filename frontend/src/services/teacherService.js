import api from "./api";

export const registerTeacher = (data) => {
  return api.post("/Teacher", data);
};

export const getTeacherById = (id) => {
  return api.get(`/Teacher/${id}`);
};
export const getAllTeachers = () =>
  api.get("/Teacher");

export const getMyStudents = (teacherId) =>
  api.get(`/Teacher/${teacherId}/students`);




