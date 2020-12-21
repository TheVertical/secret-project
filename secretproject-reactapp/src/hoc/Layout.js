import React from 'react';
import './Layout.css'
import './LayoutElements/Header.css';
import { Switch, Route } from "react-router-dom"
import "./LayoutElements/Main.css"
import Page404 from '../pages/page404'
import SuccessfulRegistration from '../pages/SuccessfulRegistration'
import MainPage from '../pages/MainPage';
import ProductPage from '../pages/ProductPage';
import Catalog_Page from '../pages/Catalog_Page'
import VisualFactory from '../basedComponents/VisualFactory';
import Cart from '../pages/Cart';
import OrderRegistration from '../pages/OrderRegistration';
import LoadingPage from '../pages/LoadingPage';


class Layout extends React.Component {
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
      if (!response.ok) { alert(response) }
      let json = await response.json();
      this.setState({ Downloaded: json,IsLoading:false});
   }
   
   render() {

      if(this.state.IsLoading){ return (<div className="Layout_FullContentStyle"><LoadingPage loading={this.state.IsLoading}></LoadingPage></div>)}
      let header =  VisualFactory.renderVisualElement(this.state.Downloaded["Header"]);
      let grayline =  VisualFactory.renderVisualElement(this.state.Downloaded["GrayLine"]);
      let footer =  VisualFactory.renderVisualElement(this.state.Downloaded["Footer"]);
      return (
         <div>
            <div className="globalStyleWhite">
               {/* Разбиение блоков */}
               {/*Header*/}
               <div className="globalStyleTop">{header}</div>
               {/*GrayLine*/}
               <div className="globalStyleBottom">{grayline}</div>
               <Switch>
                  <Route path="/home" render={() => <MainPage></MainPage>}></Route>
                  <Route path="/pages/contacts" exact render={() => <MainPage></MainPage>}></Route>
                  <Route path="/catalog/product/:id" render={() => <ProductPage></ProductPage>}></Route>
                  <Route path="/catalog/:params" exact render={() => <Catalog_Page></Catalog_Page>}></Route>
                  <Route path="/pages/home" exact render={() => <h1 className="mainStyle">Fourth</h1>}></Route>
                  <Route path="/pages/news" exact render={() => <SuccessfulRegistration></SuccessfulRegistration>}></Route>
                  <Route path="/Basket" exact render={() => <Cart></Cart>}></Route>
                  <Route path="/Catalog" exact render={() => <Catalog_Page></Catalog_Page>}></Route>
                  <Route path="/order" exact render={() => <OrderRegistration></OrderRegistration>}></Route>
                  <Route render={() => <Page404 className="mainStyle"></Page404>}></Route>
               </Switch>
               {/*Footer*/}
               <div className="globalStyleFooter">{footer}</div>

            </div>


         </div>
      );
   }


}

export default Layout
