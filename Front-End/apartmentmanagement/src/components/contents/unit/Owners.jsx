import {
  Button,
  Table,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Paper,
} from "@material-ui/core";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { apiService } from "../../../services/apiService";
import AddOwnerForm from "../../Forms/AddOwnerForm";
import EditOwnerForm from "../../Forms/EditOwnerForm";
import ModalForm from "../../ModalForm";

function Owners() {
  const { buildingId, unitId } = useParams();
  const [owners, setOwners] = useState([]);
  useEffect(async () => {
    const data = await apiService.getRequest(
      `building/${buildingId}/unit/${unitId}/owner`
    );
    setOwners(data);
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
            </TableRow>
          </TableHead>
          {owners.map((owner) => (
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
              <TableCell>{owner.firstName}</TableCell>
              <TableCell>{owner.lastName}</TableCell>
              <TableCell>{owner.phoneNumber}</TableCell>
              <TableCell>{owner.from}</TableCell>
              <TableCell>{owner.to}</TableCell>
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
        title="Change Owner"
        onClose={() => setOpenEditForm(false)}
      >
        <EditOwnerForm />
      </ModalForm>
      <ModalForm
        open={openAddForm}
        title="New Owner"
        onClose={() => setOpenAddForm(false)}
      >
        <AddOwnerForm />
      </ModalForm>
    </>
  );
}

export default Owners;
