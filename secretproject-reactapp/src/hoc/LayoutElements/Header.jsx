//Библиотечные зависимости
import React, { Children } from 'react';
import { Container, Row, Col } from 'bootstrap-4-react'

import ImageBlock from '../../basedComponents/ImageBlock';
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
            <Container>
                <Row>
                    <Col Col="sm-3" className="d-flex align-items-center">
                        <ImageBlock Alt="Olimp-dental" Source="/Images/logo.png" />
                    </Col>
                    <Col Col="sm-3" className="d-flex align-items-center">
                        <ImageBlock Alt="Olimp-dental" Source="/Images/logo.png" />
                    </Col>
                </Row>
            </Container>
        );

    }
}

export default Header



