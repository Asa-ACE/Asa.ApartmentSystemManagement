import React, { useEffect, useState } from "react";
import BuildingCard from "./BuildingCard";
import Box from "@material-ui/core/Box";
import { apiService } from "../services/apiService";
import { Button, Grid } from "@material-ui/core";
import { useStyles } from "@material-ui/pickers/views/Calendar/SlideTransition";
import ModalForm from "./ModalForm";
import AddBuildingForm from "./Forms/AddBuildingForm";

const defaultProps = {
  bgcolor: "background.paper",
  border: 1,
};

const borderColors = ["lightblue", "lightgreen", "yellow", "lightred", "pink"];
const backgroundColors = [
  "#ffebee",
  "#fce4ec",
  "#f3e5f5",
  "#ede7f6",
  "#e8eaf6",
  "#e3f2fd",
  "#e0f2f1",
  "#f9fbe7",
  "#fff3e0",
  "#eceff1",
];
function Cards() {
  const [buildings, setBuildings] = useState([]);
  const [openAdd, setOpenAdd] = useState(false);
  useEffect(async () => {
    const data = await apiService.getRequest("building");
    console.log(data);
    setBuildings(data);
  }, []);
  console.log(buildings);

  return (
    <Grid container>
      <Grid item xs={12}>
        <Box display="flex" flexWrap="wrap" justifyContent="center">
          {buildings.map((item, index) => {
            return (
              <Box
                borderRadius={5}
                {...defaultProps}
                borderColor={borderColors[index % borderColors.length]}
                m={3}
                key={index}
              >
                <BuildingCard
                  building={item}
                  key={index}
                  bg={backgroundColors[index % backgroundColors.length]}
                />
              </Box>
            );
          })}
        </Box>
      </Grid>
      <Grid item xs={12}>
        <Button
          variant="contained"
          color="primary"
          onClick={() => setOpenAdd(true)}
        >
          Add Building
        </Button>
      </Grid>
      <ModalForm
        open={openAdd}
        title="New Building"
        onClose={() => setOpenAdd(false)}
      >
        <AddBuildingForm
          buildings={buildings}
          setBuildings={setBuildings}
          handleClose={() => setOpenAdd(false)}
        />
      </ModalForm>
    </Grid>
  );
}

export default Cards;
