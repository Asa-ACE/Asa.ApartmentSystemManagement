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

const initialValues = {
  buildingName: null,
};

const useStyles = makeStyles((theme) => ({
  payer: {
    marginTop: theme.spacing(2),
  },
  formula: {
    marginBottom: theme.spacing(2),
  },
}));

function EditBuildingNameForm(props) {
  const { handleClose } = props;
  const { values, setValues, handleInputChange } = useForm(initialValues);

  const handleSubmit = (e) => {
    e.preventDefault();
  };

  //const categories = apiService.getRequest("/formulatype");
  const categories = [
    { CategoryId: 1, Name: "yyyy" },
    { CategoryId: 2, Name: "yyyyss" },
  ];

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
              label="Building Name"
              name="buildingName"
              value={values.buildingName}
              on
              onChange={handleInputChange}
              autoFocus
              fullWidth
              type="text"
            />
          </Grid>
          <Grid item xs={2}>
            <Button variant="contained" color="primary" fullWidth type="submit">
              Ok
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

export default EditBuildingNameForm;
