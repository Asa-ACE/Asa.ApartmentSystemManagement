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

function OwnedUnits() {
  const { buildingId, unitId } = useParams();
  const units = apiService.getRequest(`unit/owned`);
  const [rows, setRows] = useState(units);
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
                  to={`${url}/owned/${unit.Id}/charge`}
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

export default OwnedUnits;
