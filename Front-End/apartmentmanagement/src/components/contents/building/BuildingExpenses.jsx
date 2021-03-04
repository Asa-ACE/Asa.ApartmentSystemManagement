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
import AddExpenseForm from "../../Forms/AddExpenseForm";
import EditExpenseForm from "../../Forms/EditExpenseForm";

function BuildingExpenses() {
  const { buildingId, unitId } = useParams();
  const [expenses, setExpenses] = useState([]);
  useEffect(async () => {
    const data = await apiService.getRequest(`building/${buildingId}/expense`);
    setExpenses(data);
  }, []);
  const [openEditForm, setOpenEditForm] = useState(false);
  const [openAddForm, setOpenAddForm] = useState(false);
  const [id, setId] = useState(0);

  return (
    <>
      <TableContainer component={Paper}>
        <Table aria-label="list-table">
          <TableHead>
            <TableRow>
              <TableCell />
              <TableCell>Name</TableCell>
              <TableCell>From</TableCell>
              <TableCell>To</TableCell>
              <TableCell>Amount</TableCell>
            </TableRow>
          </TableHead>
          {expenses.map((expense) => (
            <TableRow>
              <TableCell>
                <IconButton
                  color="primary"
                  onClick={() => {
                    setId(expense.expenseId);
                    setOpenEditForm(true);
                  }}
                >
                  <EditRoundedIcon />
                </IconButton>
              </TableCell>
              <TableCell>{expense.name}</TableCell>
              <TableCell>{expense.from.substring(0, 10)}</TableCell>
              <TableCell>{expense.to.substring(0, 10)}</TableCell>
              <TableCell>{expense.amount}</TableCell>
            </TableRow>
          ))}
        </Table>
      </TableContainer>
      <IconButton color="primary" onClick={() => setOpenAddForm(true)}>
        <AddCircleIcon />
      </IconButton>
      <ModalForm
        open={openEditForm}
        title="Edit Expense"
        onClose={() => setOpenEditForm(false)}
      >
        <EditExpenseForm
          setExpenses={setExpenses}
          expenses={expenses}
          expenseId={id}
          handleClose={() => setOpenEditForm(false)}
        />
      </ModalForm>
      <ModalForm
        open={openAddForm}
        title="New Expense"
        onClose={() => setOpenAddForm(false)}
      >
        <AddExpenseForm
          expenses={expenses}
          setExpenses={setExpenses}
          handleClose={() => setOpenAddForm(false)}
        />
      </ModalForm>
    </>
  );
}

export default BuildingExpenses;
