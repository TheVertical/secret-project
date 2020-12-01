import React, { Children } from 'react';
import Header from "./LayoutElements/Header"
import Main from "./LayoutElements/Main"
import Footer from "./LayoutElements/Footer"
import './Layout.css'
import Builder from './VisualBuilder'
import VisualBuilder from './VisualBuilder';
import ContactBlock from '../AtomicComponents/ContactBlock';


class Layout extends React.Component{

render(props){
   return(
       <div>
            <div className="globalStyleTop">
               <VisualBuilder></VisualBuilder>
            </div>
         <Header></Header>
         <Main></Main>
         <Footer></Footer>
      </div>
   );
}


}

export default Layout