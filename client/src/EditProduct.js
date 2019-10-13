import React from "react";
import clsx from "clsx";
import { withStyles } from "@material-ui/core/styles";
import TextField from "@material-ui/core/TextField";
import { PersistentDrawerLeft } from "./Area/NavDrawer";
import { Card, Button } from "@material-ui/core";
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
  return (
    <React.Fragment>
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
          className={classes.submit}
          onClick={() => {
            // const [error, setError] = useState(undefined);
            axios
              .put("http://localhost:5000/api/products/{SKU}", editProductForm)
              .then(function(response) {
                console.log(response);
              })
              .catch(function(error) {
                // setError(true);
                console.log(error);
              });
          }}
        >
          Submit
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
    marginLeft: "44%",
    marginTop: theme.spacing(4)
  }
});

export const EditProduct = withStyles(styles)(EditProductPageComp);
