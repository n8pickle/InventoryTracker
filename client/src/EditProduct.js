import React from "react";
import clsx from "clsx";
import { withStyles } from "@material-ui/core/styles";
import TextField from "@material-ui/core/TextField";
import { PersistentDrawerLeft } from "./Area/NavDrawer";
import { ConfirmationBox } from "./Area/ConfirmationBox";
import { Card, Button } from "@material-ui/core";
import DeleteIcon from "@material-ui/icons/Delete";
import { Redirect } from "react-router";
import axios from "axios";

const EditProductPageComp = ({ classes, location }) => {
  const [editProductForm, setEditProductForm] = React.useState({
    ProductName: location.state.navToEditProduct.productName,
    Color: location.state.navToEditProduct.color,
    TrimColor: location.state.navToEditProduct.trimColor,
    Size: location.state.navToEditProduct.size,
    SKU: location.state.navToEditProduct.sku,
    Quantity: location.state.navToEditProduct.quantity,
    NotificationQuantity: location.state.navToEditProduct.notificationQuantity,
    Price: 0,
    Dimensions: "2x1",
    Deleted: 0,
    ProductID: 0
  });
  const [itemDeleted, setItemDeleted] = React.useState(false);
  const [itemSubmitted, setItemSubmitted] = React.useState(false);
  const [editCanceled, setEditCanceled] = React.useState(false);
  const [open, setOpen] = React.useState(false);

  const onSubmitHandler = async () => {
    await axios
      .put(
        "http://localhost:5000/api/products/" +
          location.state.navToEditProduct.sku,
        editProductForm
      )
      .then(function(response) {
        console.log(response);
      })
      .catch(function(error) {
        console.log(error);
      });
    setItemSubmitted(true);
  };

  const onDeleteHandler = async () => {
    await axios
      .delete(
        "http://localhost:5000/api/products/" +
          location.state.navToEditProduct.sku
      )
      .then(function(response) {
        console.log(response);
      })
      .catch(function(error) {
        // setError(true);
        console.log(error);
      });
    setItemDeleted(true);
  };

  if (itemDeleted) return <Redirect to="/"></Redirect>;

  if (itemSubmitted) return <Redirect to="/"></Redirect>;

  if (editCanceled) return <Redirect to="/"></Redirect>;

  return (
    <form>
      <PersistentDrawerLeft />
      <Card className={classes.center}>
        <TextField
          id="outlined-dense"
          label="Product Name"
          fullWidth
          value={editProductForm.ProductName}
          onChange={e =>
            setEditProductForm({
              ...editProductForm,
              ProductName: e.target.value
            })
          }
          className={clsx(classes.textField, classes.dense)}
          margin="dense"
          variant="outlined"
        />
        <TextField
          id="outlined-dense"
          label="Color"
          fullWidth
          value={editProductForm.Color}
          onChange={e =>
            setEditProductForm({
              ...editProductForm,
              Color: e.target.value
            })
          }
          className={clsx(classes.textField)}
          margin="dense"
          variant="outlined"
        />
        <TextField
          id="outlined-dense"
          label="Trim Color"
          fullWidth
          value={editProductForm.TrimColor}
          onChange={e =>
            setEditProductForm({
              ...editProductForm,
              TrimColor: e.target.value
            })
          }
          className={clsx(classes.textField)}
          margin="dense"
          variant="outlined"
        />
        <TextField
          id="outlined-dense"
          label="SKU"
          type="number"
          fullWidth
          value={editProductForm.SKU}
          onChange={e =>
            setEditProductForm({
              ...editProductForm,
              SKU: +e.target.value
            })
          }
          className={clsx(classes.textField)}
          margin="dense"
          variant="outlined"
        />
        <TextField
          id="outlined-dense"
          label="Size"
          fullWidth
          value={editProductForm.Size}
          onChange={e =>
            setEditProductForm({
              ...editProductForm,
              Size: e.target.value
            })
          }
          className={clsx(classes.textField)}
          margin="dense"
          variant="outlined"
        />
        <TextField
          id="outlined-dense"
          label="Quantity"
          fullWidth
          type="number"
          value={editProductForm.Quantity}
          onChange={e =>
            setEditProductForm({
              ...editProductForm,
              Quantity: +e.target.value
            })
          }
          className={clsx(classes.textField)}
          margin="dense"
          variant="outlined"
        />
        <TextField
          id="outlined-dense"
          label="Notification Quantity"
          fullWidth
          value={editProductForm.NotificationQuantity}
          onChange={e =>
            setEditProductForm({
              ...editProductForm,
              NotificationQuantity: +e.target.value
            })
          }
          className={clsx(classes.textField)}
          margin="dense"
          variant="outlined"
        />
        <Button
          variant="contained"
          color="primary"
          className={classes.allButtons}
          onClick={e => {
            e.preventDefault();
            onSubmitHandler();
          }}
          type="submit"
        >
          Submit
        </Button>
        <Button
          variant="contained"
          color="primary"
          className={classes.allButtons}
          onClick={e => setEditCanceled(true)}
        >
          Cancel
        </Button>
        <Button
          variant="contained"
          color="secondary"
          className={classes.allButtons}
          onClick={e => setOpen(true)}
        >
          <DeleteIcon />
        </Button>
      </Card>
      <ConfirmationBox
        open={open}
        setOpen={setOpen}
        onDeleteHandler={onDeleteHandler}
      ></ConfirmationBox>
    </form>
  );
};
const styles = theme => ({
  inputBackground: {
    marginTop: "5%",
    marginLeft: "5%"
  },
  textField: {
    marginLeft: theme.spacing(5),
    marginRight: theme.spacing(5),
    paddingRight: theme.spacing(10),
    marginTop: theme.spacing(2),
    display: "block"
  },
  dense: {
    marginTop: theme.spacing(4)
  },
  center: {
    height: "70%",
    width: "40%",
    left: "50%",
    top: "50%",
    position: "absolute",
    transform: "translateX(-50%) translateY(-50%)"
  },
  allButtons: {
    marginLeft: "15%",
    marginTop: theme.spacing(4)
  }
});

export const EditProduct = withStyles(styles)(EditProductPageComp);
