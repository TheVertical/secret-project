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
//Вспомогательные функции
import { MakeServerQuery } from  '../Services/ServerQuery'

//const Query = new ServerQuery();


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
      //let url = 'https://secrethost.azurewebsites.net/visual/backbone';
      //let response = await fetch(url);
      //if (!response.ok) { alert(response.status) }
      //else {
      //   let json = await response.json();
      //   this.setState({ Downloaded: json, IsLoading: false });
     //}
     let responce = await MakeServerQuery('GET', "/visual/backbone");
     if (responce && responce.success) {
       this.setState({ Downloaded: responce.data, IsLoading: false });
     }
   }

   render() {

      if (this.state.IsLoading) {
       return (<div className="Layout_FullContentStyle"><LoadingPage loading={this.state.IsLoading}></LoadingPage></div>)
      }
      let header =  VisualFactory.renderVisualElement(this.state.Downloaded["Header"]);
      let grayline =  VisualFactory.renderVisualElement(this.state.Downloaded["GrayLine"]);
      let footer = VisualFactory.renderVisualElement(this.state.Downloaded["Footer"]);
      return (
         <div>
            <div className="globalStyleWhite">
               {/* Разбиение блоков */}
               {/*Header*/}
               <div className="globalStyleTop">
                  {header}
               </div>
               {/*GrayLine*/}
               <div className="globalStyleBottom">
                  {grayline}
               </div>
               <Switch>
                  <Route exact path="/" render={() => <MainPage></MainPage>}></Route>
                  <Route path="/pages/contacts" exact render={() => <MainPage></MainPage>}></Route>
                  <Route path="/catalog/product/:id" render={() => <ProductPage></ProductPage>}></Route>
                  <Route exact path="/catalog" render={(props) => <Catalog_Page {...props}></Catalog_Page>}></Route>
                  <Route exact path="/catalog/brend/:id" render={(props) => <Catalog_Page {...props}></Catalog_Page>}></Route>
                  <Route path="/catalog/category/:id" exact render={() => <Catalog_Page></Catalog_Page>}></Route>
                  <Route path="/pages/news" exact render={() => <SuccessfulRegistration></SuccessfulRegistration>}></Route>
                  <Route path="/cart" exact render={() => <Cart></Cart>}></Route>
                  <Route path="/" exact render={() => <Catalog_Page></Catalog_Page>}></Route>
                  <Route path="/order" exact render={() => <OrderRegistration></OrderRegistration>}></Route>
                  <Route render={() => <Page404 className="mainStyle"></Page404>}></Route>
               </Switch>
               {/*Footer*/}
               <div className="globalStyleFooter">
                  {footer}
               </div>

            </div>


         </div>
      );
   }


}

export default Layout
