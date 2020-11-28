import React, { Children } from 'react';
import './Footer.css';
import { Container, Row, Col } from 'bootstrap-4-react'
import Picture from "../../basedComponents/Picture"
import LinkBlock from "../../basedComponents/LinkBlock"
import Form from 'react-bootstrap/Form'
import LinkList from '../../containers/LinkList'
import ContactSectionFoot from '../../containers/ContactSectionFoot'
import bottomLogo from "../../Images/bottomSecureLogo.png"

class Footer extends React.Component {

    constructor() {
        super()
        this.state = {
            isColumn: false,
            Links: {
                "Доставка и оплата": "#",
                "Возврат": "#",
                "Пункт самовывоза": "#",
                "Возврат": "#",
                "Новости": "#",
                "Акции и скидки": "#",
                "Отзывы": "#",
                "Обучение": "#"
            }
        }
    }

    render(props) {
        return (

            <div className="globalStyleFooter">
                <Container>
                    <Row className="AlignCenter">
                        <Col col="lg-auto">
                            <h1>Оставайтесь на связи!</h1>
                        </Col>
                    
                        <Col>
                            <Form>
                                <Form.Group controlId="exampleForm.ControlInput1" className="styleForInput">
                                    <Form.Control type="email" placeholder="name@example.com" />
                                </Form.Group>
                            </Form>
                        </Col>
                        <Col>
                     
                        </Col>
                    </Row>
                    <hr></hr>
                    <Row>
                      <Col col="lg">
                      <LinkList Links={this.state.Links} Title="Моя учетная запись"></LinkList>
                      </Col>
                      <Col col="lg">
                      <LinkList Links={this.state.Links} Title="Магазин"></LinkList>
                      </Col>
                      <Col col="lg">
                      <LinkList  Links={this.state.Links} Title="Cервис"></LinkList>
                      </Col>
                      <Col col="lg">
                      <ContactSectionFoot></ContactSectionFoot>
                      </Col>
                    </Row>
                    <Row className="styyyyleForMargin">
                      <Col col="lg-auto">
                      <Picture src={bottomLogo}></Picture>
                      </Col>
                      <Col col="lg-auto">
                    
                      </Col>
                      <Col col="lg-auto">
                    
                      </Col>
                    </Row>
                </Container>
            </div>
        );
    }


}

export default Footer