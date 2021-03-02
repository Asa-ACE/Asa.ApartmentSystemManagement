import { makeStyles, useTheme } from "@material-ui/core";
import { useContext } from "react";
import { Link } from "react-router-dom";
import { SidebarContext } from "./Template";
import ChevronLeftIcon from "@material-ui/icons/ChevronLeft";
import ChevronRightIcon from "@material-ui/icons/ChevronRight";
import ListItem from "@material-ui/core/ListItem";
import ListItemText from "@material-ui/core/ListItemText";
import List from "@material-ui/core/List";
import Divider from "@material-ui/core/Divider";
import IconButton from "@material-ui/core/IconButton";
import Drawer from "@material-ui/core/Drawer";
import ListItemIcon from "@material-ui/core/ListItemIcon";
import { drawerWidth } from "./Template";
import MeetingRoomRoundedIcon from "@material-ui/icons/MeetingRoomRounded";
import ApartmentRoundedIcon from "@material-ui/icons/ApartmentRounded";

const useStyle = makeStyles((theme) => ({
  hide: {
    display: "none",
  },
  drawer: {
    width: drawerWidth,
    flexShrink: 0,
  },
  drawerPaper: {
    width: drawerWidth,
    boxShadow:
      "0 5px 10px -3px rgba(0,0,0,.23), 0 6px 10px -5px rgba(0,0,0,.25)",
    borderRadius: "35",
  },
  drawerHeader: {
    display: "flex",
    alignItems: "center",
    padding: theme.spacing(0, 1),
    ...theme.mixins.toolbar,
    justifyContent: "flex-end",
  },
}));

function Sidebar() {
  const classes = useStyle(drawerWidth);
  const { openSidebar, setOpenSidebar } = useContext(SidebarContext);
  const theme = useTheme();

  const handleDrawerClose = () => {
    setOpenSidebar(false);
  };

  return (
    <Drawer
      className={classes.drawer}
      variant="persistent"
      anchor="left"
      open={openSidebar}
      classes={{
        paper: classes.drawerPaper,
      }}
    >
      <div className={classes.drawerHeader}>
        <IconButton onClick={handleDrawerClose}>
          {theme.direction === "ltr" ? (
            <ChevronLeftIcon />
          ) : (
            <ChevronRightIcon />
          )}
        </IconButton>
      </div>
      <Divider />
      <List>
        <ListItem button key="Buildings" component={Link} to="/buildings">
          <ListItemIcon>
            <ApartmentRoundedIcon />
          </ListItemIcon>
          <ListItemText primary="Buildings" />
        </ListItem>
        <ListItem button key="Units" component={Link} to="/units~">
          <ListItemIcon>
            <MeetingRoomRoundedIcon />
          </ListItemIcon>
          <ListItemText primary="Units" />
        </ListItem>
      </List>
    </Drawer>
  );
}

export default Sidebar;
