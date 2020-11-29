import React, { Children } from 'react';
import Header from "./LayoutElements/Header"
import Main from "./LayoutElements/Main"
import Footer from "./LayoutElements/Footer"
import './Layout.css'



class Layout extends React.Component{

render(props){
   return(
   
   <div>
         <Header></Header>
         <Main></Main>
         <Footer></Footer>
      </div>
   );
}


}

export default Layout