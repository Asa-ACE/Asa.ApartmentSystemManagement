import { Divider, Grid, Typography } from "@material-ui/core";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { apiService } from "../../../services/apiService";

function BuildingInfo() {
  const { buildingId } = useParams();
  const [building, setBuilding] = useState({});
  useEffect(async () => {
    const data = await apiService.getRequest(`building/${buildingId}`);
    setBuilding(data);
    console.log(data);
  }, []);
  //const building = { Name: "Hard", NumberOfUnits: 10, Address: "ssssss" };

  return (
    <>
      <Grid container>
        <Grid item xs={12} justify="center">
          <Typography variant="h3">{building.name}</Typography>
          <Divider />
        </Grid>
        <Grid item xs={12} justify="center">
          <Typography variant="h6">
            Number Of Units: {building.numberOfUnits}
          </Typography>
        </Grid>
        <Grid item xs={12} justify="center">
          <Typography variant="h6">Address: {building.address}</Typography>
        </Grid>
      </Grid>
    </>
  );
}

export default BuildingInfo;
