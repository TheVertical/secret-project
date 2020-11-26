import React, { Children } from 'react';
// import {
//    Button,
//    CheckBox,
//    LinkBlock,
//    Picture,
//    Radio
// } from "../components/"
import Button from "../basedComponents/Button"
import CheckBox from "../basedComponents/CheckBox"
import LinkBlock from "../basedComponents/LinkBlock"
import Picture from "../basedComponents/Picture"
import Radio  from "../basedComponents/Radio"

class Layout extends React.Component{

render(props){
   return(
      <div>
         <Button/>
         <CheckBox/>
         <LinkBlock/>
         <Picture/>
         <Radio></Radio>
      </div>
   )
}


}

export default Layout;