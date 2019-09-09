import React from "react";
import { withStyles, makeStyles } from "@material-ui/core/styles";
import Table from "@material-ui/core/Table";
import TableBody from "@material-ui/core/TableBody";
import TableCell from "@material-ui/core/TableCell";
import TableHead from "@material-ui/core/TableHead";
import TableRow from "@material-ui/core/TableRow";
import Paper from "@material-ui/core/Paper";
import Fab from "@material-ui/core/Fab";
import AddIcon from "@material-ui/icons/Add";
import EditIcon from "@material-ui/icons/Edit";
import SubtractIcon from "@material-ui/icons/Remove";

const StyledTableCell = withStyles(theme => ({
  head: {
    fontSize: 20,
    backgroundColor: theme.palette.common.black,
    color: theme.palette.common.white
  },
  body: {
    fontSize: 14
  }
}))(TableCell);

const StyledTableRow = withStyles(theme => ({
  root: {
    "&:nth-of-type(odd)": {
      backgroundColor: theme.palette.background.default
    }
  }
}))(TableRow);

function createData(productName, color, trimColor, sku, size, quantity) {
  return { productName, color, trimColor, sku, size, quantity };
}

const useStyles = makeStyles(theme => ({
  root: {
    width: "90%",
    marginTop: theme.spacing(15),
    overflowX: "auto",
    margin: "auto"
  },
  table: {
    minWidth: 700
  }
}));

export const InventoryTable = ({ tables, error }) => {
  const classes = useStyles();

  return (
    <Paper className={classes.root}>
      {!error && tables === "loading" && <div>loading</div>}
      {!error && tables !== "loading" && (
        <Table className={classes.table}>
          <TableHead>
            <TableRow>
              <StyledTableCell align="center">Edit</StyledTableCell>
              <StyledTableCell align="right">Product Name</StyledTableCell>
              <StyledTableCell align="right">Color</StyledTableCell>
              <StyledTableCell align="right">Trim Color</StyledTableCell>
              <StyledTableCell align="right">SKU</StyledTableCell>
              <StyledTableCell align="right">Size</StyledTableCell>
              <StyledTableCell align="right">Quantity</StyledTableCell>
              <StyledTableCell align="center">Inc</StyledTableCell>
              <StyledTableCell align="center">Dec</StyledTableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {tables.map(row => (
              <StyledTableRow key={tables.name}>
                <StyledTableCell component="th" scope="row">
                  <Fab color="primary" aria-label="add" className={classes.fab}>
                    <EditIcon />
                  </Fab>
                </StyledTableCell>
                <StyledTableCell>{row.productName}</StyledTableCell>
                <StyledTableCell align="right">{row.color}</StyledTableCell>
                <StyledTableCell align="right">{row.trimColor}</StyledTableCell>
                <StyledTableCell align="right">{row.sku}</StyledTableCell>
                <StyledTableCell align="right">{row.size}</StyledTableCell>
                <StyledTableCell align="right">{row.quantity}</StyledTableCell>
                <StyledTableCell align="right">
                  <Fab color="primary" aria-label="add" className={classes.fab}>
                    <AddIcon />
                  </Fab>
                </StyledTableCell>
                <StyledTableCell align="right">
                  <Fab
                    color="primary"
                    aria-label="delete"
                    className={classes.fab}
                  >
                    <SubtractIcon />
                  </Fab>
                </StyledTableCell>
              </StyledTableRow>
            ))}
          </TableBody>
        </Table>
      )}
      {error && <p>There was an error loading the data. Please try again.</p>}
    </Paper>
  );
};
