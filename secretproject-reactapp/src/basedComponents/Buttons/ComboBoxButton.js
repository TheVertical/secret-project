import React from 'react'
import ButtonGroup from 'react-bootstrap/ButtonGroup'
import Dropdown from 'react-bootstrap/Dropdown'
import DropdownButton from 'react-bootstrap/DropdownButton'
import DropdownMenu from 'react-bootstrap/esm/DropdownMenu';
import { Link, NavLink, withRouter } from 'react-router-dom'
import "./ComboBoxButton.css"

class ComboBoxButton extends React.Component {

  constructor(props) {
    super(props);
    this.state = {
      Id: props.Id,
      Title: props.Title,
      Image: props.Image,
      Action: props.Action,
      DropdownMenu: props.DropdownMenu,

      history: props.history,
    }
    this.count = 0;
    // this.onClick_DropdowmItem = this.OnClick_DropdowmItem.bind(this);
    this.onClick_DropdowmItem = null;
  }
  CreateItem(item) {
    let visualItem;
    if (item.Items.length > 0) {
      let dropdownMenu = this.CreateDropdownMenu(item.Items)
      visualItem = <DropdownButton title={item.Title} as={NavLink} to={"/catalog"}>{dropdownMenu}</DropdownButton>
    }
    else {
      visualItem = <Dropdown.Item key={this.count} as={NavLink} to={"/" + item.Route}>{item.Title}</Dropdown.Item>
      this.count++;
    }
    return (visualItem);
  }
  CreateDropdownMenu(dropdownItems) {
    return (
      dropdownItems.map(item => { return (this.CreateItem(item)) })
    );
  }
  render() {
    let dropdownMenu = <div></div>;
    if (this.state.DropdownMenu != undefined && this.state.DropdownMenu.Items.length > 0)
      dropdownMenu = this.CreateDropdownMenu(this.state.DropdownMenu.Items);
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