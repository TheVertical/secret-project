//Библиотечные зависимости
import React from 'react'
import linkblock from '../basedComponents/LinkBlock';

//Собственные зависимости
import "./ContactBlock.css"

//Расширяет или не расширяет React.Component?
class LinksMenu extends React.Component{
    constructor(props)
    {
        super();
        this.state ={
            Id: props.Id,
            Liks: props.Links
        }
    }
    //Функции React

    //Собственные функции класса

    render(){
        return(
        <div className="blockStyle">
            {this.state.Liks.map((link)=>
            <a className="stylishAAA" key={link.Id} href={link.Link}>{link.Title}</a>
            )}
        </div>
        );
    }

}

export default LinksMenu;