import {
  FormControl,
  InputLabel,
  Select,
  OutlinedInput,
  MenuItem,
  Checkbox,
  ListItemText,
  SelectChangeEvent,
  FormHelperText
} from "@mui/material";
import React from "react";

interface MultiSelectProps {
  label: string;
  values: string[];
  selectedValues: string[];
  onChange: (values: string[]) => void;
}

const ITEM_HEIGHT = 48;
const ITEM_PADDING_TOP = 8;

const MenuProps = {
  PaperProps: {
    style: {
      maxHeight: ITEM_HEIGHT * 4.5 + ITEM_PADDING_TOP,
      width: 250
    }
  }
};

const MultiSelectFormInput: React.FC<MultiSelectProps> = ({
  label,
  values,
  selectedValues,
  onChange
}) => {
  const handleChange = (event: SelectChangeEvent<string[]>) => {
    const value = event.target.value;
    onChange(typeof value === "string" ? value.split(",") : value);
  };

  return (
    <FormControl fullWidth sx={{ mt: 2, p: 0 }}>
      <InputLabel id="demo-multiple-checkbox-label">{label}</InputLabel>
      <Select
        labelId="demo-multiple-checkbox-label"
        multiple
        value={selectedValues}
        onChange={handleChange}
        input={<OutlinedInput label={label} />}
        renderValue={(selected) => selected.join(", ")}
        MenuProps={MenuProps}
      >
        {values.map((value) => (
          <MenuItem key={value} value={value}>
            <Checkbox checked={selectedValues.indexOf(value) > -1} />
            <ListItemText primary={value} />
          </MenuItem>
        ))}
      </Select>
      <FormHelperText></FormHelperText>
    </FormControl>
  );
};

export default MultiSelectFormInput;
