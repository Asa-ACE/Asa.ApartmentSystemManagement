import React from "react";
import { Tab, Tabs } from "@material-ui/core";
import TabPanel from "./TabPanel";
import { makeStyles } from "@material-ui/core";
import CustomTab from "./CustomTab";

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

function CustomTabs(props) {
  const classes = useStyles();
  const { children } = props;
  const tabs = children;
  const [value, setValue] = React.useState(0);

  const handleChange = (event, newValue) => {
    setValue(newValue);
  };
  console.log('ali');
  console.log(tabs);
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
            label={tab.props.name}
            {...{
              id: `vertical-tab-${index}`,
              "aria-controls": `vertical-tabpanel-${index}`,
            }}
          />
        ))}
      </Tabs>
      {tabs.map((tab, index) => (
        <TabPanel value={value} index={index}>
          {tab.props.children}
        </TabPanel>
      ))}
    </div>
  );
}

export default CustomTabs;
