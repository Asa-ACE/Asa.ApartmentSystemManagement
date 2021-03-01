import React from "react";
// import 'bootstrap/dist/css/bootstrap.min.css';
import "./index.css";
import { Switch, Redirect, Route } from "react-router-dom";
import Login from "./components/Pages/Login";
import Register from "./components/Pages/Register";
import Dashboard from "./components/Pages/Dashboard";

function App() {
  return (
    <>
      <Switch>
        <Route path="/login">
          <Login />
        </Route>
        <Route path="/signup">
          <Register />
        </Route>
        <Route path="/">
          <Dashboard/>
        </Route>
      </Switch>
    </>
  );
}

export default App;
