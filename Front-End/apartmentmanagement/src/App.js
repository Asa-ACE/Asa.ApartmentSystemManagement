import React from "react";
// import 'bootstrap/dist/css/bootstrap.min.css';
import "./index.css";
import { Switch, Redirect, Route } from "react-router-dom";
import Login from "./components/Pages/Login";
import Register from "./components/Pages/Register";
import Dashboard from "./components/Pages/Dashboard";
import PrivateRoute from "./components/PrivateRoute";

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
        <PrivateRoute path="/" component={Dashboard} />
      </Switch>
    </>
  );
}

export default App;
