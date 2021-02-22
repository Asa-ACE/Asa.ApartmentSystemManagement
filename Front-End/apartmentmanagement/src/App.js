import React from "react";
// import 'bootstrap/dist/css/bootstrap.min.css';
import "./index.css";
import Navbar from "./components/Navbar";
import Login from "./components/Login";
import Register from "./components/Register";
import BuildingPage from "./components/buildingPage/BuildingPage";
import UnitTable from "./components/unitsPage/UnitTable";
import Dashboard from "./components/Dashboard";
import UnitsPage from "./components/unitsPage/UnitsPage";
import Cards from "./components/Cards";
import BuildingData from "./FakeData/BuildingsData";
import TabsContainer from "./components/TabsContainer";
import TabItem from "./components/TabItem";
import TabPanel from "@material-ui/lab/TabPanel";

function App() {
  return (
    <>
      <Dashboard>
        <TabsContainer>
          <TabItem label="AmirHossein">
            <Cards BuildingData={BuildingData} />
          </TabItem>
          <TabItem label="ssss">Mohsen</TabItem>
        </TabsContainer>
      </Dashboard>
    </>
  );
}

export default App;
