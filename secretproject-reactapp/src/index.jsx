import React from 'react';
import ReactDOM from 'react-dom';
import App from './App.tsx';
import { BrowserRouter } from "react-router-dom"
import { Provider } from 'react-redux'

const rootElement = document.getElementById('root');

 
const application = (
      <App />
)

ReactDOM.render(

  application,

  rootElement);


