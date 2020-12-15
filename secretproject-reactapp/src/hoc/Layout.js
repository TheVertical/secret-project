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
import OrderPage from '../pages/OrderPage';
import Catalog_Page from '../pages/Catalog_Page'
import Cart from '../pages/Cart'
import OrderRegistration from '../pages/OrderRegistration'



class Layout extends React.Component{
   
   render(){
     
      return (
         <div>
            <div className="globalStyleWhite">
               {/* Разбиение блоков */}
               <VisualBuilder Direction="Header"></VisualBuilder>
               <VisualBuilder Direction="GrayLine"></VisualBuilder>
               {/* <VisualBuilder Direction="Content"></VisualBuilder> */}
              
               <Switch>
                  {/* <Route path="" exact render={()=>{<MainPage></MainPage>}}></Route> */}
                  <Route path="/" exact render={()=><MainPage></MainPage>}></Route>
                  <Route path="/main" exact render={()=><MainPage></MainPage>}></Route>
                  <Route path="/catalog/:id" exact render={()=><OrderPage></OrderPage>}></Route>
                  <Route path="/catalog" exact render={()=><Catalog_Page></Catalog_Page>}></Route>
                  <Route path="/fourth" exact render={()=><h1 className="mainStyle">Fourth</h1>}></Route>
                  <Route path="/succesful_registration" exact render={()=><SuccessfulRegistration></SuccessfulRegistration>}></Route>
                  <Route path="/cart" exact render={()=><Cart></Cart>}></Route>
                  <Route path="/seventh" exact render={()=><OrderRegistration></OrderRegistration>}></Route>
                  <Route render={()=><Page404 className="mainStyle"></Page404>}></Route>
               </Switch>
               
               <VisualBuilder Direction="Footer"></VisualBuilder>
            </div>


         </div>
      );
   }


}

export default Layout