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

class Catalog_Page extends React.Component {
  constructor() {
    super();
    this.state = {}
  }

  render() {
    return (
      <div className="mainStyle">
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
            <h1 className="Catalog_Page_H1">Гигиена и профилактика</h1>
          </Row>
          <hr />
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
          </Col>

        
          
          
          </Row>
        </Container>
      </div>
    )
  }

}
export default Catalog_Page