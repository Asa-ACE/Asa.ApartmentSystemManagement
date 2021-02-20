import { makeStyles } from "@material-ui/core";
import { createContext, React, useState } from "react";
import Navbar from "./Navbar";
import Sidebar from "./Sidebar";
import clsx from "clsx";

export const SidebarContext = createContext();
export const drawerWidth = 240;

const useStyle = makeStyles((theme) => ({
  content: {
    flexGrow: 1,
    padding: theme.spacing(3),
    transition: theme.transitions.create("margin", {
      easing: theme.transitions.easing.sharp,
      duration: theme.transitions.duration.leavingScreen,
    }),
    marginLeft: -drawerWidth,
  },
  contentShift: {
    transition: theme.transitions.create("margin", {
      easing: theme.transitions.easing.easeOut,
      duration: theme.transitions.duration.enteringScreen,
    }),
    marginLeft: 0,
  },
}));

function Dashboard() {
  const classes = useStyle();
  const [openSidebar, setOpenSidebar] = useState(false);
  return (
    <>
      <SidebarContext.Provider value={{ openSidebar, setOpenSidebar }}>
        <Navbar />
        <Sidebar />
      </SidebarContext.Provider>
      <main
        className={clsx(classes.content, {
          [classes.contentShift]: openSidebar,
        })}
      />
    </>
  );
}
