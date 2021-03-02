import { useState } from "react";
import { useParams } from "react-router-dom";
import ModalForm from "../../ModalForm";

function Owners() {
  const { buildingId, unitId } = useParams();
  const owners = apiService.getRequest(
    `building/${buildingId}/units/${unitId}/owners`
  );
  const [rows, setRows] = useState(owners);
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
            </TableRow>
          </TableHead>
          {rows.map((owner) => (
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
              <TableCell>{owner.FirstName}</TableCell>
              <TableCell>{owner.LastName}</TableCell>
              <TableCell>{owner.PhoneNumber}</TableCell>
              <TableCell>{owner.From}</TableCell>
              <TableCell>{owner.To}</TableCell>
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
      ></ModalForm>
      <ModalForm
        open={openAddForm}
        title="New Owner"
        onClose={() => setOpenAddForm(false)}
      ></ModalForm>
    </>
  );
}

export default Owners;
