import axios from "axios";

const api = axios.create({
  baseURL: "https://localhost:7105/",
});

export { api };
