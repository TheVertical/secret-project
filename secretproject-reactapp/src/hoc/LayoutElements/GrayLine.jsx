//Библиотечные зависимости
import React, { Children } from 'react';
import { Container } from 'bootstrap-4-react';
//Собственные зависимости


class GrayLine extends React.Component {
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
        <div className ="globalStyleBottom">{this.state.Content}</div>
        );

    }
}

export default GrayLine
