import { FormControl, InputLabel, MenuItem, Select } from "@mui/material";
import React from "react";

interface DynamicSelectProps {
  label: string;
  value: string;
  options: string[];
  onChange: (value: string) => void;
}

const DynamicSelect: React.FC<DynamicSelectProps> = ({
  label,
  value,
  options,
  onChange
}) => {
  return (
    <FormControl fullWidth>
      <InputLabel id="select-label">{label}</InputLabel>
      <Select
        labelId="select-label"
        id="select"
        value={value}
        label={label}
        onChange={(e) => onChange(e.target.value)}
      >
        {options.map((option) => (
          <MenuItem key={option} value={option}>
            {option}
          </MenuItem>
        ))}
      </Select>
    </FormControl>
  );
};

export default DynamicSelect;
