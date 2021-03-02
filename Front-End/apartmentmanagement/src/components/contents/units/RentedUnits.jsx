import { useState } from "react";
import { Link, useParams } from "react-router-dom";
import ModalForm from "../../ModalForm";

function RentedUnits() {
  const { buildingId, unitId } = useParams();
  const owners = apiService.getRequest(
    `building/${buildingId}/units/${unitId}/tenants`
  );
  const [rows, setRows] = useState(owners);

  return (
    <>
      <TableContainer component={paper}>
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
                  to={`${url}/rented-charge`}
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
