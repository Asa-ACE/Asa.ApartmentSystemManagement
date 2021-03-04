import {
  TableContainer,
  Table,
  TableCell,
  TableHead,
  Button,
  TableRow,
  Paper,
} from "@material-ui/core";
import { useEffect, useState } from "react";
import { useParams, Link, useRouteMatch } from "react-router-dom";
import { apiService } from "../../../services/apiService";

function BuildingUnits() {
  const { buildingId } = useParams();
  const [units, setUnits] = useState([]);
  useEffect(async () => {
    const data = await apiService.getRequest(`building/${buildingId}/unit`);
    setUnits(data);
  }, []);

  const { path, url } = useRouteMatch();
  return (
    <TableContainer component={Paper}>
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
                to={`${url}/${unit.id}`}
                variant="contained"
                color="primary"
              >
                Enter
              </Button>
            </TableCell>
            <TableCell>{unit.area}</TableCell>
            <TableCell>{unit.unitNumber}</TableCell>
          </TableRow>
        ))}
      </Table>
    </TableContainer>
  );
}

export default BuildingUnits;
