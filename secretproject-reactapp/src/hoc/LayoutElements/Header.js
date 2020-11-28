/* eslint react/prop-types: 0 */
import React, { Children } from 'react';
import { Container, Row, Col } from 'bootstrap-4-react'
// import { Picture, LinkBlock} from "../../basedComponents";
import Picture from "../../basedComponents/Picture"
import LinkBlock from "../../basedComponents/LinkBlock"
import ContactSection from "../../basedComponents/ContactSection"
import "./Header.css"
import logo from './logo.png'
import profileLogo from './profileLogo.png'
import shopLogo from './shopLogo.png'
// import { Dropdown, ButtonGroup, Button, BSpan } from 'bootstrap-4-react'
import ButtonGroup from 'react-bootstrap/ButtonGroup'
import Dropdown1 from 'react-bootstrap/Dropdown'
import Dropdown1Button from 'react-bootstrap/DropdownButton'
import Button from 'react-bootstrap/Button'
import Modal from 'react-bootstrap/Modal'

class Header extends React.Component {
 
    
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

    //Функции
    // function MyVerticallyCenteredModal(props) {
    //     return (
    //       <Modal
    //         {...props}
    //         size="lg"
    //         aria-labelledby="contained-modal-title-vcenter"
    //         centered
    //       >
    //         <Modal.Header closeButton>
    //           <Modal.Title id="contained-modal-title-vcenter">
    //             Modal heading
    //           </Modal.Title>
    //         </Modal.Header>
    //         <Modal.Body>
    //           <h4>Centered Modal</h4>
    //           <p>
    //             Cras mattis consectetur purus sit amet fermentum. Cras justo odio,
    //             dapibus ac facilisis in, egestas eget quam. Morbi leo risus, porta ac
    //             consectetur ac, vestibulum at eros.
    //           </p>
    //         </Modal.Body>
    //         <Modal.Footer>
    //           <Button onClick={props.onHide}>Close</Button>
    //         </Modal.Footer>
    //       </Modal>
    //     );
    //   }
 

    render() {
        return (

            <div>
                <div className="globalStyleTop">
                    <Container>
                        <Row className="rrrOw" >
                            <Col col="lg">
                                <Picture src={logo}></Picture>
                            </Col>
                            <Col col="6">
                                <LinkBlock Links={this.state.Links}></LinkBlock>
                            </Col>
                            <Col col="auto" className="styleForPadding">
                                
                                <ContactSection> </ContactSection>
                            </Col>
                        </Row>
                    </Container>
                </div>
                <div className="globalStyleBottom">
                    <Container>
                        <Row className="rrrOw" >
                            <Col col="lg" className="dropDownStyles">



                                {/* Создание первой кнопки "Каталог" со всеми вложениями */}

                                <Dropdown1Button id="dropdown-item-button" title="Каталог" className='styleForMargin'>
                                    <ButtonGroup vertical>

                                        <Button href="/sdsd" className="styleForAkciiISkidki">Акции и скидки</Button>
                                        <Button href="/sdsds">Стоматологические установки</Button>

                                        <Dropdown1Button as={ButtonGroup} title="Гигиена и профилактика" id="bg-vertical-dropdown-1" drop='right' className="styleForInsideButtons">
                                            <Dropdown1.Item eventKey="1">Гигиена и профилактика</Dropdown1.Item>
                                            <Dropdown1.Item eventKey="2">Ортопедические материалы</Dropdown1.Item>
                                        </Dropdown1Button>

                                        <Dropdown1Button as={ButtonGroup} title="Ортопедические материалы" id="bg-vertical-dropdown-2" drop='right'>
                                            <Dropdown1.Item eventKey="1">Dropdown link</Dropdown1.Item>
                                            <Dropdown1.Item eventKey="2">Dropdown link</Dropdown1.Item>
                                        </Dropdown1Button>

                                        <Dropdown1Button as={ButtonGroup} title="Пломбировочные материалы" id="bg-vertical-dropdown-3" drop='right'>
                                            <Dropdown1.Item eventKey="1">Dropdown link</Dropdown1.Item>
                                            <Dropdown1.Item eventKey="2">Dropdown link</Dropdown1.Item>
                                        </Dropdown1Button>

                                        <Dropdown1Button as={ButtonGroup} title="Приспособления и инструменты" id="bg-vertical-dropdown-3" drop='right'>
                                            <Dropdown1.Item eventKey="1">Dropdown link</Dropdown1.Item>
                                            <Dropdown1.Item eventKey="2">Dropdown link</Dropdown1.Item>
                                        </Dropdown1Button>

                                        <Dropdown1Button as={ButtonGroup} title="Дезинфекция" id="bg-vertical-dropdown-3" drop='right'>
                                            <Dropdown1.Item eventKey="1">Dropdown link</Dropdown1.Item>
                                            <Dropdown1.Item eventKey="2">Dropdown link</Dropdown1.Item>
                                        </Dropdown1Button>

                                        <Dropdown1Button as={ButtonGroup} title="Слепочные массы" id="bg-vertical-dropdown-3" drop='right'>
                                            <Dropdown1.Item eventKey="1">Dropdown link</Dropdown1.Item>
                                            <Dropdown1.Item eventKey="2">Dropdown link</Dropdown1.Item>
                                        </Dropdown1Button>
                                        <Button>Технодент</Button>

                                    </ButtonGroup>
                                </Dropdown1Button>


                                {/* Создание второй кнопки "Обучение" со всеми вложениями */}
                                <Dropdown1Button id="dropdown-item-button" title="Обучение" className='styleForMargin'>
                                    <ButtonGroup vertical>

                                        <Button href="/sdsd" className="styleForAkciiISkidki">Акции и скидки</Button>
                                        <Button href="/sdsds">Стоматологические установки</Button>
                                        <Button>Технодент</Button>

                                    </ButtonGroup>
                                </Dropdown1Button>


                                {/* Создание третьей кнопки "Имплантации" со всеми вложениями */}
                                <Dropdown1Button id="dropdown-item-button" title="Имплантация" className='styleForMargin'>
                                    <ButtonGroup vertical>

                                        <Button href="/sdsd" className="styleForAkciiISkidki">Акции и скидки</Button>
                                        <Button href="/sdsds">Стоматологические установки</Button>
                                        <Button>Технодент</Button>

                                    </ButtonGroup>
                                </Dropdown1Button>








                                {/* AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA */}
                            </Col>
                            <Col col="lg">

                            </Col>

                            <Col col="lg" justify-content="flex-end" className="stylesForShopLogoAndProfileLogo styleForPadding">

                          <Button className='styleForMargin'>
                           <Picture src={shopLogo}></Picture>
                          </Button>
                          <Button className='styleForMargin'>
                           <Picture src={profileLogo}></Picture>
                          </Button>
                            
                            </Col>


                        </Row>
                    </Container>
                </div>
            </div>

        )


    }

}
export default Header



