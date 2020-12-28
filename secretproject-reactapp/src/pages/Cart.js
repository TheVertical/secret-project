import React from 'react'
import { Row, Col, Container } from 'bootstrap-4-react'
import { Button } from "react-bootstrap"
import './Cart.css'
import ".././hoc/LayoutElements/Main.css"
import CartProductArray from "./../hoComplexComponents/CartProductArray"
import { NavLink } from 'react-router-dom'
import Breadcrumb from 'react-bootstrap/Breadcrumb'
import Form from 'react-bootstrap/Form'
import { MakeServerQuery } from '../Services/ServerQuery'
import CartElement from "./../ComplexComponents/CartElement"

class Cart extends React.Component {

  constructor() {
    super();
    this.state = {
      FullCost: 0,
      CartLines: undefined
    }
  }
  componentDidMount() {
    this.getCartLineList();
  }
  async getCartLineList() {
    let query = '/cart/list';
    let responce = await MakeServerQuery('GET', query);
    if (responce != undefined && responce.success) {
      this.setState({ FullCost: responce.data.FullCost, CartLines: responce.data.Lines });
      console.debug(responce.data);
    }
    else
      alert('Error. Something was happend.');
  }
  getLines() {
    let count = 0;
    let array = [];
    if(this.state.CartLines)
    this.state.CartLines.map(l => {
      array.push(
          <CartElement key={count}
           key={l.Model.Id}
           Id={l.Model.Id}
           Amount={l.Amount}
           ImageUrl={l.Model.ImageUrl}
           Title={this.ReturnSubString(l.Model.Title)}
           OriginalPrice={l.Model.OriginalPrice}
           Description={l.Model.Description}
           IsDiscouted={l.Model.IsDiscouted}
           IsInStock={l.Model.IsInStock}
           IsNew={l.Model.IsNew}
           IsPopular={l.Model.IsPopular} />
      )
      count++;
    });
    return array;
  }

  ReturnSubString(str) {
    if (str != undefined && str.length >= 20) { return str.substr(0, 17) + "..." }
    return str;
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
              {this.getLines()}
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
                <Form.Control placeholder="Введите промокод:" />
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