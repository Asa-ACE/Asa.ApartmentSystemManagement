import axios from "axios";

const apiURL = "http://localhost:12560/";

async function getRequest(route) {
  try {
    let res = await axios.get(`${apiURL}${route}`);
  } catch (err) {}
}

async function postRequest(route, data) {
  try {
    let res = await axios.post(`${apiURL}${route}`, data);
  } catch (err) {}
}

async function putRequest(route, data) {
  try {
    let res = await axios.put(`${apiURL}${route}`, data);
  } catch (err) {}
}

async function patchRequest(route, data) {
  try {
    let res = await axios.patch(`${apiURL}${route}`, data);
  } catch (err) {}
}

async function deleteRequest(route, data) {
  try {
    let res = await axios.delete(`${apiURL}${route}`, data);
  } catch (err) {}
}

export const apiService = {
  getRequest,
  postRequest,
  putRequest,
  patchRequest,
  deleteRequest,
};
