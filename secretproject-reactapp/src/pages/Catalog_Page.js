// import img_src from '../Images/Product.jpg'
import './Catalog_Page.css'
import ProductCardArray from "./../hoComplexComponents/ProductCardArray"
import React from 'react'
import { Row, Col } from 'bootstrap-4-react'
import { Button, Container } from "react-bootstrap"
import './OrderPage.css'
import ".././hoc/LayoutElements/Main.css"
import { NavLink } from 'react-router-dom'
// import ProductCardArray from './../hoCont/ProductCardArray'
import Breadcrumb from 'react-bootstrap/Breadcrumb'
import Accordion from 'react-bootstrap/Accordion'
import Card from 'react-bootstrap/Card'
import DropdownButton from 'react-bootstrap/DropdownButton'
import Dropdown from 'react-bootstrap/Dropdown'
import DropdownItem from 'react-bootstrap/esm/DropdownItem'
import ButtonGroup from 'react-bootstrap/ButtonGroup'
import Pagination from 'react-bootstrap/Pagination'
import PageItem from 'react-bootstrap/PageItem'

class Catalog_Page extends React.Component {
  constructor() {
    super();
    this.state = {
      sortStyle: "Убыванию цены"
    }

  }

  render() {


    let active = 1;
    let items = [];
    for (let number = 1; number <= 5; number++) {
      items.push(
        <Pagination.Item key={number} active={number === active}>
          {number}
        </Pagination.Item>,
      );
    }

    return (
      <div className="mainStyle">
        <Container>
          <Row >
            <Breadcrumb>
              <Breadcrumb.Item href="#">Home</Breadcrumb.Item>
              <Breadcrumb.Item href="https://getbootstrap.com/docs/4.0/components/breadcrumb/">
                Library
                                 </Breadcrumb.Item>
              <Breadcrumb.Item active>Data</Breadcrumb.Item>
            </Breadcrumb>
          </Row>
          <Row>
            <h1 className="Catalog_Page_H1">Гигиена и профилактика</h1>
          </Row>
          <hr />
          <Row className="Catalog_Page_TitleRow">
            <span>Найдено товаров: 50</span>
            <div className="Catalog_Page_TitleRowDiv">
              <span>Сортировать по: </span>
              <DropdownButton as={ButtonGroup} title={this.state.sortStyle} className="Catalog_Page_SortButtonStyle">
                <DropdownItem eventKey="1" onClick={() => { this.setState({ sortStyle: "Убыванию цены" }) }}>Убыванию цены</DropdownItem>
                <DropdownItem eventKey="2" onClick={() => { this.setState({ sortStyle: "Возрастанию цены" }) }}>Возрастанию цены</DropdownItem>
                <DropdownItem eventKey="3" onClick={() => { this.setState({ sortStyle: "По новинкам" }) }}>По новинкам</DropdownItem>
                <DropdownItem eventKey="4" onClick={() => { this.setState({ sortStyle: "По рейтингу" }) }}>По рейтингу</DropdownItem>
              </DropdownButton>
              <div className="Catalog_Page_SVG_SpisokStyle"></div>
              <div></div>
            </div>
          </Row>
          <Row>
            <Col col="2">
              <Accordion>
                <Card>
                  <Card.Header>
                    <Accordion.Toggle as={Button} variant="link" eventKey="0">
                      Click me!
                     </Accordion.Toggle>
                  </Card.Header>
                  <Accordion.Collapse eventKey="0">
                    <Card.Body>Hello! I'm the body</Card.Body>
                  </Accordion.Collapse>
                </Card>
                <Card>
                  <Card.Header>
                    <Accordion.Toggle as={Button} variant="link" eventKey="1">
                      Click me!
      </Accordion.Toggle>
                  </Card.Header>
                  <Accordion.Collapse eventKey="1">
                    <Card.Body>Hello! I'm another body</Card.Body>
                  </Accordion.Collapse>
                </Card>
              </Accordion>
            </Col>

            <Col>
             <ProductCardArray></ProductCardArray> 
              <Pagination>{items}</Pagination>
          </Col>




          </Row>
        </Container>
      </div>
    )
  }

}
export default Catalog_Page