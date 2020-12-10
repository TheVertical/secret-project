import React from 'react'
import { Row, Col } from 'bootstrap-4-react'
import { Button, Container } from "react-bootstrap"
import './OrderPage.css'
import ".././hoc/LayoutElements/Main.css"
import ProductCardArray from "./../hoComplexComponents/ProductCardArray"
import { NavLink } from 'react-router-dom'
// import ProductCardArray from './../hoCont/ProductCardArray'
import Breadcrumb from 'react-bootstrap/Breadcrumb'


class OrderPage extends React.Component {

    constructor() {
        super();
        this.state = {}
    }

    render() {
        return (
            <div className="mainStyle">
                <div>


                    <Container>
                        <Row>
                            <Breadcrumb>
                                <Breadcrumb.Item href="#">Home</Breadcrumb.Item>
                                <Breadcrumb.Item href="https://getbootstrap.com/docs/4.0/components/breadcrumb/">
                                    Library
                                 </Breadcrumb.Item>
                                <Breadcrumb.Item active>Data</Breadcrumb.Item>
                            </Breadcrumb>
                        </Row>
                        <Row>
                            <h1>Наименование супер-крутого товара в дозировке 2*50мл</h1>
                        </Row>
                        <Container className="OrderPage_OrderBlockStyle">

                            <Row>
                                <img src="./Images/Product1.jpg" className="OrderPage_ImageStyle"></img>
                                <span>Производитель:</span>
                                <NavLink to="/">DentKist</NavLink>
                            </Row>
                            <Row>
                                <h1>2995 ₽</h1>
                                <span>Код: 02641</span>
                                <Row className="OrderPage_InsideRow">
                                <button>-</button>
                                <span></span>
                                <button>+</button>
                                </Row>
                            
                            </Row>

                        </Container>

                    </Container>

                </div>
            </div>
        )
    }

}
export default OrderPage