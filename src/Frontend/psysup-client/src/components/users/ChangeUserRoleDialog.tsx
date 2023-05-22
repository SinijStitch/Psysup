import {
  Button,
  Dialog,
  DialogActions,
  DialogContent,
  DialogTitle,
  IconButton,
  List,
  ListItem,
  Stack,
  Typography
} from "@mui/material";
import { ERole } from "enums/ERole";
import React from "react";
import DeleteForeverIcon from "@mui/icons-material/DeleteForever";
import DynamicSelect from "components/common/DynamicSelect";

interface ChangeUserRoleDialogProps {
  isOpen: boolean;
  roles: ERole[];
  onCancel: () => void;
  onSave: (roles: ERole[]) => void;
}

const ChangeUserRoleDialog: React.FC<ChangeUserRoleDialogProps> = ({
  isOpen,
  roles,
  onCancel,
  onSave
}) => {
  const [newRoles, setNewRoles] = React.useState<ERole[]>(roles);
  const [selectedRole, setSelectedRole] = React.useState<ERole | "">("");
  const filteredRoles = React.useMemo(() => {
    return Object.values(ERole).filter((role) => !newRoles.includes(role));
  }, [newRoles]);

  const handleDialogCancel = () => {
    setNewRoles(roles);
    onCancel();
  };

  const handleDialogSave = () => {
    onSave(newRoles);
  };

  const handleRoleChange = (newValue: string) => {
    setSelectedRole(newValue as ERole);
  };

  const handleAddRole = () => {
    setNewRoles([...newRoles, selectedRole as ERole]);
    setSelectedRole("");
  };

  const handleDeleteRole = (role: string) => {
    setNewRoles(newRoles.filter((item) => item !== role));
  };

  return (
    <Dialog
      onClose={handleDialogCancel}
      open={isOpen}
      PaperProps={{ sx: { width: "500px", mx: "auto" } }}
    >
      <DialogTitle>Change User Role</DialogTitle>
      <DialogContent dividers>
        <Stack useFlexGap spacing={1}>
          <DynamicSelect
            label="Select Role"
            value={selectedRole}
            options={filteredRoles}
            onChange={handleRoleChange}
          />
          <Button
            fullWidth
            variant="contained"
            disabled={!selectedRole}
            onClick={handleAddRole}
          >
            Add Role
          </Button>
          <List>
            {newRoles.map((role) => (
              <ListItem key={role}>
                <Stack
                  width="100%"
                  direction="row"
                  justifyContent="space-between"
                  alignItems="center"
                >
                  <Typography>{role}</Typography>
                  <IconButton
                    disabled={newRoles.length === 1}
                    onClick={() => handleDeleteRole(role)}
                  >
                    <DeleteForeverIcon />
                  </IconButton>
                </Stack>
              </ListItem>
            ))}
          </List>
        </Stack>
      </DialogContent>
      <DialogActions>
        <Button autoFocus onClick={handleDialogSave}>
          Save changes
        </Button>
      </DialogActions>
    </Dialog>
  );
};

export default ChangeUserRoleDialog;
