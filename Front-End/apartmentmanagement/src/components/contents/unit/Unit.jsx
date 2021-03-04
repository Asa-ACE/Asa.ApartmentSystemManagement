import TabItem from "../../TabItem";
import TabsContainer from "../../TabsContainer";
import { useRouteMatch, Switch, Route } from "react-router-dom";
import Owners from "./Owners";
import Tenants from "./Tenants";

function Unit() {
  const { path, url } = useRouteMatch();

  return (
    <Switch>
      <Route path={path} exact>
        <TabsContainer>
          <TabItem label="Owners">
            <Owners />
          </TabItem>
          <TabItem label="Tenants">
            <Tenants />
          </TabItem>
        </TabsContainer>
      </Route>
    </Switch>
  );
}

export default Unit;
