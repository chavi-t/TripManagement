import api from "./api"; 

export const getClasses = () => {
  return api.get("/Class");
};