import React from "react";

export const MyCoolComponent = ({ title, description, list }) => (
  <div>
    <h1>{title}</h1>
    <p>{description}</p>
    {list.map(x => (
      <div>{x}</div>
    ))}
  </div>
);
