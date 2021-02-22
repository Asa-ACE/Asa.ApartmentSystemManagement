import React, { createContext } from "react";
import StyledTab from "./StyledTab";
import StyledTabs from "./StyledTabs";
import TabPanel from "./TabPanel";
import { makeStyles } from "@material-ui/core";
import {Grid} from "@material-ui/core";

const useStyles = makeStyles((theme) => ({
  root: {
    flexGrow: 1,
    backgroundColor: theme.palette.background.paper,
    display: "flex",
  },
  container: {
    padding: theme.spacing(3),
  },
}));

export const TabsContext = createContext(null);

function TabsContainer(props) {
  const classes = useStyles();
  const children = React.Children.toArray(props.children);

  const [value, setValue] = React.useState(0);

  return (
    <div className={classes.root}>
      <TabsContext.Provider value={{value, setValue}}>
        <Grid container>
          <Grid item xs={12}>
            <StyledTabs>
              {children.map((tab, index) => (
                <StyledTab
                  label={tab.props.label}
                  {...{
                    id: `tab-`,
                    "aria-controls": `tabpanel-`,
                  }}
                />
              ))}
            </StyledTabs>
          </Grid>
          {children.map((tab, index) => (
            <TabPanel value={value} index={index}>
              {tab.props.children}
            </TabPanel>
          ))}
        </Grid>
      </TabsContext.Provider>
    </div>
  );
}

export default TabsContainer;
