import React, { useRef } from "react";
import Avatar from "@material-ui/core/Avatar";
import Button from "@material-ui/core/Button";
import CssBaseline from "@material-ui/core/CssBaseline";
import TextField from "@material-ui/core/TextField";
import { Link } from "react-router-dom";
import Paper from "@material-ui/core/Paper";
import Grid from "@material-ui/core/Grid";
import LockOutlinedIcon from "@material-ui/icons/LockOutlined";
import Typography from "@material-ui/core/Typography";
import { makeStyles } from "@material-ui/core/styles";

const useStyles = makeStyles((theme) => ({
  root: {
    height: "100vh",
  },
  image: {
    backgroundImage:
      "url(https://www.teahub.io/photos/full/106-1062458_cyberpunk-2077-night-city-wallpaper-4k.png)",
    backgroundRepeat: "no-repeat",
    backgroundColor:
      theme.palette.type === "light"
        ? theme.palette.grey[50]
        : theme.palette.grey[900],
    backgroundSize: "cover",
    backgroundPosition: "center",
  },
  paper: {
    margin: theme.spacing(8, 4),
    display: "flex",
    flexDirection: "column",
    alignItems: "center",
  },
  avatar: {
    margin: theme.spacing(1),
    backgroundColor: theme.palette.secondary.main,
  },
  form: {
    width: "100%", // Fix IE 11 issue.
    marginTop: theme.spacing(1),
  },
  submit: {
    margin: theme.spacing(3, 0, 2),
  },
}));

function Register() {
  const usernameInput = useRef(null);
  const passwordInput = useRef(null);
  const passwordRepeatInput = useRef(null);
  const firstNameInput = useRef(null);
  const lastNameInput = useRef(null);
  const phoneNumberInput = useRef(null);

  const classes = useStyles();
  const handleSubmit = (e) => {
    e.preventDefault();
    console.log(
      `${usernameInput.current.value} : ${passwordInput.current.value}`
    );
    console.log(usernameInput);
  };
  return (
    <Grid container component="main" className={classes.root}>
      <CssBaseline />
      <Grid item xs={false} sm={4} md={7} className={classes.image}></Grid>
      <Grid item xs={12} sm={8} md={5} component={Paper} elevation={6} square>
        <div className={classes.paper}>
          <Avatar className={classes.avatar}>
            <LockOutlinedIcon />
          </Avatar>
          <Typography component="h1" variant="h5">
            ثبت نام
          </Typography>
          <form
            className={classes.form}
            noValidate
            onSubmit={(e) => handleSubmit(e)}
          >
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
              inputRef={usernameInput}
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
              inputRef={passwordInput}
            />
            <TextField
              variant="outlined"
              margin="normal"
              required
              fullWidth
              name="passwordRepeat"
              label="تکرار رمز عبور"
              type="password"
              id="passwordRepeat"
              inputRef={passwordRepeatInput}
            />

            <TextField
              variant="outlined"
              margin="normal"
              required
              fullWidth
              name="firstName"
              label="نام"
              type="name"
              id="firstName"
              inputRef={firstNameInput}
            />
            <TextField
              variant="outlined"
              margin="normal"
              required
              fullWidth
              name="lastName"
              label="نام خانوادگی"
              type="name"
              id="lastName"
              inputRef={lastNameInput}
            />
            <TextField
              variant="outlined"
              margin="normal"
              required
              fullWidth
              name="phoneNumber"
              label="شماره تلفن"
              type="phonenumber"
              id="phoneNumber"
              autoComplete="current-password"
              inputRef={phoneNumberInput}
            />
            <Button
              type="submit"
              fullWidth
              variant="contained"
              color="primary"
              className={classes.submit}
            >
              ثبت نام
            </Button>
            <Grid container>
              <Grid item>
                <Link to="/login" variant="body2">
                  {"حساب کاربری دارید؟ وارد شوید"}
                </Link>
              </Grid>
            </Grid>
          </form>
        </div>
      </Grid>
    </Grid>
  );
}

export default Register;