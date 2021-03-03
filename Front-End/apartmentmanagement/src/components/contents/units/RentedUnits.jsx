import {
  Button,
  Table,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Paper,
} from "@material-ui/core";
import { apiService } from "../../../services/apiService";
import { useState } from "react";
import { Link, useParams, useRouteMatch } from "react-router-dom";
import ModalForm from "../../ModalForm";

function RentedUnits() {
  const { buildingId, unitId } = useParams();
  const owners = apiService.getRequest(`unit/rented`);
  const [rows, setRows] = useState(owners);
  const { path, url } = useRouteMatch();

  return (
    <>
      <TableContainer component={Paper}>
        <Table aria-label="list-table">
          <TableHead>
            <TableRow>
              <TableCell />
              <TableCell>Building Name</TableCell>
              <TableCell>Unit Number</TableCell>
              <TableCell>Area</TableCell>
            </TableRow>
          </TableHead>
          {rows.map((unit) => (
            <TableRow>
              <TableCell>
                <Button
                  variant="contained"
                  color="primary"
                  component={Link}
                  to={`${url}/rented/${unit.Id}/charge`}
                >
                  Check Charges
                </Button>
              </TableCell>
              <TableCell>{unit.BuildingName}</TableCell>
              <TableCell>{unit.UnitNumber}</TableCell>
              <TableCell>{unit.Area}</TableCell>
            </TableRow>
          ))}
        </Table>
      </TableContainer>
    </>
  );
}

export default RentedUnits;
