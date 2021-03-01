import React, { useContext } from "react";
import { makeStyles } from "@material-ui/core/styles";
import AppBar from "@material-ui/core/AppBar";
import Toolbar from "@material-ui/core/Toolbar";
import Typography from "@material-ui/core/Typography";
import Button from "@material-ui/core/Button";
import IconButton from "@material-ui/core/IconButton";
import MenuIcon from "@material-ui/icons/Menu";
import ClickAwayListener from "@material-ui/core/ClickAwayListener";
import Grow from "@material-ui/core/Grow";
import Paper from "@material-ui/core/Paper";
import Popover from "@material-ui/core/Popover";
import MenuList from "@material-ui/core/MenuList";
import { Box } from "@material-ui/core";
import { SidebarContext } from "./Template";
import clsx from "clsx";
import { drawerWidth } from "./Template";
import PopupState, { bindTrigger, bindPopover } from "material-ui-popup-state";

const useStyles = makeStyles((theme) => ({
  root: {
    flexGrow: 1,
  },
  appBar: {
    transition: theme.transitions.create(["margin", "width"], {
      easing: theme.transitions.easing.sharp,
      duration: theme.transitions.duration.leavingScreen,
    }),
  },
  appBarShift: {
    width: `calc(100% - ${drawerWidth}px)`,
    marginLeft: drawerWidth,
    transition: theme.transitions.create(["margin", "width"], {
      easing: theme.transitions.easing.easeOut,
      duration: theme.transitions.duration.enteringScreen,
    }),
  },
  menuButton: {
    marginRight: theme.spacing(2),
  },
  title: {
    flexGrow: 1,
  },
  profile: {
    color: "white",
  },
  profileContainer: {},
  hide: {
    display: "none",
  },
  menuPopper: {
    zIndex: "1500",
  },
}));

function Navbar() {
  const classes = useStyles();
  const [openMenue, setOpenMenue] = React.useState(false);
  const anchorRef = React.useRef(null);
  const { openSidebar, setOpenSidebar } = useContext(SidebarContext);

  const handleDrawerOpen = () => {
    setOpenSidebar(true);
  };

  return (
    <AppBar
      position="fixed"
      className={clsx(classes.appBar, {
        [classes.appBarShift]: openSidebar,
      })}
    >
      <Toolbar>
        <IconButton
          edge="start"
          className={clsx(classes.menuButton, openSidebar && classes.hide)}
          color="inherit"
          aria-label="menu"
          onClick={handleDrawerOpen}
        >
          <MenuIcon />
        </IconButton>
        <Typography variant="h4" className={classes.title}>
          ChargeAsa
        </Typography>
        <PopupState variant="popover" popupId="popup">
          {(popupState) => (
            <>
              <Button
                aria-controls={openMenue ? "menu-list-grow" : undefined}
                aria-haspopup="true"
                {...bindTrigger(popupState)}
              >
                <Typography variant="h6" className={classes.profile}>
                  AmirHossein
                </Typography>
              </Button>
              <Popover
                {...bindPopover(popupState)}
                anchorOrigin={{
                  vertical: "bottom",
                  horizontal: "center",
                }}
                transformOrigin={{
                  vertical: "top",
                  horizontal: "center",
                }}
              >
                <Box p={2}>
                  <Button variant="contained" color="primary">
                    <Typography>Logout</Typography>
                  </Button>
                </Box>
              </Popover>
            </>
          )}
        </PopupState>
      </Toolbar>
    </AppBar>
  );
}

export default Navbar;
