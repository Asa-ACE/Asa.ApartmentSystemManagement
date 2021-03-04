import "date-fns";
import DateFnsUtils from "@date-io/date-fns";
import {
  Button,
  FormControl,
  Grid,
  InputLabel,
  makeStyles,
  MenuItem,
  Select,
  TextField,
} from "@material-ui/core";
import {
  KeyboardDatePicker,
  MuiPickersUtilsProvider,
} from "@material-ui/pickers";
import { AirlineSeatIndividualSuiteSharp } from "@material-ui/icons";
import { useEffect, useState } from "react";
import useForm from "./useForm";
import { apiService } from "../../services/apiService";
import { useParams } from "react-router-dom";

const initialValues = {
  name: null,
  from: null,
  to: null,
  amount: 0,
  categoryId: 0,
};

const useStyles = makeStyles((theme) => ({
  payer: {
    marginTop: theme.spacing(2),
  },
  formula: {
    marginBottom: theme.spacing(2),
  },
}));

function AddExpenseForm(props) {
  const { handleClose, expenses, setExpenses } = props;
  const { values, setValues, handleInputChange } = useForm(initialValues);
  const { buildingId } = useParams();

  const handleSubmit = async (e) => {
    e.preventDefault();
    const data = {
      CategoryId: values.categoryId,
      From: values.from,
      To: values.to,
      Amount: parseFloat(values.amount),
      Name: values.name,
    };
    const id = await apiService.postRequest(
      `building/${buildingId}/expense`,
      data
    );
    handleClose();
    window.location.reload();
  };
  const [categories, setCategories] = useState([]);
  useEffect(async () => {
    const data = await apiService.getRequest("building/expensecategory");
    setCategories(data);
  }, []);

  const classes = useStyles();

  return (
    <form onSubmit={handleSubmit}>
      <MuiPickersUtilsProvider utils={DateFnsUtils}>
        <Grid container spacing={1}>
          <Grid item xs={12}>
            <TextField
              variant="outlined"
              margin="normal"
              required
              label="Expense Name"
              name="name"
              value={values.name}
              on
              onChange={handleInputChange}
              autoFocus
              fullWidth
              type="text"
            />
          </Grid>
          <Grid item xs={12}>
            <FormControl required fullWidth>
              <InputLabel id="select-category">Expense Categories</InputLabel>
              <Select
                labelId="select-category"
                value={values.categoryId}
                onChange={handleInputChange}
                name="categoryId"
              >
                {categories.map((category) => (
                  <MenuItem value={category.categoryId}>
                    {category.name}
                  </MenuItem>
                ))}
              </Select>
            </FormControl>
          </Grid>
          <Grid item xs={12} sm={6}>
            <KeyboardDatePicker
              margin="normal"
              label="From"
              format="MM/dd/yyyy"
              value={values.from}
              fullWidth
              required
              onChange={(val) =>
                handleInputChange({ target: { name: "from", value: val } })
              }
              KeyboardButtonProps={{
                "aria-label": "change date",
              }}
            />
          </Grid>
          <Grid item xs={12} sm={6}>
            <KeyboardDatePicker
              margin="normal"
              label="To"
              format="MM/dd/yyyy"
              value={values.to}
              fullWidth
              required
              onChange={(val) =>
                handleInputChange({ target: { name: "to", value: val } })
              }
              KeyboardButtonProps={{
                "aria-label": "change date",
              }}
            />
          </Grid>
          <Grid item xs={12}>
            <TextField
              variant="outlined"
              margin="normal"
              required
              label="Amount"
              name="amount"
              value={values.amount}
              on
              onChange={handleInputChange}
              autoFocus
              fullWidth
              type="number"
              InputProps={{
                inputProps: {
                  step: ".01",
                },
              }}
            />
          </Grid>
          <Grid item xs={2}>
            <Button variant="contained" color="primary" fullWidth type="submit">
              Add
            </Button>
          </Grid>
          <Grid item xs={2}>
            <Button
              variant="contained"
              color="secondary"
              fullWidth
              onClick={handleClose}
            >
              Cancel
            </Button>
          </Grid>
        </Grid>
      </MuiPickersUtilsProvider>
    </form>
  );
}

export default AddExpenseForm;
