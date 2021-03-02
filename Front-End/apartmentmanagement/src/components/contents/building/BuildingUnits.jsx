import {
  TableContainer,
  Table,
  TableCell,
  TableHead,
  Button,
  TableRow,
} from "@material-ui/core";
import { useParams, Link, useRouteMatch } from "react-router-dom";
import { apiService } from "../../../services/apiService";

function BuildingUnits() {
  const { buildingId } = useParams();
  const units = apiService.getRequest(`/building/${buildingId}/units`);
  const { path, url } = useRouteMatch();
  return (
    <TableContainer component={paper}>
      <Table aria-label="list-table">
        <TableHead>
          <TableRow>
            <TableCell />
            <TableCell>Area</TableCell>
            <TableCell>UnitNumber</TableCell>
          </TableRow>
        </TableHead>
        {units.map((unit) => (
          <TableRow>
            <TableCell>
              <Button
                component={Link}
                to={`${url}/${unit.Id}`}
                variant="contained"
                color="primary"
              >
                Enter
              </Button>
            </TableCell>
            <TableCell>{unit.Area}</TableCell>
            <TableCell>{unit.UnitNumber}</TableCell>
          </TableRow>
        ))}
      </Table>
    </TableContainer>
  );
}

export default BuildingUnits;
