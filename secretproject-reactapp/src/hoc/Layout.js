import React from 'react';
import Header from "./LayoutElements/Header"
import Footer from "./LayoutElements/Footer"
import './Layout.css'
import {Switch,Route} from "react-router-dom"
import "./LayoutElements/Main.css"
import Page404 from '../pages/page404'
import SuccessfulRegistration from '../pages/SuccessfulRegistration'
import MainPage from '../pages/MainPage';
import OrderPage from '../pages/OrderPage';
import Catalog_Page from '../pages/Catalog_Page'
import GrayLine from '../hoc/LayoutElements/GrayLine';
import VisualFactory from '../basedComponents/VisualElement';



class Layout extends React.Component{
   constructor(props) {
      super(props);
      this.state = {
        Direction: props.Direction,
        IsLoading: true,
        Downloaded: {},
     }
   }
  
    componentDidMount() {
      this.getBackbone();
    }
  
    async getBackbone() {
      let url = 'https://secrethost.azurewebsites.net/visual/backbone'
      let response = await fetch(url); 
      let json = await response.json();
      console.log(json);
      this.setState({Downloaded:json,IsLoading:false});
    }
   async geaPage(){
   }

   render(){
     let header = this.state.IsLoading ? <p><em>Loading...</em></p> : VisualFactory.renderVisualElement(this.state.Downloaded["Header"]);
     console.log(header);
     let grayline = this.state.IsLoading ? <p><em>Loading...</em></p> : VisualFactory.renderVisualElement(this.state.Downloaded["GrayLine"]);
     console.log(grayline);
     let footer = this.state.IsLoading ? <p><em>Loading...</em></p> : VisualFactory.renderVisualElement(this.state.Downloaded["Footer"]);
      return (
         <div>
            <div className="globalStyleWhite">
               {/* Разбиение блоков */}
               {/*Header*/}
              <div className ="globalStyleTop">{header}</div>
               {/*GrayLine*/}
              <div className ="globalStyleBottom">{grayline}</div>
               <Switch>
                  <Route path="/home" exact render={()=><MainPage></MainPage>}></Route>
                  <Route path="/pages/contacts" exact render={()=><MainPage></MainPage>}></Route>
                  <Route path="/pages/pickuppoint" exact render={()=><OrderPage></OrderPage>}></Route>
                  <Route path="/pages/return" exact render={()=><Catalog_Page></Catalog_Page>}></Route>
                  <Route path="/pages/home" exact render={()=><h1 className="mainStyle">Fourth</h1>}></Route>
                  <Route path="/pages/news" exact render={()=><SuccessfulRegistration></SuccessfulRegistration>}></Route>
                  <Route render={()=><Page404 className="mainStyle"></Page404>}></Route>
               </Switch>
               {/*Footer*/}
              <div className="globalStyleFooter">{footer}</div>

            </div>


         </div>
      );
   }


}

export default Layout