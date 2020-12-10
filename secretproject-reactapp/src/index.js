import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import {BrowserRouter} from "react-router-dom"

 const rootElement = document.getElementById('root');
 const application = (
   <BrowserRouter>
       <App/>
   </BrowserRouter>
 )

ReactDOM.render(

    application,

  rootElement);
 

