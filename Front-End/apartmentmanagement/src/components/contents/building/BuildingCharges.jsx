import { useState } from "react";
import { useParams } from "react-router-dom";
import ModalForm from "../../ModalForm";
import EditRoundedIcon from "@material-ui/icons/EditRounded";
import {
  IconButton,
  Table,
  TableContainer,
  TableHead,
  TableRow,
  TableCell,
  Button,
  Paper,
} from "@material-ui/core";
import AddCircleIcon from "@material-ui/icons/AddCircle";
import AddChargeForm from "../../Forms/AddChargeForm";
import { apiService } from "../../../services/apiService";
import EditChargeForm from "../../Forms/EditChargeForm";

function BuildingCharges() {
  const { buildingId, unitId } = useParams();
  const charges = apiService.getRequest(`building/${buildingId}/charge`);
  const [rows, setRows] = useState(charges);
  const [openEditForm, setOpenEditForm] = useState(false);
  const [openAddForm, setOpenAddForm] = useState(false);

  const handleCalculate = (chargeId) => {
    apiService.postRequest(
      `/building/${buildingId}/charge/${chargeId}/calculate`
    );
  };
  return (
    <>
      <TableContainer component={Paper}>
        <Table aria-label="list-table">
          <TableHead>
            <TableRow>
              <TableCell />
              <TableCell>From</TableCell>
              <TableCell>To</TableCell>
            </TableRow>
          </TableHead>
          {rows.map((charge) => (
            <TableRow>
              <TableCell>
                <Button
                  variant="contained"
                  color="primary"
                  onClick={() => handleCalculate(charge.ChargeId)}
                >
                  Calculate
                </Button>
              </TableCell>
              <TableCell>
                <IconButton
                  color="primary"
                  onClick={() => setOpenEditForm(true)}
                >
                  <EditRoundedIcon />
                </IconButton>
              </TableCell>
              <TableCell>{charge.From}</TableCell>
              <TableCell>{charge.To}</TableCell>
            </TableRow>
          ))}
        </Table>
      </TableContainer>
      <IconButton color="primary" onClick={() => setOpenAddForm(true)}>
        <AddCircleIcon />
      </IconButton>
      <ModalForm
        open={openEditForm}
        title="Edit Charge"
        onClose={() => setOpenEditForm(false)}
      >
        <EditChargeForm />
      </ModalForm>
      <ModalForm
        open={openAddForm}
        title="New Charge"
        onClose={() => setOpenAddForm(false)}
      >
        <AddChargeForm />
      </ModalForm>
    </>
  );
}

export default BuildingCharges;
