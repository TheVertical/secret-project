//Библиотечные зависимости
import React, { Component } from 'react';
// import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
// import { Link } from 'react-router-dom';
 import "./LinkBlock.css"
//Собственные зависимости
import "./ContactBlock.css"
import {Link, NavLink} from "react-router-dom"

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
    checkHor(){
      return (
        //TODO Здесь не правильно сделано, надо наоборот, ошибка на стороне сервера, там надо у свойства проставить IsHorizontal = true
          this.state.IsHorizontal ? "forColumnCase" : "blockStyle"
      )
    }
    render() {
       //Проверяет ориентацию - выбирает нужный стиль для верстки
        console.log(this.checkHor());
        let con = [];
        for(let i=0;i < this.state.Links.length;i++)
        {
          let link = this.state.Links[i];
          if(link.Link != undefined && link.Id != undefined && link.Title != undefined)
          {
            con.push(<NavLink className="stylishAAA" to={'/'+link.Link}>{link.Title}</NavLink>);
          }
        }
        return (
        <div className={this.checkHor()}>
            {this.state.MainTitle}
            {con}
        </div>
        
        );
    }

}

export default LinksMenu;