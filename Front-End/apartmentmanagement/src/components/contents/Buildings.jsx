import { apiService } from "../../services/apiService";
import Cards from "../Cards";
import BuildingsData from "../FakeData/BuildingsData";
import Building from "./building/Building";
import { Route, Switch, useRouteMatch } from "react-router-dom";

function Buildings() {
  const { path, url } = useRouteMatch();

  return (
    <Switch>
      <Route path={`${path}`} exact>
        <Cards />
      </Route>
      <Route path={`${path}/:buildingId`}>
        <Building />
      </Route>
    </Switch>
  );
}

export default Buildings;
