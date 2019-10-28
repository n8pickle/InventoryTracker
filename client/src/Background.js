import React from "react";
import { withStyles } from "@material-ui/core/styles";

const BackgroundComp = ({ classes, children }) => (
  <div className={classes.backgrnd}>{children}</div>
);

const styles = theme => ({
  backgrnd: {
    width: "100%",
    height: "100vh",
    backgroundColor: "#2f2f2f",
    position: "relative"
  }
});

export const Background = withStyles(styles)(BackgroundComp);
