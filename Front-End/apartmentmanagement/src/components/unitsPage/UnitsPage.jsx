import React, { useRef } from "react";
import Paper from "@material-ui/core/Paper";
import { makeStyles } from "@material-ui/core/styles";
import AddUnit from "./AddUnit";
import UnitTable from "./UnitTable";

const useStyles = makeStyles((theme) => ({
  paper: {
    margin: theme.spacing(8, 4),
    display: "flex",
    flexDirection: "column",
    alignItems: "center",
  },
}));

function UnitsPage() {
  const classes = useStyles();
  return (
    <Paper className={classes.paper}>
      <UnitTable />
      <AddUnit />
    </Paper>
  );
}

export default UnitsPage;
