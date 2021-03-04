import { makeStyles, Paper, Box } from "@material-ui/core";
import React, { createContext, useState, useEffect } from "react";
import Navbar from "./Navbar";
import Sidebar from "./Sidebar";
import clsx from "clsx";

export const SidebarContext = createContext([]);
export const drawerWidth = 240;

const useStyle = makeStyles((theme) => ({
  container: {
    height: "100vh",
    backgroundColor: "#e3e3e3",
  },
  content: {
    flexGrow: 1,
    padding: theme.spacing(3),
    transition: theme.transitions.create("margin", {
      easing: theme.transitions.easing.sharp,
      duration: theme.transitions.duration.leavingScreen,
    }),
    marginLeft: 0,
  },
  toolbar: {
    ...theme.mixins.toolbar,
    flexGrow: 1,
  },
  contentShift: {
    transition: theme.transitions.create("margin", {
      easing: theme.transitions.easing.easeOut,
      duration: theme.transitions.duration.enteringScreen,
    }),
    marginLeft: drawerWidth,
  },
  paper: {
    padding: theme.spacing(2),
    display: "flex",
    overflow: "auto",
    flexDirection: "column",
  },
}));

function Template(props) {
  const { children } = props;
  const classes = useStyle();
  const [openSidebar, setOpenSidebar] = useState(false);

  return (
    <div className={classes.container}>
      <SidebarContext.Provider value={{ openSidebar, setOpenSidebar }}>
        <Navbar />
        <Sidebar />
      </SidebarContext.Provider>
      <div className={classes.toolbar} />
      <div
        className={clsx(classes.content, {
          [classes.contentShift]: openSidebar,
        })}
      >
        <Paper className={classes.paper}>
          <Box m={2}>{children}</Box>
        </Paper>
      </div>
    </div>
  );
}

export default Template;
