import React from "react";
import { withStyles } from "@material-ui/styles";
import Button from "@material-ui/core/Button";
import SearchIcon from "@material-ui/icons/Search";

const SearchBarComp = ({ classes }) => (
  <div className={classes.searchComp}>
    <h3 className={classes.searchHead}>Search:</h3>
    <input className={classes.searchText}></input>
    <Button variant="contained" color="primary" className={classes.searchBtn}>
      <SearchIcon></SearchIcon>
    </Button>
  </div>
);

const styles = theme => ({
  searchHead: {
    textAlign: "left",
    padding: ".5%",
    marginLeft: "17%",
    marginBottom: "0px",
    marginTop: "2%"
  },
  searchBtn: {
    padding: theme.spacing(2) // = 8 * 2
  },
  searchText: {
    width: "60%",
    padding: theme.spacing(2),
    margin: "10px",
    font: "Roboto",
    fontSize: "1.1em",
    borderRadius: "0.5em"
  },
  searchComp: {
    marginTop: "12%"
  }
});

export const SearchBar = withStyles(styles)(SearchBarComp);
