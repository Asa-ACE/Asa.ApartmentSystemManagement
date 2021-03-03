import { Divider, Grid, Typography } from "@material-ui/core";
import { useParams } from "react-router-dom";
import { apiService } from "../../../services/apiService";

function BuildingInfo() {
  const { buildingId } = useParams();
  const building = apiService.getRequest(`/building/${buildingId}`);
  //const building = { Name: "Hard", NumberOfUnits: 10, Address: "ssssss" };
  return (
    <>
      <Typography variant="h3">{building.Name}</Typography>
      <Divider />
      <Typography variant="h6">Number Of Units: </Typography>
      <Typography variant="body1">
        {building.NumberOfUnits}
        <br />
      </Typography>
      <Typography variant="h6">Address: </Typography>
      <Typography variant="body1">
        {building.Address}
        <br />
      </Typography>
    </>
  );
}

export default BuildingInfo;
