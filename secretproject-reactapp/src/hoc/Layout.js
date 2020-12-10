import React, { Children } from 'react';
import Header from "./LayoutElements/Header"
import Main from "./LayoutElements/Main"
import Footer from "./LayoutElements/Footer"
import './Layout.css'
import Builder from './VisualBuilder'
import VisualBuilder from './VisualBuilder';
<<<<<<< HEAD
import {Switch,Route} from "react-router-dom"
import "./LayoutElements/Main.css"
import Page404 from '../pages/page404'
import SuccessfulRegistration from '../pages/SuccessfulRegistration'
import { Button } from 'react-bootstrap';
import MainPage from '../pages/MainPage';
=======
import ErrorPage from './ErrorPage';
import { Route } from 'react-router-dom';

class Layout extends React.Component {
   constructor()
   {
      super();
      this.state = {
         IsLoading: true,
         Downloaded: {},
         IsError: false,
         ErrorMessage: '',
      }
   }
   
   componentDidMount() {
      this.downloadPage('visual/backbone');
   }
>>>>>>> 26c09335afe064e226dc7787d4ea1f621f56a548

   async downloadPage(route) {
      let url = 'https://secrethost.azurewebsites.net/' + route;
      const response = await fetch(url);
      let json;
      try {
         json = await response.json();
      }
      catch (exception) {
         console.log(exception);
         this.setState({IsError: true,ErrorMessage:exception});
      }
      if(!(this.state.IsError) && response.status != 404 )
         this.setState({ Downloaded: json, IsLoading: false});
      else
         this.setState({IsError: true,IsLoading: false});
   }

   render() {
      let error = this.state.IsError ? <ErrorPage Message = {this.state.ErrorMessage}></ErrorPage> : '';
      let _header = this.state.IsLoading && !this.state.IsError ? 'Loading' : VisualBuilder.renderVisual(this.state.Downloaded.Header);
      let _grayLine = this.state.IsLoading && !this.state.IsError ? 'Loading' : VisualBuilder.renderVisual(this.state.Downloaded.GrayLine);
      let _content = this.state.IsLoading && !this.state.IsError ? 'Loading' : VisualBuilder.renderVisual(this.state.Downloaded);
      let _footer = this.state.IsLoading && !this.state.IsError ? 'Loading' : VisualBuilder.renderVisual(this.state.Downloaded);
      return (
         <div>
            {error}
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
                  <Header>{_header}</Header>
               {/* <Route></Route> */}
            </div>


         </div>
      );
   }


}

export default Layout