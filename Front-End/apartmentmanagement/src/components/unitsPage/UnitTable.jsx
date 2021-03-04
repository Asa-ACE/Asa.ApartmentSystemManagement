import React from "react";
import { withStyles, makeStyles } from "@material-ui/core/styles";
import Table from "@material-ui/core/Table";
import TableBody from "@material-ui/core/TableBody";
import TableCell from "@material-ui/core/TableCell";
import TableContainer from "@material-ui/core/TableContainer";
import TableHead from "@material-ui/core/TableHead";
import TableRow from "@material-ui/core/TableRow";
import Paper from "@material-ui/core/Paper";

const StyledTableCell = withStyles((theme) => ({
  head: {
    backgroundColor: theme.palette.common.black,
    color: theme.palette.common.white,
  },
  body: {
    fontSize: 14,
  },
}))(TableCell);

const StyledTableRow = withStyles((theme) => ({
  root: {
    "&:nth-of-type(odd)": {
      backgroundColor: theme.palette.action.hover,
    },
  },
}))(TableRow);

function createData(description, area, number, id) {
  return { description, area, number, id };
}

const units = [
  createData("Frozen yoghurt", 159, 6, 24),
  createData("Ice cream sandwich", 237, 9, 37),
  createData("Eclair", 262, 16, 24),
  createData("Cupcake", 305, 3, 67),
];

const useStyles = makeStyles({
  table: {
    minWidth: 700,
  },
});

export default function UnitTable() {
  const classes = useStyles();

  return (
    <TableContainer component={Paper}>
      <Table className={classes.table} aria-label="customized table">
        <TableHead>
          <TableRow>
            <StyledTableCell>توضیحات</StyledTableCell>
            <StyledTableCell align="right">مساحت</StyledTableCell>
            <StyledTableCell align="right">شماره واحد</StyledTableCell>
            <StyledTableCell align="right">کد واحد</StyledTableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {units.map((unit) => (
            <StyledTableRow key={unit.number}>
              <StyledTableCell component="th" scope="row">
                {unit.description}
              </StyledTableCell>
              <StyledTableCell align="right">{unit.area}</StyledTableCell>
              <StyledTableCell align="right">{unit.number}</StyledTableCell>
              <StyledTableCell align="right">{unit.id}</StyledTableCell>
            </StyledTableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
}
