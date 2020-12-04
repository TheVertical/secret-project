import React, { Children } from 'react';
import Header from "./LayoutElements/Header"
import Main from "./LayoutElements/Main"
import Footer from "./LayoutElements/Footer"
import './Layout.css'
import Builder from './VisualBuilder'
import VisualBuilder from './VisualBuilder';


class Layout extends React.Component{


   //action = "/About"
  static renderContent(action){
     return (VisualBuilder.renderPage(action));

  }
render(props){
   return(
       <div>
            <div className="globalStyleWhite">
               {/* <Header Content = {VisualBuilder.Render(props.Header)}> </Header>
               <Cotent id ="content" Content = {VisualBuilder.Render(props.Header)}></Cotent>
               <Footer Content = {VisualBuilder.Render(props.Header)}> </Footer> */}
               <VisualBuilder></VisualBuilder>

            </div>
         {/* <Header></Header>
         <Main></Main>
         <Footer></Footer> */}

      </div>
   );
}


}

export default Layout