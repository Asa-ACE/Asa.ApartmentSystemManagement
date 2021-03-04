import TabItem from "../../TabItem";
import TabsContainer from "../../TabsContainer";
import BuildingInfo from "./BuildingInfo";
import BuildingUnits from "./BuildingUnits";
import BuildingCharges from "./BuildingCharges";
import Unit from "../unit/Unit";
import { useRouteMatch, Switch, Route } from "react-router-dom";
import BuildingExpenses from "./BuildingExpenses";

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
          <TabItem label="Charges">
            <BuildingCharges />
          </TabItem>
          <TabItem label="Expenses">
            <BuildingExpenses />
          </TabItem>
        </TabsContainer>
      </Route>
      <Route path={`${path}/:unitId`}>
        <Unit />
      </Route>
    </Switch>
  );
}

export default Building;
