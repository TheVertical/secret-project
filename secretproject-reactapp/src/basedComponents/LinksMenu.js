//Библиотечные зависимости
import React from 'react'
import linkblock from '../basedComponents/LinksMenu';

//Собственные зависимости
import "./ContactBlock.css"

//Расширяет или не расширяет React.Component?
class LinksMenu extends React.Component{
    constructor(props)
    {
        super();
        this.state ={
            Id: props.Id,
            Links: props.Links
        }
    }
    //Функции React

    //Собственные функции класса

    render(){
        return(
        <div className="blockStyle">
            {this.state.Links.map((link)=>
            <a className="stylishAAA" key={link.Id} href={link.Link}>{link.Title}</a>
            )}
        </div>
        );
    }

}

export default LinksMenu;