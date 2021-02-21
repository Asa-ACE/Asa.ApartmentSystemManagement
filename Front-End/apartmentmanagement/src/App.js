import React from "react";
// import 'bootstrap/dist/css/bootstrap.min.css';
import "./index.css";
import Navbar from "./components/Navbar";
import Login from "./components/Login";
import Register from "./components/Register";
import BuildingPage from "./components/buildingPage/BuildingPage";
import UnitTable from "./components/unitsPage/UnitTable";
import TabsContainer from "./components/TabsContainer"
import Dashboard from "./components/Dashboard";
import UnitsPage from "./components/unitsPage/UnitsPage";

function App() {
  return (
    <>
      <Dashboard>
        <UnitsPage/>
      </Dashboard>
    </>
  );
}

export default App;
