import React, { Children } from 'react';
import Header from "./LayoutElements/Header"
import Main from "./LayoutElements/Main"
import Footer from "./LayoutElements/Footer"
import './Layout.css'
import Builder from './VisualBuilder'
import VisualBuilder from './VisualBuilder';
import {Switch,Route} from "react-router-dom"
import "./LayoutElements/Main.css"
import Page404 from '../pages/page404'
import SuccessfulRegistration from '../pages/SuccessfulRegistration'
import { Button } from 'react-bootstrap';
import MainPage from '../pages/MainPage';

class Layout extends React.Component{


   //action = "/About"
  static renderContent(action){
     return (VisualBuilder.renderPage(action));

  }
render(props){
   return(
       <div>
            <div className="globalStyleWhite">
               {/* Разбиение блоков */}
               <VisualBuilder Direction="Header"></VisualBuilder>
               <VisualBuilder Direction="GrayLine"></VisualBuilder>
               {/* <VisualBuilder Direction="Content"></VisualBuilder> */}
              
               <Switch>
                  {/* <Route path="" exact render={()=>{<MainPage></MainPage>}}></Route> */}
                  <Route path="/" exact render={()=><MainPage></MainPage>}></Route>
                  <Route path="/first" exact render={()=><MainPage></MainPage>}></Route>
                  <Route path="/second" exact render={()=><h1 className="mainStyle">Second</h1>}></Route>
                  <Route path="/third" exact render={()=><h1 className="mainStyle">Third</h1>}></Route>
                  <Route path="/fourth" exact render={()=><h1 className="mainStyle">Fourth</h1>}></Route>
                  <Route path="/fifth" exact render={()=><SuccessfulRegistration></SuccessfulRegistration>}></Route>
                  <Route render={()=><Page404 className="mainStyle"></Page404>}></Route>
               </Switch>
               
               <VisualBuilder Direction="Footer"></VisualBuilder>
            </div>
 

      </div>
   );
}


}

export default Layout