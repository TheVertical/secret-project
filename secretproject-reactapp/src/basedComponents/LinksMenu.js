//Библиотечные зависимости
import React from 'react'
import linkblock from '../basedComponents/LinksMenu';
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