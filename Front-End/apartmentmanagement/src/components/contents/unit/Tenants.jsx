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
import { useParams } from "react-router-dom";
import ModalForm from "../../ModalForm";
import AddTenantForm from "../../Forms/AddTenantForm";
import EditTenantForm from "../../Forms/EditTenantForm";

function Tenants() {
  const { buildingId, unitId } = useParams();
  const tenants = apiService.getRequest(
    `building/${buildingId}/unit/${unitId}/tenant`
  );
  const [rows, setRows] = useState(tenants);
  const [openEditForm, setOpenEditForm] = useState(false);
  const [openAddForm, setOpenAddForm] = useState(false);

  return (
    <>
      <TableContainer component={Paper}>
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
        title="Edit Tenant"
        onClose={() => setOpenEditForm(false)}
      >
        <EditTenantForm />
      </ModalForm>
      <ModalForm
        open={openAddForm}
        title="New Tenant"
        onClose={() => setOpenAddForm(false)}
      >
        <AddTenantForm />
      </ModalForm>
    </>
  );
}

export default Tenants;
