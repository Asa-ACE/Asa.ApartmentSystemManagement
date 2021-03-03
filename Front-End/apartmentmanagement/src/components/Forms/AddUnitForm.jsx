import "date-fns";
import DateFnsUtils from "@date-io/date-fns";
import {
  Button,
  Divider,
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
import { useParams } from "react-router-dom";

const initialValues = {
  area: 0,
};

const useStyles = makeStyles((theme) => ({
  payer: {
    marginTop: theme.spacing(2),
  },
  formula: {
    marginBottom: theme.spacing(2),
  },
}));

function AddUnitForm(props) {
  const { unitNumber, handleClose } = props;
  const { values, setValues, handleInputChange } = useForm(initialValues);
  const { buildingId } = useParams();

  const handleSubmit = (e) => {
    e.preventDefault();
    const data = { Area: values.area, UnitNumber: unitNumber };
    apiService.postRequest(`building/${buildingId}/unit`, data);
  };

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
              label="Area"
              name="area"
              value={values.area}
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

export default AddUnitForm;
