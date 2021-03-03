import {
  Button,
  Table,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
} from "@material-ui/core";
import { apiService } from "../../../services/apiService";
import { useState } from "react";
import { useParams } from "react-router-dom";
import ModalForm from "../../ModalForm";

function Tenants() {
  const { buildingId, unitId } = useParams();
  const tenants = apiService.getRequest(
    `building/${buildingId}/units/${unitId}/tenants`
  );
  const [rows, setRows] = useState(tenants);
  const [openEditForm, setOpenEditForm] = useState(false);
  const [openAddForm, setOpenAddForm] = useState(false);

  return (
    <>
      <TableContainer component={paper}>
        <Table aria-label="list-table">
          <TableHead>
            <TableRow>
              <TableCell />
              <TableCell>First Name</TableCell>
              <TableCell>Last Name</TableCell>
              <TableCell>Phone Number</TableCell>
              <TableCell>From</TableCell>
              <TableCell>To</TableCell>
              <TableCell>Number Of People</TableCell>
            </TableRow>
          </TableHead>
          {rows.map((tenant) => (
            <TableRow>
              <TableCell>
                <Button
                  variant="contained"
                  color="primary"
                  onClick={() => setOpenEditForm(true)}
                >
                  Edit Owner
                </Button>
              </TableCell>
              <TableCell>{tenant.FirstName}</TableCell>
              <TableCell>{tenant.LastName}</TableCell>
              <TableCell>{tenant.PhoneNumber}</TableCell>
              <TableCell>{tenant.From}</TableCell>
              <TableCell>{tenant.To}</TableCell>
              <TableCell>{tenant.NumberOfPeople}</TableCell>
            </TableRow>
          ))}
        </Table>
      </TableContainer>
      <Button
        variant="contained"
        color="primary"
        onClick={() => setOpenAddForm(true)}
      >
        Add Owner
      </Button>
      <ModalForm
        open={openEditForm}
        title="Change Tenant"
        onClose={() => setOpenEditForm(false)}
      ></ModalForm>
      <ModalForm
        open={openAddForm}
        title="New Tenant"
        onClose={() => setOpenAddForm(false)}
      ></ModalForm>
    </>
  );
}

export default Tenants;
