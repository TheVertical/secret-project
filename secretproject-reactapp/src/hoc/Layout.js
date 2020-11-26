import React, { Children } from 'react';
// import {
//    Button,
//    CheckBox,
//    LinkBlock,
//    Picture,
//    Radio
// } from "../components/"
import Button from "../atom_components/Button"
import CheckBox from "../atom_components/CheckBox"
import LinkBlock from "../atom_components/LinkBlock"
import Picture from "../atom_components/Picture"
import Radio  from "../atom_components/Radio"

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