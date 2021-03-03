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
import { useState } from "react";
import useForm from "./useForm";
import { apiService } from "../../services/apiService";

const initialValues = {
  name: "",
  formulaType: "",
  isForOwner: false,
};

const useStyles = makeStyles((theme) => ({
  payer: {
    marginTop: theme.spacing(2),
  },
  formula: {
    marginBottom: theme.spacing(2),
  },
}));

function AddExpenseCategory(props) {
  const { handleClose } = props;
  const { values, setValues, handleInputChange } = useForm(initialValues);

  const handleSubmit = (e) => {
    e.preventDefault();
  };

  //const formulas = apiService.getRequest("/formulatype");
  const formulas = [
    { TypeName: "ali", Title: "staRTuo" },
    { TypeName: "mmm", Title: "stgfdfo" },
  ];

  const classes = useStyles();

  return (
    <form onSubmit={handleSubmit}>
      <MuiPickersUtilsProvider utils={DateFnsUtils}>
        <Grid container spacing={1}>
          <Grid item xs={12} sm={9}>
            <TextField
              variant="outlined"
              margin="normal"
              required
              label="Expense Category Name"
              name="name"
              value={values.name}
              type="text"
              onChange={handleInputChange}
              fullWidth
            />
          </Grid>
          <Grid item xs={12} sm={3}>
            <FormControl required fullWidth className={classes.payer}>
              <InputLabel id="select-payer">Payer</InputLabel>
              <Select
                labelId="select-payer"
                value={values.isForOwner}
                onChange={handleInputChange}
                name="isForOwner"
              >
                <MenuItem value={true}>Owner</MenuItem>
                <MenuItem value={false}>Tenant</MenuItem>
              </Select>
            </FormControl>
          </Grid>
          <Grid item xs={12}>
            <FormControl required fullWidth className={classes.formula}>
              <InputLabel id="select-formula">Payer</InputLabel>
              <Select
                labelId="select-formula"
                value={values.formulaType}
                onChange={handleInputChange}
                name="formulaType"
              >
                {formulas.map((formula) => (
                  <MenuItem value={formula.TypeName}>{formula.Title}</MenuItem>
                ))}
              </Select>
            </FormControl>
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

export default AddExpenseCategory;
