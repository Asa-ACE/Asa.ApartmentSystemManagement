import React from "react";
import { makeStyles } from "@material-ui/core/styles";
import Button from "@material-ui/core/Button";
import Popper from "@material-ui/core/Popper";
import Typography from "@material-ui/core/Typography";
import { Grid } from "@material-ui/core";
import Grow from "@material-ui/core/Grow";
import Paper from "@material-ui/core/Paper";
import TextField from "@material-ui/core/TextField";

function AddUnit() {
  const [openMenue, setOpenMenue] = React.useState(false);
  const anchorRef = React.useRef(null);
  const handleToggle = () => {
    console.log(openMenue);
    setOpenMenue((prevOpen) => !prevOpen);
    console.log(openMenue);
  };
  const prevOpen = React.useRef(openMenue);
  React.useEffect(() => {
    if (prevOpen.current === true && openMenue === false) {
      anchorRef.current.focus();
    }

    prevOpen.current = openMenue;
  }, [openMenue]);

  return (
    <Grid>
      <Button
        aria-controls={openMenue ? "menu-list-grow" : undefined}
        aria-haspopup="true"
        onClick={() => {
          handleToggle();
        }}
        ref={anchorRef}
      >
        <Typography variant="h6">اضافه کردن واحد</Typography>
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
              <form noValidate>
                <TextField
                  variant="outlined"
                  margin="normal"
                  required
                  fullWidth
                  id="username"
                  label="نام کاربری"
                  name="username"
                  autoComplete="username"
                  autoFocus
                />
                <TextField
                  variant="outlined"
                  margin="normal"
                  required
                  fullWidth
                  name="password"
                  label="رمز عبور"
                  type="password"
                  id="password"
                  autoComplete="current-password"
                />
                <Button
                  type="submit"
                  fullWidth
                  variant="contained"
                  color="primary"
                >
                  ورود
                </Button>
              </form>
            </Paper>
          </Grow>
        )}
      </Popper>
    </Grid>
  );
}

export default AddUnit;
