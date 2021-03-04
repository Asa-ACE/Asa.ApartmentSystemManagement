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
  username: null,
  from: null,
  to: null,
};

const useStyles = makeStyles((theme) => ({
  payer: {
    marginTop: theme.spacing(2),
  },
  formula: {
    marginBottom: theme.spacing(2),
  },
}));

function AddOwnerForm(props) {
  const { handleClose } = props;
  const { values, setValues, handleInputChange } = useForm(initialValues);
  const { buildingId, unitId } = useParams();

  const handleSubmit = (e) => {
    e.preventDefault();
    const data = {
      PersonName: values.username,
      From: values.from,
      To: values.to,
    };
    apiService.postRequest(`building/${buildingId}/unit/${unitId}/owner`, data);
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
              label="Username"
              name="username"
              value={values.username}
              on
              onChange={handleInputChange}
              autoFocus
              fullWidth
              type="text"
            />
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

export default AddOwnerForm;
