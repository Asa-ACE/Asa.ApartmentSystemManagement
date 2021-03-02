import Buildings from "../contents/Buildings";
import ChargeItemTable from "../ChargeItemTable";
import Template from "../Template";
import TabPanel from "../TabPanel";
import TabsContainer from "../TabsContainer";
import TabItem from "../TabItem";
import UnitChargeTable from "../UnitChargeTable";
import AddBuildingForm from "../Forms/AddBuildingForm";
import { Redirect, Switch, useRouteMatch, Route } from "react-router-dom";
import BuildingInfo from "../contents/building/BuildingInfo";

function Dashboard() {
  const { path, url } = useRouteMatch();
  console.log(url);
  return (
    <Template>
      <Switch>
        <Route exact path={path}>
          <Redirect to={`/buildings`} />
        </Route>
        <Route path={`${path}/buildings`}>
          <Buildings />
        </Route>
        <Route path={`${path}/units`}></Route>
      </Switch>
      <BuildingInfo />
    </Template>
  );
}

export default Dashboard;
