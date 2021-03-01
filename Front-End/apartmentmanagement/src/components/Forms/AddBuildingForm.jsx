import { Grid, TextField } from "@material-ui/core";

function AddBuildingForm() {
  return (
    <form>
      <Grid container>
        <Grid item xs={12} sm={6}>
          <TextField
            variant="outlined"
            margin="normal"
            required
            label="Building Name"
            name="name"
            autoFocus
          />
        </Grid>
        <Grid item xs={12} sm={6}>
          <TextField
            variant="outlined"
            margin="normal"
            required
            label="Building Name"
            name="numberOfUnits"
          />
        </Grid>
        <Grid item xs={12}>
          <TextField
            variant="outlined"
            margin="normal"
            required
            label="Address"
            name="address"
          />
        </Grid>
      </Grid>
    </form>
  );
}

export default AddBuildingForm;
