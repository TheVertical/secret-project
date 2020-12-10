//Библиотечные зависимости
import React, { Children } from 'react';
import { Container } from 'bootstrap-4-react';
import "./Header.css"
//Собственные зависимости


class Header extends React.Component {
    /*Constructors*/
    constructor(props) {
        super(props)
        this.state = {
            Content: props.Content
        }
    }

    //Функции


    render() {
        return (
        <div className ="globalStyleTop">{this.props.children}</div>
        );

    }
}

export default Header



