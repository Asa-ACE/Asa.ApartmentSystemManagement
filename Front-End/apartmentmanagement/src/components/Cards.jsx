import React from "react";
import BuildingCard from "./BuildingCard" ;
import Box from '@material-ui/core/Box';

const defaultProps = {
    bgcolor: 'background.paper',
    border: 1,
  };

const borderColors = ['lightblue','lightgreen','yellow','lightred','pink'] ;
function Cards({BuildingData}) {
    return (
        <Box  display="flex" flexWrap="wrap" justifyContent="flex-start">
            {
                BuildingData.map((item,index) => {return <Box borderRadius={5} {...defaultProps}  borderColor={borderColors[index%borderColors.length]} m={1} key={index}><BuildingCard BuildingData={item} key={index}/></Box>})
            }
        </Box>
    );

}

export default Cards ;