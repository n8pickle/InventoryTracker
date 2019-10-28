import React from "react";
import { withStyles } from "@material-ui/core/styles";
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
import axios from "axios";
import { Redirect } from "react-router";
import { EditableTypography } from "../.vscode/EditableTypography";

const InventoryTableComp = ({
  tables,
  error,
  classes,
  setTables,
  setError
}) => {
  const [navToEditProduct, setNavToEditProduct] = React.useState(undefined);
  const [incrementProduct, setIncrementProduct] = React.useState(undefined);

  const onSubmit = async (sku, amount) => {
    await axios
      .post("http://localhost:5000/api/inventory/" + sku + "/set/" + amount)
      .then(function(response) {
        console.log(response);
      })
      .catch(function(error) {
        console.log(error);
      });
    await axios
      .get("http://localhost:5000/api/products")
      .then(function(response) {
        setTables(response.data);
        console.log(response);
      })
      .catch(function(error) {
        setError(true);
        console.log(error);
      });
  };

  const onDecrement = async sku => {
    console.log(sku);
    await axios
      .post("http://localhost:5000/api/inventory/" + sku + "/sbt/" + 1)
      .then(function(response) {
        console.log(response);
      })
      .catch(function(error) {
        console.log(error);
      });
    await axios
      .get("http://localhost:5000/api/products")
      .then(function(response) {
        setTables(response.data);
        console.log(response);
      })
      .catch(function(error) {
        setError(true);
        console.log(error);
      });
  };

  const onIncrement = async sku => {
    await axios
      .post("http://localhost:5000/api/inventory/" + sku + "/add/" + 1)
      .then(function(response) {
        console.log(response);
      })
      .catch(function(error) {
        console.log(error);
      });
    await axios
      .get("http://localhost:5000/api/products")
      .then(function(response) {
        setTables(response.data);
        console.log(response);
      })
      .catch(function(error) {
        setError(true);
        console.log(error);
      });
  };

  if (navToEditProduct) {
    return (
      <Redirect
        to={{ pathname: "/edit-product", state: { navToEditProduct } }}
      />
    );
  }

  return (
    <Paper className={classes.root}>
      {!error && tables === "loading" && <div>loading</div>}
      {!error && tables !== "loading" && (
        <Table className={classes.table}>
          <TableHead>
            <TableRow className={classes.head}>
              <TableCell align="center">Edit</TableCell>
              <TableCell align="left">Product Name</TableCell>
              <TableCell align="right">Color</TableCell>
              <TableCell align="right">Trim Color</TableCell>
              <TableCell align="right">SKU</TableCell>
              <TableCell align="right">Size</TableCell>
              <TableCell align="right">Quantity</TableCell>
              <TableCell align="center">Inc</TableCell>
              <TableCell align="center">Dec</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {tables.map(row => (
              <TableRow
                className={
                  row.quantity > row.notificationQuantity
                    ? classes.tRow
                    : classes.bg
                }
                key={row.sku}
              >
                <TableCell component="th" scope="row">
                  <Fab
                    color="primary"
                    aria-label="add"
                    className={classes.fab}
                    onClick={e => setNavToEditProduct(row)}
                  >
                    <EditIcon />
                  </Fab>
                </TableCell>
                <TableCell>{row.productName}</TableCell>
                <TableCell align="right">{row.color}</TableCell>
                <TableCell align="right">{row.trimColor}</TableCell>
                <TableCell align="right">{row.sku}</TableCell>
                <TableCell align="right">{row.size}</TableCell>
                <TableCell align="right" width="10%" marginRight="0%">
                  <EditableTypography
                    value={row.quantity}
                    onBlur={e => onSubmit(row.sku, e.target.value)}
                  ></EditableTypography>
                </TableCell>
                <TableCell align="center">
                  <Fab
                    color="primary"
                    aria-label="add"
                    className={classes.fab}
                    onClick={() => onIncrement(row.sku)}
                  >
                    <AddIcon />
                  </Fab>
                </TableCell>
                <TableCell align="center">
                  <Fab
                    color="primary"
                    aria-label="delete"
                    className={classes.fab}
                    onClick={e => onDecrement(row.sku)}
                  >
                    <SubtractIcon />
                  </Fab>
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      )}
      {error && <p>There was an error loading the data. Please try again.</p>}
    </Paper>
  );
};

const styles = theme => ({
  head: {
    backgroundColor: theme.palette.common.black,
    color: theme.palette.common.white,
    fontType: "Roboto",
    fontSize: "10em"
  },
  body: {
    // fontSize: 14
  },
  root: {
    width: "90%",
    marginTop: theme.spacing(15),
    overflowX: "auto",
    margin: "auto",
    fontType: "Roboto",
    fontSize: "4em"
  },
  table: {
    minWidth: 700
  },
  tRow: {
    "&:nth-of-type(odd)": {
      backgroundColor: "#2f2f2f"
    }
  },
  bg: {
    backgroundColor: "#ff0000"
  },
  quantityBase: {
    textAlign: "right",
    width: "50%",
    margin: "auto"
  }
});

export const InventoryTable = withStyles(styles)(InventoryTableComp);
