import React, { useRef } from "react";
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

  const numberInput = useRef(null);
  const areaInput = useRef(null);
  const descriptionInput = useRef(null);

  const handleSubmit = (e) => {
    e.preventDefault();
    console.log(
      `${numberInput.current.value} : ${areaInput.current.value}: ${descriptionInput.current.value}`
    );
  };

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
              <form noValidate onSubmit={(e) => handleSubmit(e)}>
                <TextField
                  variant="outlined"
                  margin="normal"
                  required
                  fullWidth
                  id="UnitNumber"
                  label="شماره واحد"
                  name="UnitNumber"
                  type="number"
                  autoFocus
                  inputRef={numberInput}
                />
                <TextField
                  variant="outlined"
                  margin="normal"
                  required
                  fullWidth
                  name="Area"
                  label="مساحت"
                  type="float"
                  id="Area"
                  inputRef={areaInput}
                />
                <TextField
                  variant="outlined"
                  margin="normal"
                  required
                  fullWidth
                  name="Description"
                  label="توضیحات"
                  type="string"
                  id="Description"
                  inputRef={descriptionInput}
                />
                <Button
                  type="submit"
                  fullWidth
                  variant="contained"
                  color="primary"
                  onClick={handleClose}
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
