import {
  Collapse,
  IconButton,
  TableCell,
  TableRow,
  Box,
  Typography,
  makeStyles,
} from "@material-ui/core";
import KeyboardArrowUpIcon from "@material-ui/icons/KeyboardArrowUp";
import KeyboardArrowDownIcon from "@material-ui/icons/KeyboardArrowDown";
import { useState } from "react";
import ChargeItemTable from "./ChargeItemTable";

const useStyle = makeStyles({
  root: {
    "& > *": {
      borderBottom: "unset",
    },
  },
  sub: {
    paddingBottom: 0,
    paddingTop: 0,
  },
});

function UnitChargeRow(props) {
  const { row } = props;
  const [open, setOpen] = useState(false);
  const classes = useStyle();
  let sum = 0;
  row.chargeItems.forEach((chargeItem) => (sum += chargeItem.amount));

  return (
    <>
      <TableRow className={classes.root}>
        <TableCell>
          <IconButton
            aria-label="expand row"
            size="small"
            onClick={() => setOpen(!open)}
          >
            {open ? <KeyboardArrowUpIcon /> : <KeyboardArrowDownIcon />},
          </IconButton>
        </TableCell>
        <TableCell>{row.from}</TableCell>
        <TableCell>{row.to}</TableCell>
        <TableCell>{sum}</TableCell>
      </TableRow>
      <TableRow>
        <TableCell className={classes.sub} colspan={4}>
          <Collapse in={open} timeout="auto" unmountOnExit>
            <Box margin={5}>
              <Typography variant="h6" gutterBottom component="div">
                Details
              </Typography>
              <ChargeItemTable />
            </Box>
          </Collapse>
        </TableCell>
      </TableRow>
    </>
  );
}

export default UnitChargeRow;
