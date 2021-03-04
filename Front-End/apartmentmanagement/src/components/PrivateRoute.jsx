import { renderIntoDocument } from "react-dom/test-utils";
import { Route, Redirect } from "react-router-dom";
import { authenticationService } from "../services/authenticationService";

const PrivateRoute = ({ component: Component, ...rest }) => (
  <Route
    {...rest}
    render={(props) => {
      const currentUser = authenticationService.getCurrentUser();
      if (!currentUser) {
        return (
          <Redirect
            to={{ pathname: "/login", state: { from: props.location } }}
          />
        );
      }
      return <Component {...props} />;
    }}
  />
);
export default PrivateRoute;
