import axios from "axios";
import { authenticationService } from "./authenticationService";
axios.interceptors.a.use(
  (r) => r,
  (err) => console.log(err.response)
);
const apiURL = "http://localhost:12560/";
const handleError = (err) => {
  console.log(err.response);
  if ([401, 403].indexOf(err.response.status) !== -1) {
    alert("You're not logged in :)");
    authenticationService.logout();
    window.location.reload();
  }
  alert(err);
  Promise.reject(err);
};

const authHeader = () => {
  let currentUser = authenticationService.getCurrentUser();
  if (currentUser && currentUser.Token) {
    return { Authorization: `Bearer ${currentUser.token}` };
  } else {
    return {};
  }
};

async function getRequest(route) {
  try {
    let res = await axios.get(`${apiURL}${route}`, {
      headers: authHeader(),
    });
  } catch ({ response }) {
    handleError(response);
  }
}

async function postRequest(route, data) {
  try {
    let res = await axios.post(`${apiURL}${route}`, JSON.stringify(data), {
      headers: authHeader(),
    });
  } catch (err) {
    handleError(err);
  }
}

async function putRequest(route, data) {
  try {
    let res = await axios.put(`${apiURL}${route}`, JSON.stringify(data), {
      headers: authHeader(),
    });
  } catch (err) {
    handleError(err);
  }
}

async function patchRequest(route, data) {
  try {
    let res = await axios.patch(`${apiURL}${route}`, JSON.stringify(data), {
      headers: authHeader(),
    });
  } catch (err) {
    handleError(err);
  }
}

async function deleteRequest(route, data) {
  try {
    let res = await axios.delete(`${apiURL}${route}`, JSON.stringify(data));
  } catch (err) {
    handleError(err);
  }
}

export const apiService = {
  getRequest,
  postRequest,
  putRequest,
  patchRequest,
  deleteRequest,
};
