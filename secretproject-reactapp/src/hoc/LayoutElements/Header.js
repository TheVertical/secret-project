/* eslint react/prop-types: 0 */
import React, { Children } from 'react';
import { Container, Row, Col } from 'bootstrap-4-react'
// import { Picture, LinkBlock} from "../../basedComponents";
import Picture from "../../basedComponents/Picture"
import LinkBlock from "../../basedComponents/LinkBlock"
import ContactSection from "../../basedComponents/ContactSection"
import "./Header.css"
import logo from './logo.png'
import { Dropdown, ButtonGroup, Button, BSpan } from 'bootstrap-4-react'
import Dropdown1 from 'react-bootstrap/Dropdown'
import Dropdown1Button from 'react-bootstrap/DropdownButton'


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

    // const getNewState=()=>{

    // }

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
                            <Col col="lg">
                                <ContactSection></ContactSection>
                            </Col>
                        </Row>
                    </Container>
                </div>
                <div className="globalStyleBottom">
                    <Container>
                        <Row className="rrrOw" >
                            <Col col="lg" className="dropDownStyles">
                                {/* <Dropdown>
                                    <Dropdown.Button secondary id="dropdownMenuButton">Каталог</Dropdown.Button>
                                    <Dropdown.Menu aria-labelledby="dropdownMenuButton">
                                        <Dropdown.Item href="#" disabled>Акции и скидки</Dropdown.Item>
                                        <Dropdown.Item href="#" disabled>Стоматологические установки</Dropdown.Item>
                                             
                                         <Dropdown.Item disabled>
                                        <ButtonGroup dropright>
                                            <Dropdown.Button success>Гигиена и профилактика</Dropdown.Button>
                                            <Dropdown.Menu>
                                                <Dropdown.Item href="#" active>Action</Dropdown.Item>
                                                <Dropdown.Item disabled>Another action</Dropdown.Item>
                                                <Dropdown.Item>Something else here</Dropdown.Item>
                                                <Dropdown.Divider />
                                                <Dropdown.Item>Separated link</Dropdown.Item>
                                            </Dropdown.Menu>
                                        </ButtonGroup>
                                        </Dropdown.Item>

                                        <Dropdown.Item href="" disabled>
                                        <ButtonGroup dropright>
                                            <Dropdown.Button success>Ортопедические материалы</Dropdown.Button>
                                            <Dropdown.Menu>
                                                <Dropdown.Item href="#" active>Action</Dropdown.Item>
                                                <Dropdown.Item disabled>Another action</Dropdown.Item>
                                                <Dropdown.Item>Something else here</Dropdown.Item>
                                                <Dropdown.Divider />
                                                <Dropdown.Item>Separated link</Dropdown.Item>
                                            </Dropdown.Menu>
                                        </ButtonGroup>
                                        </Dropdown.Item>


                                        <Dropdown.Item href="#" disabled>
                                        <ButtonGroup dropright>
                                            <Dropdown.Button success>Слепочные массы</Dropdown.Button>
                                            <Dropdown.Menu>
                                                <Dropdown.Item href="#" active>Action</Dropdown.Item>
                                                <Dropdown.Item disabled>Another action</Dropdown.Item>
                                                <Dropdown.Item>Something else here</Dropdown.Item>
                                                <Dropdown.Divider />
                                                <Dropdown.Item>Separated link</Dropdown.Item>
                                            </Dropdown.Menu>
                                        </ButtonGroup>
                                        </Dropdown.Item>

                                        <Dropdown.Item href="#" disabled>
                                        <ButtonGroup dropright>
                                            <Dropdown.Button success>Пломбировочные материалы</Dropdown.Button>
                                            <Dropdown.Menu>
                                                <Dropdown.Item href="#" active>Action</Dropdown.Item>
                                                <Dropdown.Item disabled>Another action</Dropdown.Item>
                                                <Dropdown.Item>Something else here</Dropdown.Item>
                                                <Dropdown.Divider />
                                                <Dropdown.Item>Separated link</Dropdown.Item>
                                            </Dropdown.Menu>
                                        </ButtonGroup>
                                        </Dropdown.Item>

                                        <Dropdown.Item href="#" disabled>
                                        <ButtonGroup dropright>
                                            <Dropdown.Button success>Приспособления и инструменты</Dropdown.Button>
                                            <Dropdown.Menu>
                                                <Dropdown.Item href="#" active>Action</Dropdown.Item>
                                                <Dropdown.Item disabled>Another action</Dropdown.Item>
                                                <Dropdown.Item>Something else here</Dropdown.Item>
                                                <Dropdown.Divider />
                                                <Dropdown.Item>Separated link</Dropdown.Item>
                                            </Dropdown.Menu>
                                        </ButtonGroup>
                                        </Dropdown.Item>

                                        <Dropdown.Item href="#" disabled>
                                        <ButtonGroup dropright>
                                            <Dropdown.Button success>Дезинфекция</Dropdown.Button>
                                            <Dropdown.Menu>
                                                <Dropdown.Item href="#" active>Action</Dropdown.Item>
                                                <Dropdown.Item disabled>Another action</Dropdown.Item>
                                                <Dropdown.Item>Something else here</Dropdown.Item>
                                                <Dropdown.Divider />
                                                <Dropdown.Item>Separated link</Dropdown.Item>
                                            </Dropdown.Menu>
                                        </ButtonGroup>
                                        </Dropdown.Item>
                                        <ButtonGroup dropright>

                                            <Dropdown.Button success>Дезинфекция</Dropdown.Button>
                                            <Dropdown.Menu>
                                                <Dropdown.Item href="#" active>Action</Dropdown.Item>
                                                <Dropdown.Item disabled>Another action</Dropdown.Item>
                                                <Dropdown.Item>Something else here</Dropdown.Item>
                                                <Dropdown.Divider />
                                                <Dropdown.Item>Separated link</Dropdown.Item>
                                            </Dropdown.Menu>
                                            </ButtonGroup> 
                                            <div className="mb-2">
    {['up', 'down', 'left', 'right'].map((direction) => (
      <Dropdown1Button
        as={ButtonGroup}
        key={direction}
        id={`dropdown-button-drop-${direction}`}
        drop={direction}
        variant="secondary"
        title={` Drop ${direction} `}
      >
        <Dropdown1.Item eventKey="1">Action</Dropdown1.Item>
        <Dropdown1.Item eventKey="2">Another action</Dropdown1.Item>
        <Dropdown1.Item eventKey="3">Something else here</Dropdown1.Item>
        <Dropdown1.Divider />
        <Dropdown1.Item eventKey="4">Separated link</Dropdown1.Item>
      </Dropdown1Button>
    ))}
  </div>

                                        <Dropdown.Item href="#" disabled>ТехноДент</Dropdown.Item>







                                    </Dropdown.Menu>
                                </Dropdown>
                                <Dropdown>
                                    <Dropdown.Button secondary id="dropdownMenuButton">Обучение</Dropdown.Button>
                                    <Dropdown.Menu aria-labelledby="dropdownMenuButton">
                                        <Dropdown.Item href="#" active>Action</Dropdown.Item>
                                        <Dropdown.Item disabled>Another action</Dropdown.Item>
                                        <Dropdown.Item>Something else here</Dropdown.Item>
                                    </Dropdown.Menu>
                                </Dropdown>
                                <Dropdown>
                                    <Dropdown.Button secondary id="dropdownMenuButton">Имплантация</Dropdown.Button>
                                    <Dropdown.Menu aria-labelledby="dropdownMenuButton">
                                        <Dropdown.Item href="#" active>Action</Dropdown.Item>
                                        <Dropdown.Item disabled>Another action</Dropdown.Item>
                                        <Dropdown.Item>Something else here</Dropdown.Item>
                                    </Dropdown.Menu>
                                </Dropdown> */}

                                {/* AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA */}

                                <Dropdown1Button id="dropdown-item-button" title="Каталог">
                                    <Dropdown1.Item href="#">Акции и скидки</Dropdown1.Item>
                                    <Dropdown1.Item href="#">Стоматологические установки</Dropdown1.Item>
                                    <Dropdown1.ItemText>
                                        <Dropdown1Button as={ButtonGroup}  drop='right' title="Гигиена и профилактика">
                                        <Dropdown1.Item as="button">Another action</Dropdown1.Item>
                                        <Dropdown1.Item as="button">Something else</Dropdown1.Item>
                                        </Dropdown1Button>
                                    </Dropdown1.ItemText>
                                    <Dropdown1.ItemText>
                                        <Dropdown1Button as={ButtonGroup}  drop='right' title="Ортопедические материалы">
                                        <Dropdown1.Item as="button">Another action</Dropdown1.Item>
                                        <Dropdown1.Item as="button">Something else</Dropdown1.Item>
                                        </Dropdown1Button>
                                    </Dropdown1.ItemText>
                                    <Dropdown1.ItemText>
                                        <Dropdown1Button as={ButtonGroup}  drop='right' title="Пломбировочные материалы">
                                        <Dropdown1.Item as="button">Another action</Dropdown1.Item>
                                        <Dropdown1.Item as="button">Something else</Dropdown1.Item>
                                        </Dropdown1Button>
                                    </Dropdown1.ItemText>
                                    <Dropdown1.ItemText>
                                        <Dropdown1Button as={ButtonGroup}  drop='right' title="Приспособления и инструменты">
                                        <Dropdown1.Item as="button">Another action</Dropdown1.Item>
                                        <Dropdown1.Item as="button">Something else</Dropdown1.Item>
                                        </Dropdown1Button>
                                    </Dropdown1.ItemText>
                                    <Dropdown1.ItemText>
                                        <Dropdown1Button as={ButtonGroup}  drop='right' title="Дезинфекция">
                                        <Dropdown1.Item as="button">Another action</Dropdown1.Item>
                                        <Dropdown1.Item as="button">Something else</Dropdown1.Item>
                                        </Dropdown1Button>
                                    </Dropdown1.ItemText>
                                    <Dropdown1.ItemText>
                                        <Dropdown1Button as={ButtonGroup}  drop='right' title="Слепочные массы">
                                        <Dropdown1.Item as="button">Another action</Dropdown1.Item>
                                        <Dropdown1.Item as="button">Something else</Dropdown1.Item>
                                        </Dropdown1Button>
                                    </Dropdown1.ItemText>
                                    <Dropdown1.Item href="">Технодент</Dropdown1.Item>
                           
                                </Dropdown1Button>

                                <Dropdown1Button id="dropdown-item-button" title="Обучение">
                                    <Dropdown1.ItemText>Dropdown item text</Dropdown1.ItemText>
                                    <Dropdown1.ItemText>
                                        <Dropdown1Button as={ButtonGroup}  drop='right'>
                                        <Dropdown1.Item as="button">Another action</Dropdown1.Item>
                                        <Dropdown1.Item as="button">Something else</Dropdown1.Item>
                                        </Dropdown1Button>
                                    </Dropdown1.ItemText>
                                    <Dropdown1.Item as="button">Another action</Dropdown1.Item>
                                    <Dropdown1.Item as="button">Something else</Dropdown1.Item>
                                </Dropdown1Button>

                                <Dropdown1Button id="dropdown-item-button" title="Имплантации">
                                    <Dropdown1.ItemText>Dropdown item text</Dropdown1.ItemText>
                                    <Dropdown1.ItemText>
                                        <Dropdown1Button as={ButtonGroup}  drop='right'>
                                        <Dropdown1.Item as="button">Another action</Dropdown1.Item>
                                        <Dropdown1.Item as="button">Something else</Dropdown1.Item>
                                        </Dropdown1Button>
                                    </Dropdown1.ItemText>
                                    <Dropdown1.Item as="button">Another action</Dropdown1.Item>
                                    <Dropdown1.Item as="button">Something else</Dropdown1.Item>
                                </Dropdown1Button>

                                {/* AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA */}
                            </Col>
                            <Col col="lg">

                            </Col>

                            <Col col="lg">
                            </Col>


                        </Row>
                    </Container>
                </div>
            </div>

        )


    }

}
export default Header



