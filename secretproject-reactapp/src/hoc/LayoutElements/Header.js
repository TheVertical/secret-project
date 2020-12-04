//Библиотечные зависимости
import React, { Children } from 'react';
 import { Container, Row, Col } from 'bootstrap-4-react'
 import Picture from "../../basedComponents/ImageBlock"
import LinkBlock from "../../basedComponents/LinksMenu"
import ContactSectionHeader from "../../ComplexComponents/ContactSectionHeader"
import "./Header.css"
import ButtonGroup from 'react-bootstrap/ButtonGroup'
import Dropdown1 from 'react-bootstrap/Dropdown'
import Dropdown1Button from 'react-bootstrap/DropdownButton'
import Button from 'react-bootstrap/Button'
import Search from '../../ComplexComponents/Search'
//Собственные зависимости
import Block from '../../basedComponents/Block'
// import ContactBlock from '../../AtomicComponents/ContactBlock'
// import LinksMenu from '../../AtomicComponents/LinksMenu'
import VisualElement from '../../basedComponents/VisualElement'


class Header extends React.Component {
    /*Constructors*/
    constructor(props) {
        super(props)
        this.state = {
            Id: props.Id,
            Row: props.Row,
            NeededColumns: props.NeededColumns,
            VisualElements: props.VisualElements

        }
    }

    //Функции


    render() {
        return (



            <div id = "block">
                   {this.state.VisualElements.map(obj =><Col col={obj.NeededColumns}> {VisualElement.renderVisualElement(obj)}</Col>)}
            </div>

            // <div>
            //     <div className="globalStyleTop">
            //         <Container>
            //             <Row className="rrrOw" >
            //                 <Col col="lg" className="styleForPadding">
            //                     <Picture src={'./Images/logo.png'}></Picture>
            //                 </Col>
            //                 <Col col="6">
            //                 <LinksMenu Id = {0} Links = 
            //                     {[
            //                         {Id:0,Title:"Доставка и оплата",Link:"#"},
            //                         {Id:0,Title:"Доставка и оплата",Link:"#"},
            //                         {Id:0,Title:"Доставка и оплата",Link:"#"},
            //                         {Id:0,Title:"Доставка и оплата",Link:"#"},
            //                         {Id:0,Title:"Доставка и оплата",Link:"#"},
            //                         {Id:0,Title:"Доставка и оплата",Link:"#"},
            //                     ]}></LinksMenu>
            //                 </Col>
            //                 <Col col="auto" className="styleForPadding">
            //                     <ContactBlock Phone="8 (953) 660-0012" OpeningHours="Пн-Чт 10:00-18:00, Пт:9:00-17:00" IsHeaderStyle={true}></ContactBlock>
            //                 </Col>
            //             </Row>
            //         </Container>
            //     </div>
            //     <div className="globalStyleBottom">
            //         <Container>
            //             <Row className="rrrOw" >
            //                 <Col col="lg" className="dropDownStyles">



            //                     {/* Создание первой кнопки "Каталог" со всеми вложениями */}

            //                     <Dropdown1Button id="dropdown-item-button" title="Каталог" className='styleForMargin'>
            //                         <ButtonGroup vertical>

            //                             <Button href="/sdsd" className="styleForAkciiISkidki">Акции и скидки</Button>
            //                             <Button href="/sdsds">Стоматологические установки</Button>

            //                             <Dropdown1Button as={ButtonGroup} title="Гигиена и профилактика" id="bg-vertical-dropdown-1" drop='right' className="styleForInsideButtons">
            //                                 <Dropdown1.Item eventKey="1">Гигиена и профилактика</Dropdown1.Item>
            //                                 <Dropdown1.Item eventKey="2">Ортопедические материалы</Dropdown1.Item>
            //                             </Dropdown1Button>

            //                             <Dropdown1Button as={ButtonGroup} title="Ортопедические материалы" id="bg-vertical-dropdown-2" drop='right'>
            //                                 <Dropdown1.Item eventKey="1">Dropdown link</Dropdown1.Item>
            //                                 <Dropdown1.Item eventKey="2">Dropdown link</Dropdown1.Item>
            //                             </Dropdown1Button>

            //                             <Dropdown1Button as={ButtonGroup} title="Пломбировочные материалы" id="bg-vertical-dropdown-3" drop='right'>
            //                                 <Dropdown1.Item eventKey="1">Dropdown link</Dropdown1.Item>
            //                                 <Dropdown1.Item eventKey="2">Dropdown link</Dropdown1.Item>
            //                             </Dropdown1Button>

            //                             <Dropdown1Button as={ButtonGroup} title="Приспособления и инструменты" id="bg-vertical-dropdown-3" drop='right'>
            //                                 <Dropdown1.Item eventKey="1">Dropdown link</Dropdown1.Item>
            //                                 <Dropdown1.Item eventKey="2">Dropdown link</Dropdown1.Item>
            //                             </Dropdown1Button>

            //                             <Dropdown1Button as={ButtonGroup} title="Дезинфекция" id="bg-vertical-dropdown-3" drop='right'>
            //                                 <Dropdown1.Item eventKey="1">Dropdown link</Dropdown1.Item>
            //                                 <Dropdown1.Item eventKey="2">Dropdown link</Dropdown1.Item>
            //                             </Dropdown1Button>

            //                             <Dropdown1Button as={ButtonGroup} title="Слепочные массы" id="bg-vertical-dropdown-3" drop='right'>
            //                                 <Dropdown1.Item eventKey="1">Dropdown link</Dropdown1.Item>
            //                                 <Dropdown1.Item eventKey="2">Dropdown link</Dropdown1.Item>
            //                             </Dropdown1Button>
            //                             <Button>Технодент</Button>

            //                         </ButtonGroup>
            //                     </Dropdown1Button>


            //                     {/* Создание второй кнопки "Обучение" со всеми вложениями */}
            //                     <Dropdown1Button id="dropdown-item-button" title="Обучение" className='styleForMargin'>
            //                         <ButtonGroup vertical>

            //                             <Button href="/sdsd" className="styleForAkciiISkidki">Акции и скидки</Button>
            //                             <Button href="/sdsds">Стоматологические установки</Button>
            //                             <Button>Технодент</Button>

            //                         </ButtonGroup>
            //                     </Dropdown1Button>


            //                     {/* Создание третьей кнопки "Имплантации" со всеми вложениями */}
            //                     <Dropdown1Button id="dropdown-item-button" title="Имплантация" className='styleForMargin'>
            //                         <ButtonGroup vertical>

            //                             <Button href="/sdsd" className="styleForAkciiISkidki">Акции и скидки</Button>
            //                             <Button href="/sdsds">Стоматологические установки</Button>
            //                             <Button>Технодент</Button>

            //                         </ButtonGroup>
            //                     </Dropdown1Button>
            //                     <Button href = "#" value = "BB">BB</Button>








            //                     {/* AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA */}
            //                 </Col>
            //                 <Col col="6" className="styleForPadding">
            //                     <Search></Search>
            //                 </Col>

            //                 <Col col="lg" className="stylesForShopLogoAndProfileLogo styleForPadding">

            //                     <Button className='styleForMargin'>
            //                         <Picture src={'./Images/shopLogo.png'}></Picture>
            //                     </Button>
            //                     <Button className='styleForMargin'>
            //                         <Picture src={'./Images/profileLogo.png'}></Picture>
            //                     </Button>

            //                 </Col>


            //             </Row>
            //         </Container>
            //     </div>
            // </div >

        )

    }
}

export default Header



