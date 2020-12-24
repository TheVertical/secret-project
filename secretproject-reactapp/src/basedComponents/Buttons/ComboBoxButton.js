import React from 'react'
import ButtonGroup from 'react-bootstrap/ButtonGroup'
import Dropdown from 'react-bootstrap/Dropdown'
import DropdownButton from 'react-bootstrap/DropdownButton'
import DropdownMenu from 'react-bootstrap/esm/DropdownMenu';
import { NavLink, withRouter } from 'react-router-dom'

class ComboBoxButton extends React.Component {

  constructor(props) {
    super(props);
    this.state = {
      Id: props.Id,
      Title: props.Title,
      Image: props.Image,
      Action: props.Action,
      DropdownMenu: props.DropdownMenu,

      history: props.history
    }
    // this.onClick_DropdowmItem = this.OnClick_DropdowmItem.bind(this);
    this.onClick_DropdowmItem = null;
  }

 
  static CreateItem(item) {
    let visualItem;
    if (item.Items.length > 0) {
      let dropdownMenu = this.CreateDropdownMenu(item.Items)
      visualItem =<DropdownButton title={item.Title} as={NavLink} to={"/catalog"}>{dropdownMenu}</DropdownButton>
    }
    else {
      visualItem = <Dropdown.Item as={NavLink} to={item.Route}>{item.Title}</Dropdown.Item>
    }
    return (visualItem);
  }
  static CreateDropdownMenu(dropdownItems) {
    return (
      dropdownItems.map(item => {return (ComboBoxButton.CreateItem(item))})
    );
  }
  render() {
    let dropdownMenu = <div></div>;
    if (this.state.DropdownMenu != undefined && this.state.DropdownMenu.Items.length > 0)
      dropdownMenu = ComboBoxButton.CreateDropdownMenu(this.state.DropdownMenu.Items);
    return (
      <div>
        <DropdownButton title={this.state.Title}
        onSelect={this.onClick_DropdowmItem}>
          {dropdownMenu}
        </DropdownButton>
      </div >
    )
  }

}

export default withRouter(ComboBoxButton);