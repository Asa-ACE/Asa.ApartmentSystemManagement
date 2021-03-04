import ModalForm from "../../ModalForm";
import EditRoundedIcon from "@material-ui/icons/EditRounded";
import {
  TableContainer,
  Table,
  TableCell,
  TableHead,
  Button,
  TableRow,
  Paper,
  IconButton,
} from "@material-ui/core";
import { useEffect, useState } from "react";
import { useParams, Link, useRouteMatch } from "react-router-dom";
import { apiService } from "../../../services/apiService";
import AddCircleIcon from "@material-ui/icons/AddCircle";
import AddChargeForm from "../../Forms/AddChargeForm";
import EditChargeForm from "../../Forms/EditChargeForm";
import AddUnitForm from "../../Forms/AddUnitForm";

function BuildingUnits() {
  const { buildingId } = useParams();
  const [units, setUnits] = useState([]);
  const [openAddForm, setOpenAddForm] = useState(false);
  useEffect(async () => {
    const data = await apiService.getRequest(`building/${buildingId}/unit`);
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
      {units.length < 100 && (
        <IconButton color="primary" onClick={() => setOpenAddForm(true)}>
          <AddCircleIcon />
        </IconButton>
      )}
      <ModalForm
        open={openAddForm}
        title="New Unit"
        onClose={() => setOpenAddForm(false)}
      >
        <AddUnitForm
          units={units}
          setUnits={setUnits}
          handleClose={() => setOpenAddForm(false)}
          unitNumber={units.length + 1}
        />
      </ModalForm>
    </>
  );
}

export default BuildingUnits;
