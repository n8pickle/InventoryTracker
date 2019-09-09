import React from "react";
import "./App.css";
import { withStyles } from "@material-ui/styles";
import { Paper } from "@material-ui/core";
import { SearchBar } from "./SeachBar";
import { PersistentDrawerLeft } from "./NavDrawer";
import { InventoryTablesContainer } from "./InventoryTableContainer";

const AppComp = ({ classes }) => {
  return (
    <React.Fragment>
      <PersistentDrawerLeft />
      <Paper className={classes.paperSearch}>
        <div className="App">
          <SearchBar />
        </div>
      </Paper>
      <InventoryTablesContainer />
    </React.Fragment>
  );
};

const styles = theme => ({
  paperSearch: {
    margin: "auto",
    width: "90%"
  }
});

export const App = withStyles(styles)(AppComp);
