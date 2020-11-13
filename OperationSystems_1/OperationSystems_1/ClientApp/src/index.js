import "bootstrap/dist/css/bootstrap.css";
import React from "react";
import App from "./App";
import ReactDOM from 'react-dom';
import registerServiceWorker from "./registerServiceWorker";

const rootElement = document.getElementById("root");

ReactDOM.render(<App />, rootElement);

registerServiceWorker();
