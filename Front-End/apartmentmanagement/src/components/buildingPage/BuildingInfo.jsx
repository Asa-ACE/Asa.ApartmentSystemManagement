import React, { useRef } from "react";
import Avatar from "@material-ui/core/Avatar";
import Button from "@material-ui/core/Button";
import CssBaseline from "@material-ui/core/CssBaseline";
import TextField from "@material-ui/core/TextField";
import Link from "@material-ui/core/Link";
import Paper from "@material-ui/core/Paper";
import Grid from "@material-ui/core/Grid";
import LockOutlinedIcon from "@material-ui/icons/LockOutlined";
import Typography from "@material-ui/core/Typography";
import { makeStyles } from "@material-ui/core/styles";

const useStyles = makeStyles((theme) => ({
  root: {
    height: "100vh",
  },
  paper: {
    margin: theme.spacing(8, 4),
    display: "flex",
    flexDirection: "column",
    alignItems: "center",
  },
  form: {
    width: "100%", // Fix IE 11 issue.
    marginTop: theme.spacing(1),
  },
  submit: {
    margin: theme.spacing(0.5, 0, 3.5),
  },
}));

function BuildingInfo() {
  const nameInput = useRef(null);

  const classes = useStyles();
  const handleSubmit = (e) => {
    e.preventDefault();
    console.log(`${nameInput.current.value}`);
  };

  return (
    <Paper className={classes.paper}>
      <Typography component="h1" variant="h5">
        Building Information
      </Typography>
      <form onSubmit={(e) => handleSubmit(e)}>
        <TextField
          variant="outlined"
          margin="normal"
          required
          fullWidth
          id="username"
          label="Building Name"
          name="username"
          defaultValue="apartment"
          inputRef={nameInput}
        />
        <Button
          variant="contained"
          color="primary"
          type="submit"
          className={classes.submit}
        >
          Change Building Name
        </Button>
        <TextField
          variant="outlined"
          margin="normal"
          disabled
          fullWidth
          name="numberOfUnit"
          label="Number Of Units"
          type="number"
          id="numberOfUnit"
          value="20"
        />
      </form>
    </Paper>
  );
}

export default BuildingInfo;
