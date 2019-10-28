import React from "react";
import ReactDOM from "react-dom";
import "./index.css";
import { EditProduct } from "./EditProduct";
import { NewProduct } from "./NewProduct";
import { App } from "./App";
import * as serviceWorker from "./serviceWorker";
import { createMuiTheme } from "@material-ui/core/styles";
import { MuiThemeProvider } from "@material-ui/core";
import { Background } from "./Background";
import { Router, Switch, Route } from "react-router";
import { createBrowserHistory } from "history";

const darkTheme = createMuiTheme({
  palette: {
    type: "dark"
  }
});

const routes = [
  { path: "/", name: "HomePage", component: App, id: 1 },
  {
    path: "/new-product",
    name: "NewProductPage",
    component: NewProduct,
    id: 2
  },
  {
    path: "/edit-product",
    name: "EditProductPage",
    component: EditProduct,
    id: 3
  }
];

var history = createBrowserHistory();

ReactDOM.render(
  <MuiThemeProvider theme={darkTheme}>
    <Background>
      <Router history={history}>
        <Switch>
          {routes.map(r => (
            <Route exact path={r.path} component={r.component} key={r.id} />
          ))}
        </Switch>
      </Router>
    </Background>
  </MuiThemeProvider>,
  document.getElementById("root")
);

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
