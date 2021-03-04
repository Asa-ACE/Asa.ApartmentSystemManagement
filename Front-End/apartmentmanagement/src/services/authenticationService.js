import axios from "axios";
import { createContext, useState } from "react";
import { BehaviorSubject } from "rxjs";
import { apiService } from "./apiService";

const login = async (username, password) => {
  let data = { username, password };
  const user = await axios.post(
    `${apiService.apiURL}user/authenticate`,
    JSON.stringify(data),
    {
      headers: {
        "Content-Type": "application/json",
      },
    }
  );
  localStorage.setItem("currentUser", JSON.stringify(user));
  console.log(user);
  debugger;
  window.location.href = "http://localhost:3000/";
};

const userSubject = new BehaviorSubject(
  JSON.parse(localStorage.getItem("currentUser"))
);
const getCurrentUser = () => userSubject.value;

const logout = () => {
  localStorage.removeItem("currentUser");
  userSubject.next(null);
  window.location.href = "http://localhost:3000/login";
};

export const authenticationService = {
  login,
  logout,
  getCurrentUser,
};
