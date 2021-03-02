import TabItem from "../../TabItem";
import TabsContainer from "../../TabsContainer";
import BuildingInfo from "./BuildingInfo";
import BuildingUnits from "./BuildingUnits";
import { useRouteMatch, Switch, Route } from "react-router-dom";

function Building() {
  const { path, url } = useRouteMatch();
  return (
    <Switch>
      <Route path={path} exact>
        <TabsContainer>
          <TabItem label="Information">
            <BuildingInfo />
          </TabItem>
          <TabItem label="Units">
            <BuildingUnits />
          </TabItem>
        </TabsContainer>
      </Route>
      <Route path={`${path}/:unitId`}></Route>
    </Switch>
  );
}

export default Building;
