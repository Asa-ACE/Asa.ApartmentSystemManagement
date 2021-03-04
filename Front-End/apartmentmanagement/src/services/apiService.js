import axios from "axios";
import { authenticationService } from "./authenticationService";

const apiURL = "http://localhost:12560/";
const handleError = (err) => {
  alert(err);
  return Promise.reject(err);
};

axios.interceptors.response.use(
  (res) => res.data,
  (err) => {
    alert(err);
    return Promise.reject(err);
  }
);
axios.interceptors.request.use((req) => {
  const currentUser = authenticationService.getCurrentUser();
  if (currentUser && currentUser.token) {
    req.headers.Authorization = currentUser.token;
  }
  req.headers["Content-Type"] = "application/json";
  return req;
});

const authHeader = () => {
  let currentUser = authenticationService.getCurrentUser();
  console.log(currentUser);
  if (currentUser && currentUser.token) {
    return {
      Authorization: `Bearer ${currentUser.token}`,
      "Content-Type": "application/json",
    };
  } else {
    return { "Content-Type": "application/json" };
  }
};

function getRequest(route) {
  const res = axios.get(`${apiURL}${route}`);
  return res;
}

function postRequest(route, data) {
  const res = axios.post(`${apiURL}${route}`, JSON.stringify(data));
  return res;
}

function putRequest(route, data) {
  const res = axios.put(`${apiURL}${route}`, JSON.stringify(data));
  return res;
}

async function patchRequest(route, data) {
  const res = axios.patch(`${apiURL}${route}`, JSON.stringify(data));
  return res;
}

async function deleteRequest(route, data) {
  const res = await axios.delete(`${apiURL}${route}`, JSON.stringify(data));
  return res;
}

export const apiService = {
  getRequest,
  postRequest,
  putRequest,
  patchRequest,
  deleteRequest,
  apiURL,
};
