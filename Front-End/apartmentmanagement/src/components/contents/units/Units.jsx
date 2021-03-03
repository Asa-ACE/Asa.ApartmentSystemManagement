import TabItem from "../../TabItem";
import TabsContainer from "../../TabsContainer";
import { useRouteMatch, Switch, Route } from "react-router-dom";
import OwnedUnits from "./OwnedUnits";
import RentedUnits from "./RentedUnits";
import OwnedUnitCharges from "../OwnedUnitCharges";
import RentedUnitCharges from "../RentedUnitChrages";

function Units() {
  const { path, url } = useRouteMatch();

  return (
    <Switch>
      <Route path={path} exact>
        <TabsContainer>
          <TabItem label="Owned Units">
            <OwnedUnits />
          </TabItem>
          <TabItem label="Rented Units">
            <RentedUnits />
          </TabItem>
        </TabsContainer>
      </Route>
      <Route path={`${path}/owned/:unitId/charges`}>
        <OwnedUnitCharges />
      </Route>
      <Route path={`${path}/rented/:unitId/charges`}>
        <RentedUnitCharges />
      </Route>
    </Switch>
  );
}

export default Units;
