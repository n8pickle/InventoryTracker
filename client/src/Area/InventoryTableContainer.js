import axios from "axios";
import React, { useEffect, useState } from "react";
import { InventoryTable } from "./InventoryTable";

export const InventoryTablesContainer = () => {
  const [tables, setTables] = useState("loading");
  const [error, setError] = useState(undefined);
  useEffect(() => {
    axios
      .get("http://localhost:5000/api/products")
      .then(function(response) {
        setTables(response.data);
        console.log(response);
      })
      .catch(function(error) {
        setError(true);
        console.log(error);
      });
  }, []);

  return (
    <InventoryTable
      tables={tables}
      setTables={setTables}
      setError={setError}
      error={error}
    />
  );
};
