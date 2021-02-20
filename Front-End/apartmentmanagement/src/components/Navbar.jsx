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
import Popper from "@material-ui/core/Popper";
import MenuItem from "@material-ui/core/MenuItem";
import MenuList from "@material-ui/core/MenuList";
import { Box } from "@material-ui/core";
import { SidebarContext } from "./Dashboard";
import clsx from "clsx";
import { drawerWidth } from "./Dashboard";

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
}));

function Navbar(props) {
  const classes = useStyles();
  const [openMenue, setOpenMenue] = React.useState(false);
  const anchorRef = React.useRef(null);
  const { openSidebar, setOpenSidebar } = useContext(SidebarContext);

  const handleToggle = () => {
    console.log(openMenue);
    setOpenMenue((prevOpen) => !prevOpen);
    console.log(openMenue);
  };

  const handleClose = (event) => {
    if (anchorRef.current && anchorRef.current.contains(event.target)) {
      return;
    }

    setOpenMenue(false);
  };

  const prevOpen = React.useRef(openMenue);
  React.useEffect(() => {
    if (prevOpen.current === true && openMenue === false) {
      anchorRef.current.focus();
    }

    prevOpen.current = openMenue;
  }, [openMenue]);

  const handleDrawerOpen = () => {
    setOpenSidebar(true);
  };

  return (
    <AppBar
      position="static"
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
          شارژآسا
        </Typography>
        <Button
          aria-controls={openMenue ? "menu-list-grow" : undefined}
          aria-haspopup="true"
          onClick={() => {
            console.log("Didid");
            handleToggle();
          }}
          ref={anchorRef}
        >
          <Typography variant="h6" className={classes.profile}>
            امیرحسین
          </Typography>
        </Button>
        <Popper
          open={openMenue}
          anchorEl={anchorRef.current}
          role={undefined}
          transition
          disablePortal
        >
          {({ TransitionProps, placement }) => (
            <Grow
              {...TransitionProps}
              style={{
                transformOrigin:
                  placement === "bottom" ? "center top" : "center bottom",
              }}
            >
              <Paper>
                <ClickAwayListener onClickAway={handleClose}>
                  <MenuList autoFocusItem={openMenue} id="menu-list-grow">
                    <Box width={300} className={classes.profileContainer}>
                      <Typography variant="subtitle1">امیرحسین</Typography>
                    </Box>
                    <Button
                      variant="contained"
                      color="secondary"
                      onClick={handleClose}
                    >
                      خروج
                    </Button>
                  </MenuList>
                </ClickAwayListener>
              </Paper>
            </Grow>
          )}
        </Popper>
      </Toolbar>
    </AppBar>
  );
}

export default Navbar;
