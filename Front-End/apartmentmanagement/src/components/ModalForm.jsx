import { Dialog, DialogContent, DialogTitle } from "@material-ui/core";



function ModalForm(props){
    const {open, onClose, title, children} = props;
    return (
        <Dialog open={open} onClose={onClose} aria-labelledby="form-dialog">
            <DialogTitle id="form-dialog-title">
                {title}
            </DialogTitle>
            <DialogContent>
                {children}
            </DialogContent>
        </Dialog>
    )
}

export default ModalForm;