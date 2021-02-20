import React from "react";
import { Tab, Tabs } from "@material-ui/core";
import TabPanel from "./TabPanel";
import { makeStyles } from "@material-ui/core";

const useStyles = makeStyles((theme) => ({
  root: {
    flexGrow: 1,
    backgroundColor: theme.palette.background.paper,
    display: "flex",
  },
  tabs: {
    borderRight: `1px solid ${theme.palette.divider}`,
  },
}));

function TabsContainer(props) {
  const classes = useStyles();
  //const { tabs } = props;
  const tabs = [{ name: "ali", element: new TabPanel() }];
  const [value, setValue] = React.useState(0);

  const handleChange = (event, newValue) => {
    setValue(newValue);
  };

  return (
    <div className={classes.root}>
      <Tabs
        orientation="vertical"
        variant="scrollable"
        value={value}
        onChange={handleChange}
        aria-label="Vertical tabs example"
        className={classes.tabs}
      >
        {tabs.map((tab, index) => (
          <Tab
            label={tab.name}
            {...{
              id: `vertical-tab-${index}`,
              "aria-controls": `vertical-tabpanel-${index}`,
            }}
          />
        ))}
      </Tabs>
      {tabs.map((tab, index) => (
        <TabPanel value={value} index={index}>
          ali
        </TabPanel>
      ))}
    </div>
  );
}

export default TabsContainer;
