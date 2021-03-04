import {
  TableContainer,
  Paper,
  Table,
  Tab,
  TableHead,
  TableRow,
  TableCell,
  TableBody,
} from "@material-ui/core";
import UnitChargeRow from "./UnitChargeRow";

function UnitChargeTable(props) {
  const { rows } = props;
  return (
    <TableContainer component={Paper}>
      <Table>
        <TableHead>
          <TableRow>
            <TableCell />
            <TableCell>From</TableCell>
            <TableCell>To</TableCell>
            <TableCell>Amount</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {rows.map((row) => (
            <UnitChargeRow row={row} />
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
}

export default UnitChargeTable;
