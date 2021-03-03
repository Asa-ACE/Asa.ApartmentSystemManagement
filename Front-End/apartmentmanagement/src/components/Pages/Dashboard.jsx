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
import ModalForm from "../ModalForm";
import AddChargeForm from "../Forms/AddChargeForm";
import AddExpenseCategory from "../Forms/AddExpenseCategoryForm";
import AddExpenseForm from "../Forms/AddExpenseForm";
import AddOwnerForm from "../Forms/AddOwnerForm";
import AddTenantForm from "../Forms/AddTenantForm";
import AddUnitForm from "../Forms/AddUnitForm";
import EditBuildingNameForm from "../Forms/EditBuildingNameForm";
import PrivateRoute from "../PrivateRoute";
import Units from "../contents/units/Units";

function Dashboard() {
  const { path, url } = useRouteMatch();
  return (
    <Template>
      <Switch>
        <Route exact path={path}>
          <Redirect to={`/buildings`} />
        </Route>
        <PrivateRoute path={`${path}buildings`}>
          <Buildings />
        </PrivateRoute>
        <PrivateRoute path={`${path}units`}>
          <Units />
        </PrivateRoute>
      </Switch>
    </Template>
  );
}

export default Dashboard;
