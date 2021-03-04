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
import { useParams } from "react-router-dom";
import ModalForm from "../../ModalForm";
import AddTenantForm from "../../Forms/AddTenantForm";
import EditTenantForm from "../../Forms/EditTenantForm";

function Tenants() {
  const { buildingId, unitId } = useParams();
  const [tenants, setTenants] = useState([]);
  useEffect(async () => {
    const data = await apiService.getRequest(
      `building/${buildingId}/unit/${unitId}/tenant`
    );
    setTenants(data);
  }, []);
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
          {tenants.map((tenant) => (
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
              <TableCell>{tenant.firstName}</TableCell>
              <TableCell>{tenant.lastName}</TableCell>
              <TableCell>{tenant.phoneNumber}</TableCell>
              <TableCell>{tenant.from}</TableCell>
              <TableCell>{tenant.to}</TableCell>
              <TableCell>{tenant.numberOfPeople}</TableCell>
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
