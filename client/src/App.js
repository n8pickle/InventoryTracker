import React from "react";
import "./App.css";
import { MyCoolComponent } from "./MyCoolComponent";

const App = () => {
  return (
    <div className="App">
      <div className="header">React TODO application</div>
      <div className="btn">+ </div>

      <MyCoolComponent
        title="Cool Stuff"
        description="Suff the coo' kids do:"
        list={[
          "program",
          "swim",
          "play games",
          "be awesome",
          "go to conie island"
        ]}
      />
      <MyCoolComponent
        title="Lame Stuff"
        description="Suff the lame kids do:"
        list={[
          "shovel poop",
          "flip burgers at mac daddys",
          "pick thier nose",
          "be lame"
        ]}
      />

      <input></input>
    </div>
  );
};

export default App;
