import { Button, Grid, makeStyles, TextField } from "@material-ui/core";
import { AirlineSeatIndividualSuiteSharp } from "@material-ui/icons";
import { useState } from "react";
import useForm from "./useForm";

const initialValues = {
  buildingName: "",
  numberOfUnits: 1,
  address: "",
};

function AddBuildingForm(props) {
  const { handleClose } = props;
  const { values, setValues, handleInputChange } = useForm(initialValues);

  const handleSubmit = (e) => {
    e.preventDefault();
  };

  return (
    <form onSubmit={handleSubmit}>
      <Grid container spacing={1}>
        <Grid item xs={12} sm={9}>
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
        <Grid item xs={12} sm={3}>
          <TextField
            variant="outlined"
            margin="normal"
            required
            label="Number Of Units"
            name="numberOfUnits"
            value={values.numberOfUnits}
            onChange={handleInputChange}
            fullWidth
            type="number"
            InputProps={{
              inputProps: {
                min: 1,
              },
            }}
          />
        </Grid>
        <Grid item xs={12}>
          <TextField
            variant="outlined"
            margin="normal"
            required
            label="Address"
            name="address"
            value={values.address}
            onChange={handleInputChange}
            type="text"
            fullWidth
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
    </form>
  );
}

export default AddBuildingForm;
