import React from "react";
// import 'bootstrap/dist/css/bootstrap.min.css';
import "./index.css";
import Navbar from "./components/Navbar";
import Login from "./components/Login";
import Register from "./components/Register";
import BuildingPage from "./components/buildingPage/BuildingPage";
import UnitTable from "./components/unitsPage/UnitTable";
import TabsContainer from "./components/TabsContainer";
import Dashboard from "./components/Dashboard";
import UnitsPage from "./components/unitsPage/UnitsPage";
import Cards from "./components/Cards";
import BuildingData from "./FakeData/BuildingsData";
import StyledTab from "./components/StyledTab";
import StyledTabs from "./components/StyledTabs";

import { makeStyles, withStyles } from '@material-ui/core/styles';
import Tabs from '@material-ui/core/Tabs';
import Tab from '@material-ui/core/Tab';
import Typography from '@material-ui/core/Typography';
const AntTab = withStyles((theme) => ({
  root: {
    textTransform: 'none',
    minWidth: 72,
    fontWeight: theme.typography.fontWeightRegular,
    marginRight: theme.spacing(4),
    fontFamily: [
      '-apple-system',
      'BlinkMacSystemFont',
      '"Segoe UI"',
      'Roboto',
      '"Helvetica Neue"',
      'Arial',
      'sans-serif',
      '"Apple Color Emoji"',
      '"Segoe UI Emoji"',
      '"Segoe UI Symbol"',
    ].join(','),
    '&:hover': {
      color: '#40a9ff',
      opacity: 1,
    },
    '&$selected': {
      color: '#1890ff',
      fontWeight: theme.typography.fontWeightMedium,
    },
    '&:focus': {
      color: '#40a9ff',
    },
  },
  selected: {},
}))((props) => <Tab disableRipple {...props} />);

const AntTabs = withStyles({
  root: {
    borderBottom: '1px solid #e8e8e8',
  },
  indicator: {
    backgroundColor: '#1890ff',
  },
})(Tabs);

function App() {
  return (
    <>
      <Dashboard>
        <AntTabs>
          <AntTab label="Amirhossein"/>
          <AntTab label="majid" />
        </AntTabs>
       
      </Dashboard>
    </>
  );
}

export default App;
