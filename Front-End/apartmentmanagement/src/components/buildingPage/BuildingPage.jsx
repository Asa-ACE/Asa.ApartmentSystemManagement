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
import BuildingInfo from "./BuildingInfo";
import AddExpanse from "./AddExpanse"

const useStyles = makeStyles((theme) => ({

  paper: {
    margin: theme.spacing(8, 4),
    display: "flex",
    flexDirection: "row",
    alignItems: "center",
  },
}));

function BuildingPage() {
  const classes = useStyles();
  return (
    <Paper className={classes.paper}>
      <BuildingInfo/>
      <AddExpanse/>
    </Paper>
  );
}

export default BuildingPage;
