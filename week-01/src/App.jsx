import { useState } from "react";
import "./App.css";
import App2, { inputLabel } from "./App2";

const customerid = 0;

export function App() {
  //const [inputName, setInputName] = useState("test");
  let inputName = "test";

  function setInputName(name) {
    console.log("setInputName triggered");
    inputName = name;
  }
  //if (inputName === "test") setInputName("hehe");

  console.log("Render ui");

  return (
    <div className="App">
      {inputName} <br />
      {inputName === "Load" && <span>Loaded</span>} <br />
      <label>{inputLabel[customerid]}</label> <br />
      <input onChange={(e) => setInputName(e.target.value)}></input> <br />
      <button onClick={() => setInputName("")}>Clear</button>
    </div>
  );
}

export function App3() {
  return (
    <div className="App">
      <input>{inputLabel}</input> <br />
      <button>This is a button 3</button>
    </div>
  );
}
