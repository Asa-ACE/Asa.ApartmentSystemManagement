import axios from "axios";
import { createContext, useState } from "react";
import { BehaviorSubject } from "rxjs";
import { apiService } from "./apiService";

const login = async (username, password) => {
  let data = { username, password };
  try {
    let user = await axios.post(
      `${apiService.apiURL}user/authenticate`,
      JSON.stringify(data)
    );
    localStorage.setItem("currentUser", JSON.stringify(user));
  } catch (err) {
    alert(err);
    Promise.reject(err);
  }
};

const userSubject = new BehaviorSubject(
  JSON.parse(localStorage.getItem("currentUser"))
);
const getCurrentUser = () => userSubject.value;

const logout = () => {
  localStorage.removeItem("currentUser");
  userSubject.next(null);
};

export const authenticationService = {
  login,
  logout,
  getCurrentUser,
};
