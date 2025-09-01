import axios from "axios";

const API_BASE_URL = "http://localhost:5247/api/files"; // Or move to .env

export const getFiles = async () => {
  const response = await axios.get(API_BASE_URL);
  return response.data;
};

export const uploadFile = async (file: File) => {
  const formData = new FormData();
  formData.append("file", file);

  const response = await axios.post(`${API_BASE_URL}/upload`, formData);
  return response.data;
};
 
export const downloadFile = async (id: string, fileName: string) => {
  const response = await axios.get(`${API_BASE_URL}/download/${id}`, {
    responseType: "blob", // Important for binary data
  });

  const url = window.URL.createObjectURL(new Blob([response.data]));
  const link = document.createElement("a");
  link.href = url;
  link.setAttribute("download", fileName);
  document.body.appendChild(link);
  link.click();
  link.remove();
};
export const deleteFile = async (id: string) => {
  await axios.delete(`${API_BASE_URL}/${id}`);
};
