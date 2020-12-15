import React from 'react'
import {Row, Col, Container } from 'bootstrap-4-react'
import {Button} from "react-bootstrap"
import './Cart.css'
import ".././hoc/LayoutElements/Main.css"
import ProductCardArray from "./../hoComplexComponents/ProductCardArray"
import CartProductArray from "./../hoComplexComponents/CartProductArray"
import {NavLink} from 'react-router-dom'
import Breadcrumb from 'react-bootstrap/Breadcrumb'
import Accordion from 'react-bootstrap/Accordion'
import Card from 'react-bootstrap/Card'
import Form from 'react-bootstrap/Form'
class Cart extends React.Component {

    constructor() {
        super();
        this.state = {}
    }

    render() {
        return (
            <div className="mainStyle">
        <Container>
          <Row >
            <Breadcrumb>
              <Breadcrumb.Item href="/">Главная</Breadcrumb.Item>
              <Breadcrumb.Item active>Корзина</Breadcrumb.Item>
            </Breadcrumb>
          </Row>
          <Row>
            <h1 className="Catalog_Page_H1">Корзина</h1>
          </Row>
          <hr />
         
          <Row>
            <Col col="8">
              <CartProductArray></CartProductArray>
            </Col>

            <Col>
           <div className="Cart_ContainerStyle">
               <h1>Итого</h1>
               <hr></hr>
               <div className="Cart_ContainerInsideStyle">
                   <span>Стоимость</span>
                   <span>2000 ₽</span>
               </div>
               <div className="Cart_ContainerInsideStyle">
                   <span>Скидка</span>
                   <span>100 ₽</span>
               </div>
               <div className="Cart_ContainerInsideStyle">
                   <span>Кол-во товаров</span>
                   <span>3</span>
               </div>
               <hr></hr>
               <div className="Cart_ContainerInsideStyle">
                <span>Всего к оплате:</span>
                <h1>3600 ₽</h1>
               
               </div>
               <Form.Control placeholder="Введите промокод:"/>
               <NavLink to="/seventh">
               <Button className="Cart_ButtonStyle">Перейти к оплате</Button>
               </NavLink>
           </div>
           </Col>

          </Row>
        </Container>
      </div>
        )
    }

}
export default Cart