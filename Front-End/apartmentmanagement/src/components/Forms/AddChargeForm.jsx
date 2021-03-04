import "date-fns";
import DateFnsUtils from "@date-io/date-fns";
import { Button, Grid, makeStyles, TextField } from "@material-ui/core";
import {
  KeyboardDatePicker,
  MuiPickersUtilsProvider,
} from "@material-ui/pickers";
import { AirlineSeatIndividualSuiteSharp } from "@material-ui/icons";
import { useState } from "react";
import useForm from "./useForm";
import { useParams } from "react-router-dom";
import { apiService } from "../../services/apiService";

const initialValues = {
  from: new Date(),
  to: new Date(),
};

function AddChargeForm(props) {
  const { handleClose, setCharges, charges } = props;
  const { values, setValues, handleInputChange } = useForm(initialValues);
  const { buildingId } = useParams();

  const handleSubmit = async (e) => {
    e.preventDefault();
    const data = {
      From: values.from,
      To: values.to,
    };
    const id = await apiService.postRequest(
      `building/${buildingId}/charge`,
      data
    );
    setCharges([
      ...charges,
      {
        from: data.From.toISOString(),
        to: data.To.toISOString(),
        chargeId: id,
      },
    ]);
    handleClose();
  };

  return (
    <form onSubmit={handleSubmit}>
      <MuiPickersUtilsProvider utils={DateFnsUtils}>
        <Grid container spacing={1}>
          <Grid item xs={12} sm={6}>
            <KeyboardDatePicker
              margin="normal"
              label="From"
              format="MM/dd/yyyy"
              value={values.from}
              fullWidth
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
              onChange={(val) =>
                handleInputChange({ target: { name: "to", value: val } })
              }
              KeyboardButtonProps={{
                "aria-label": "change date",
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

export default AddChargeForm;
