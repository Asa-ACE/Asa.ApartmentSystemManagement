import React from 'react';
// import 'bootstrap/dist/css/bootstrap.min.css';
import "./index.css";
import Navbar from './components/Navbar';
import Login from "./components/Login";
import Register from "./components/Register";

function App() {
  return (
    <>
      <Navbar>
      </Navbar>
      <Register/>
    </>
  );
}

export default App;
