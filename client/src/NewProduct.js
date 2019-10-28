import React from "react";
import clsx from "clsx";
import { withStyles } from "@material-ui/core/styles";
import TextField from "@material-ui/core/TextField";
import { PersistentDrawerLeft } from "./Area/NavDrawer";
import { Card, Button } from "@material-ui/core";
import { Redirect } from "react-router";
import axios from "axios";

const NewProductPageComp = ({ classes }) => {
  const [newProductForm, setNewProductForm] = React.useState({
    ProductName: "product",
    Color: "white",
    TrimColor: "yellow",
    Size: "small",
    SKU: 0,
    Quantity: 0,
    NotificationQuantity: 0,
    Price: 0,
    Dimensions: "2x1",
    Deleted: 0,
    ProductID: 0
  });
  const [formSubmitted, SetFormSubmitted] = React.useState(false);
  const [formCanceled, setFormCanceled] = React.useState(false);

  const inputProps = {
    maxLength: 12
  };

  const onSubmitHandler = async () => {
    await axios
      .post("http://localhost:5000/api/products/", newProductForm)
      .then(function(response) {
        console.log(response);
      })
      .catch(function(error) {
        // setError(true);
        console.log(error);
      });
    SetFormSubmitted(true);
  };

  if (formSubmitted) return <Redirect to="/"></Redirect>;
  if (formCanceled) return <Redirect to="/"></Redirect>;

  return (
    <React.Fragment>
      <PersistentDrawerLeft />
      <Card className={classes.center}>
        <TextField
          id="outlined-dense"
          label="Product Name"
          fullWidth
          value={newProductForm.ProductName}
          onChange={e =>
            setNewProductForm({
              ...newProductForm,
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
          value={newProductForm.Color}
          onChange={e =>
            setNewProductForm({
              ...newProductForm,
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
          value={newProductForm.TrimColor}
          onChange={e =>
            setNewProductForm({
              ...newProductForm,
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
          fullWidth
          inputProps={inputProps}
          value={newProductForm.SKU}
          onChange={e =>
            setNewProductForm({
              ...newProductForm,
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
          value={newProductForm.Size}
          onChange={e =>
            setNewProductForm({
              ...newProductForm,
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
          value={newProductForm.Quantity}
          onChange={e =>
            setNewProductForm({
              ...newProductForm,
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
          value={newProductForm.NotificationQuantity}
          onChange={e =>
            setNewProductForm({
              ...newProductForm,
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
          className={classes.submit}
          onClick={e => onSubmitHandler()}
        >
          Submit
        </Button>
        <Button
          variant="contained"
          color="primary"
          className={classes.submit}
          onClick={e => setFormCanceled(true)}
        >
          Cancel
        </Button>
      </Card>
    </React.Fragment>
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
  submit: {
    marginLeft: "25%",
    marginTop: theme.spacing(4)
  }
});

export const NewProduct = withStyles(styles)(NewProductPageComp);
