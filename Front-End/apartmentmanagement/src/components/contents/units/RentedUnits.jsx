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
import { useEffect, useState } from "react";
import { Link, useParams, useRouteMatch } from "react-router-dom";
import ModalForm from "../../ModalForm";

function RentedUnits() {
  const { buildingId, unitId } = useParams();
  const [units, setUnits] = useState([]);
  useEffect(async () => {
    const data = await apiService.getRequest(`unit/rented`);
    setUnits(data);
  }, []);
  const { path, url } = useRouteMatch();

  return (
    <>
      <TableContainer component={Paper}>
        <Table aria-label="list-table">
          <TableHead>
            <TableRow>
              <TableCell />
              <TableCell>Unit Number</TableCell>
              <TableCell>Area</TableCell>
            </TableRow>
          </TableHead>
          {units.map((unit) => (
            <TableRow>
              <TableCell>
                <Button
                  variant="contained"
                  color="primary"
                  component={Link}
                  to={`${url}/rented/${unit.id}/charge`}
                >
                  Check Charges
                </Button>
              </TableCell>
              <TableCell>{unit.unitNumber}</TableCell>
              <TableCell>{unit.area}</TableCell>
            </TableRow>
          ))}
        </Table>
      </TableContainer>
    </>
  );
}

export default RentedUnits;
