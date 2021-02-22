import { makeStyles, useTheme } from "@material-ui/core";
import { useContext } from "react";
import { SidebarContext } from "./Dashboard";
import ChevronLeftIcon from "@material-ui/icons/ChevronLeft";
import ChevronRightIcon from "@material-ui/icons/ChevronRight";
import ListItem from "@material-ui/core/ListItem";
import ListItemIcon from "@material-ui/core/ListItemIcon";
import ListItemText from "@material-ui/core/ListItemText";
import List from "@material-ui/core/List";
import Typography from "@material-ui/core/Typography";
import Divider from "@material-ui/core/Divider";
import IconButton from "@material-ui/core/IconButton";
import Drawer from "@material-ui/core/Drawer";
import { drawerWidth } from "./Dashboard";

const useStyle = makeStyles((theme) => ({
  hide: {
    display: "none",
  },
  drawer: {
    width: drawerWidth ,
    flexShrink: 0,
  },
  drawerPaper: {
    width: drawerWidth ,
    backgroundColor:"#E91E63",
    boxShadow: "0 5px 10px -3px rgba(0,0,0,.23), 0 6px 10px -5px rgba(0,0,0,.25)",
    borderRadius: "35"
  },
  drawerHeader: {
    display: "flex",
    alignItems: "center",
    padding: theme.spacing(0, 1),
    ...theme.mixins.toolbar,
    justifyContent: "flex-end",
    backgroundColor:"#3f51b5",
  },
}));

function Sidebar(props) {
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
        <ListItem button>
          <ListItemText primary="ساختمان ها" />
        </ListItem>
        <ListItem button>
          <ListItemText primary="واحد ها" />
        </ListItem>
      </List>
    </Drawer>
  );
}

export default Sidebar;
