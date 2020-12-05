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
               {/* Разбиение блоков */}
               <VisualBuilder Direction="Header"></VisualBuilder>
               <VisualBuilder Direction="GrayLine"></VisualBuilder>
               <VisualBuilder Direction="Content"></VisualBuilder>
               <VisualBuilder Direction="Footer"></VisualBuilder>
            </div>
 

      </div>
   );
}


}

export default Layout