import { useState, useEffect } from "react";
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
import AddUnitForm from "../../Forms/AddUnitForm";

function BuildingCharges() {
  const { buildingId, unitId } = useParams();
  const [charges, setCharges] = useState([]);
  useEffect(async () => {
    const data = await apiService.getRequest(`building/${buildingId}/charge`);
    setCharges(data);
  }, []);
  const [openEditForm, setOpenEditForm] = useState(false);
  const [openAddForm, setOpenAddForm] = useState(false);
  const [id, setId] = useState(0);

  const handleCalculate = async (chargeId) => {
    await apiService.postRequest(
      `building/${buildingId}/charge/${chargeId}/calculate`
    );
    alert("Charge has been calculated :)");
  };
  return (
    <>
      <TableContainer component={Paper}>
        <Table aria-label="list-table">
          <TableHead>
            <TableRow>
              <TableCell />
              <TableCell />
              <TableCell>From</TableCell>
              <TableCell>To</TableCell>
            </TableRow>
          </TableHead>
          {charges.map((charge) => (
            <TableRow>
              <TableCell>
                <Button
                  variant="contained"
                  color="primary"
                  onClick={() => handleCalculate(charge.chargeId)}
                >
                  Calculate
                </Button>
              </TableCell>
              <TableCell>
                <IconButton
                  color="primary"
                  onClick={() => {
                    setId(charge.chargeId);
                    setOpenEditForm(true);
                  }}
                >
                  <EditRoundedIcon />
                </IconButton>
              </TableCell>
              <TableCell>{charge.from.substring(0, 10)}</TableCell>
              <TableCell>{charge.to.substring(0, 10)}</TableCell>
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
        <EditChargeForm
          setCharges={setCharges}
          chargeId={id}
          handleClose={() => setOpenEditForm(false)}
        />
      </ModalForm>
      <ModalForm
        open={openAddForm}
        title="New Unit"
        onClose={() => setOpenAddForm(false)}
      >
        <AddChargeForm
          charges={charges}
          setCharges={setCharges}
          handleClose={() => setOpenAddForm(false)}
        />
      </ModalForm>
    </>
  );
}

export default BuildingCharges;
