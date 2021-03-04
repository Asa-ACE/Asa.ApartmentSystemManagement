import { DataGrid } from "@material-ui/data-grid";

function ChargeItemTable(props) {
  const { rows } = props;
  const columns = [
    { field: "expanseName", headerName: "Expanse Name", width: 200 },
    { field: "amount", headerName: "Amount", width: 150 },
    { field: "from", headerName: "From", width: 200 },
    { field: "to", headerName: "To", width: 200 },
  ];
  return (
    <div style={{ height: 450, width: "100%" }}>
      <DataGrid
        rows={[
          {
            id: 1,
            expanseName: "Hello",
            amount: "2",
            from: "1/1/99",
            to: "2/1/99",
          },
          {
            id: 2,
            expanseName: "Hello",
            amount: "2",
            from: "1/1/99",
            to: "2/1/99",
          },
          {
            id: 3,
            expanseName: "Hello",
            amount: "2",
            from: "1/1/99",
            to: "2/1/99",
          },
          {
            id: 4,
            expanseName: "Hello",
            amount: "2",
            from: "1/1/99",
            to: "2/1/99",
          },
          {
            id: 5,
            expanseName: "Hello",
            amount: "2",
            from: "1/1/99",
            to: "2/1/99",
          },
          {
            id: 6,
            expanseName: "Hello",
            amount: "2",
            from: "1/1/99",
            to: "2/1/99",
          },
          {
            id: 7,
            expanseName: "Hello",
            amount: "2",
            from: "1/1/99",
            to: "2/1/99",
          },
          {
            id: 8,
            expanseName: "Hello",
            amount: "2",
            from: "1/1/99",
            to: "2/1/99",
          },
          {
            id: 9,
            expanseName: "Hello",
            amount: "2",
            from: "1/1/99",
            to: "2/1/99",
          },
        ]}
        columns={columns}
        pageSize={5}
        checkboxSelection
      />
    </div>
  );
}

export default ChargeItemTable;
