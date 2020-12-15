import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import { BrowserRouter } from "react-router-dom"
import { Provider } from 'react-redux'
import {createStore} from "redux"
import rootReducer from "./redux/rootReducer"
import rootStore from "./redux/rootStore"

const rootElement = document.getElementById('root');

 
const application = (
  <Provider store={rootStore()}>
    <BrowserRouter>
      <App />
    </BrowserRouter>
  </Provider>
)

ReactDOM.render(

  application,

  rootElement);


