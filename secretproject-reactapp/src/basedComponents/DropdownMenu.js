import React from 'react'
import ButtonGroup from 'react-bootstrap/ButtonGroup'
import Dropdown from 'react-bootstrap/Dropdown'
import DropdownButton from 'react-bootstrap/DropdownButton'
import Button from 'react-bootstrap/Button'
import NavLink from "react-router-dom"

class DropdownMenu extends React.Component{
    
    constructor(props) {
        super(props);
        this.state = {
            Id: props.Id,
            Items: props.Items,
            Dropdown: props.Dropdown
        }
    }
   //Используется для вставки дочернего элемента внутрь выпадающего меню
    static InsertDropdown(element){
    return(
    element.map((value,index)=>
    <Dropdown.Item eventKey={index}>{value.Title}</Dropdown.Item>)
    )
        
    }
  //Метод проверяет наличие выпадающего меню и его дочерних элементов, вовзращает верстку
    static CheckDropdownItem(element){ 
        if (element){
            return(
           element.Items.map((value)=>
           <DropdownButton as={ButtonGroup} title={value.Title} id="bg-vertical-dropdown-1" drop='right' className="styleForInsideButtons">
         { (value.Items)?
           DropdownMenu.InsertDropdown(value.Items):
          <Button>{value}</Button>
         }
           </DropdownButton>
           )
            )
        }
    
    }
    
    render() {
      
    return (
       
        <DropdownButton id="dropdown-item-button" title={this.state.Items.Title} className='styleForMargin'>
             <ButtonGroup vertical>
              {DropdownMenu.CheckDropdownItem(this.state.Dropdown)}
             </ButtonGroup>
        </DropdownButton>
        ) 
}
      
}
export default DropdownMenu