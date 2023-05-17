import {
  Dialog,
  DialogTitle,
  DialogContent,
  DialogContentText,
  DialogActions,
  Button,
  Slide
} from "@mui/material";
import { TransitionProps } from "@mui/material/transitions";
import React from "react";

const Transition = React.forwardRef(function Transition(
  props: TransitionProps & {
    children: React.ReactElement<any, any>;
  },
  ref: React.Ref<unknown>
) {
  return <Slide direction="up" ref={ref} {...props} />;
});

interface DeleteCancelDialogProps {
  title: string;
  content: string;
  isOpen: boolean;
  onCancel: () => void;
  onSuccess: () => void;
}

const DeleteCancelDialog: React.FC<DeleteCancelDialogProps> = ({
  title,
  content,
  isOpen,
  onCancel,
  onSuccess
}) => {
  return (
    <Dialog
      open={isOpen}
      TransitionComponent={Transition}
      keepMounted
      onClose={onCancel}
    >
      <DialogTitle>{title}</DialogTitle>
      <DialogContent>
        <DialogContentText>{content}</DialogContentText>
      </DialogContent>
      <DialogActions>
        <Button variant="outlined" onClick={onCancel}>
          Cancel
        </Button>
        <Button variant="outlined" color="error" onClick={onSuccess}>
          Delete
        </Button>
      </DialogActions>
    </Dialog>
  );
};

export default DeleteCancelDialog;
