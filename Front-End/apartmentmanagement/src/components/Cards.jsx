import React from "react";
import BuildingCard from "./BuildingCard";
import Box from "@material-ui/core/Box";

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
function Cards({ BuildingData }) {
  return (
    <Box display="flex" flexWrap="wrap" justifyContent="center">
      {BuildingData.map((item, index) => {
        return (
          <Box
            borderRadius={5}
            {...defaultProps}
            borderColor={borderColors[index % borderColors.length]}
            m={3}
            key={index}
          >
            <BuildingCard
              BuildingData={item}
              key={index}
              bg={backgroundColors[index % backgroundColors.length]}
            />
          </Box>
        );
      })}
    </Box>
  );
}

export default Cards;