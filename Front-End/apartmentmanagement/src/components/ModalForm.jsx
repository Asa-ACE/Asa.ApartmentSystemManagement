import {
  Dialog,
  DialogContent,
  DialogTitle,
  Divider,
  makeStyles,
} from "@material-ui/core";

const useStyles = makeStyles(() => ({
  title: {
    justifyContent: "center",
    alignContent: "center",
  },
}));

function ModalForm(props) {
  const classes = useStyles();
  const { open, onClose, title, children } = props;
  return (
    <Dialog open={open} onClose={onClose} aria-labelledby="form-dialog">
      <DialogTitle id="form-dialog-title" className={classes.title}>
        {title}
      </DialogTitle>
      <Divider />
      <DialogContent>{children}</DialogContent>
    </Dialog>
  );
}

export default ModalForm;
