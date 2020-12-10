//Библиотечные зависимости
import React, { Component } from 'react';
// import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
// import { Link } from 'react-router-dom';
 import "./LinkBlock.css"
//Собственные зависимости
import "./ContactBlock.css"
import {NavLink} from "react-router-dom"

//Расширяет или не расширяет React.Component?
class LinksMenu extends React.Component {
    constructor(props) {
        super();
        this.state = {
            Id: props.Id,
            Links: props.Links,
            MainTitle: props.MainTitle,
            IsHorizontal: props.IsHorizontal
        }
    }
    //Функции React

    //Собственные функции класса

    render() {
       //Проверяет ориентацию - выбирает нужный стиль для верстки
        const checkHor = () => {
            return (
                this.state.IsHorizontal ? "blockStyle" : "forColumnCase"
            )
        }

        return (
        <div className={checkHor()}>
            {/* <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" light>
          <Container>
            <NavbarBrand tag={Link} to="/">WebApplication1</NavbarBrand>
            <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
            <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
              <ul className="navbar-nav flex-grow">
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/">Home</NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/counter">Counter</NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/fetch-data">Fetch data</NavLink>
                </NavItem>
              </ul>
            </Collapse>
          </Container>
        </Navbar> */}
            {this.state.MainTitle}
            {this.state.Links.map((link)=>
             <NavLink className="stylishAAA" key={link.Id} to={link.Link}>{link.Title}</NavLink>
            )
            }
        </div>
        
        );
    }

}

export default LinksMenu;