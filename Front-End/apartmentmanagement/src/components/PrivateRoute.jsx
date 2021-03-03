import { renderIntoDocument } from "react-dom/test-utils";
import { Route, Redirect } from "react-router-dom";
import { authenticationService } from "../services/authenticationService";

function PrivateRoute(props) {
  const { children, ...rest } = props;
  return (
    <Route
      {...rest}
      render={(props) => {
        const currentUser = authenticationService.getCurrentUser();
        if (!currentUser) {
          return <Redirect to="/login" />;
        }
        return { children };
      }}
    />
  );
}

export default PrivateRoute;
