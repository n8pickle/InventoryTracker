import React, { useState } from "react";
import { Typography, TextField, withStyles, MenuItem } from "@material-ui/core";

const EditableTypographyComponent = ({
  value,
  options,
  type,
  onBlur,
  onChange,
  variant,
  select,
  className,
  classes
}) => {
  const [edit, setEdit] = useState(false);

  return (
    (edit &&
      ((!select && (
        <TextField
          autoFocus
          type={type}
          defaultValue={value}
          onBlur={e => {
            onBlur && onBlur(e);
            setEdit(false);
          }}
          className={`${className} ${classes.text}`}
          InputProps={{ classes: { input: classes.text } }}
        />
      )) || (
        <TextField
          autoFocus
          select={select}
          value={value}
          onBlur={() => setEdit(false)}
          onChange={e => {
            onChange && onChange(e);
            setEdit(false);
          }}
          className={`${className} ${classes.text}`}
          InputProps={{ classes: { input: classes.text } }}
        >
          {(select &&
            options &&
            options.map((option, index) => (
              <MenuItem key={index} value={option}>
                {option}
              </MenuItem>
            ))) || <p />}
        </TextField>
      ))) || (
      <Typography
        className={`${className}`}
        variant={variant}
        onClick={() => setEdit(true)}
      >
        {value}
      </Typography>
    )
  );
};

const styles = {
  text: {
    fontSize: "14px"
  }
};

export const EditableTypography = withStyles(styles)(
  EditableTypographyComponent
);
