import { Button, Grid, makeStyles, TextField } from "@material-ui/core";
import { AirlineSeatIndividualSuiteSharp } from "@material-ui/icons";
import { useState } from "react";

const initialValues = {
  buildingName: "",
  numberOfUnits: 0,
  address: "",
};

function AddBuildingForm() {
  const [values, setValues] = useState(initialValues);

  const handleInputChange = (e) => {
    const { name, value } = e;
    setValues({
      ...values,
      [name]: value,
    });
  };
  return (
    <form>
      <Grid container spacing={1}>
        <Grid item xs={12} sm={6}>
          <TextField
            variant="outlined"
            margin="normal"
            required
            label="Building Name"
            name="buildingName"
            value={values.buildingName}
            autoFocus
            fullWidth
          />
        </Grid>
        <Grid item xs={12} sm={6}>
          <TextField
            variant="outlined"
            margin="normal"
            required
            label="Number Of Units"
            name="numberOfUnits"
            value={values.numberOfUnits}
            fullWidth
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
            fullWidth
          />
        </Grid>
        <Grid item xs={2}>
          <Button variant="contained" color="primary" fullWidth>
            Add
          </Button>
        </Grid>
        <Grid item xs={2}>
          <Button variant="contained" color="secondary" fullWidth>
            Cancel
          </Button>
        </Grid>
      </Grid>
    </form>
  );
}

export default AddBuildingForm;
