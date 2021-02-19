import React, { useRef } from "react";
import Avatar from "@material-ui/core/Avatar";
import Button from "@material-ui/core/Button";
import CssBaseline from "@material-ui/core/CssBaseline";
import TextField from "@material-ui/core/TextField";
import Link from "@material-ui/core/Link";
import Paper from "@material-ui/core/Paper";
import Grid from "@material-ui/core/Grid";
import LockOutlinedIcon from "@material-ui/icons/LockOutlined";
import Typography from "@material-ui/core/Typography";
import MenuItem from '@material-ui/core/MenuItem';
import { makeStyles } from "@material-ui/core/styles";



const categories = [
    {
      value: '12',
      label: 'قبوض',
    },
    {
      value: '13',
      label: 'تعمیرات',
    },
    {
      value: '14',
      label: 'نظافت',
    },
  ];



const useStyles = makeStyles((theme) => ({
  root: {
    height: "100vh",
  },
  paper: {
    margin: theme.spacing(8, 4),
    display: "flex",
    flexDirection: "column",
    alignItems: "center",
  },
  form: {
    width: "100%", // Fix IE 11 issue.
    marginTop: theme.spacing(1),
  },
  submit: {
    margin: theme.spacing(0.5, 0, 3.5),
  },
}));

function AddExpanse() {
  const titleInput = useRef(null);
  const amountInput = useRef(null);
  const fromInput = useRef(null);
  const toInput = useRef(null);


  const classes = useStyles();
  const handleSubmit = (e) => {
    e.preventDefault();
    console.log(`salam`);
  };




  const [catgory, setCategory] = React.useState('12');
  const handleChange = (event) => {
    setCategory(event.target.value);
  };
  
  return (
    <Paper className={classes.paper}>
      <Typography component="h1" variant="h5" >
        ثبت هزینه
      </Typography>
      <form onSubmit={(e) => handleSubmit(e)}>
        <TextField
          variant="outlined"
          margin="normal"
          required
          fullWidth
          id="title"
          label="عنوان"
          name="title"
          inputRef={titleInput}
        />
        
        <TextField
          variant="outlined"
          margin="normal"
          required
          fullWidth
          name="amount"
          label="مبلغ"
          type="number"
          id="amount"
          innerRef={amountInput}
        />  

        <TextField
          variant="outlined"
          margin="normal"
          required
          fullWidth
          name="from"
          label="از"
          type="date"
          id="from"
          innerRef={fromInput}
        />        

        <TextField
          variant="outlined"
          margin="normal"
          required
          fullWidth
          name="to"
          label="تا"
          type="date"
          id="to"
          innerRef={toInput}
        />

        <TextField
          id="ExpanseCategory"
          select
          fullWidth
          label="نوع هزینه"
          value={catgory}
          onChange={handleChange}
          variant="filled"
        >
          {categories.map((option) => (
            <MenuItem key={option.value} value={option.value}>
              {option.label}
            </MenuItem>
          ))}
        </TextField>

        <Button
          fullWidth
          variant="contained"
          color="primary"
          type="submit"
          className={classes.submit}
        >
          ثبت هزینه
        </Button>
      </form>
    </Paper>
    
  );
}

export default AddExpanse;
