import React from 'react'
import { Row, Col } from 'bootstrap-4-react'
import { Button, Container } from "react-bootstrap"
import './OrderPage.css'
import ".././hoc/LayoutElements/Main.css"
import ProductCardArray from "./../hoComplexComponents/ProductCardArray"
import { NavLink } from 'react-router-dom'
// import ProductCardArray from './../hoCont/ProductCardArray'
import Breadcrumb from 'react-bootstrap/Breadcrumb'
import Tabs from 'react-bootstrap/Tabs'
import Tab from 'react-bootstrap/Tab'

class OrderPage extends React.Component {

    constructor() {
        super();
        this.state = {
            count: 0
        }
    }

    doIncrease() {
        this.setState((state) => {
            return { count: state.count + 1 }
        });
    }
    doDecrease() {
        this.setState((state) => {
            if (state.count > 0)
                return { count: state.count - 1 }
        });
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
                            <h1 className="OrderPage_TitleH1Style">Наименование супер-крутого товара в дозировке 2*50мл</h1>
                        </Row>

                        <Container className="OrderPage_Global">
                            <Row className="OrderPage_OrderBlockStyle">

                                <Col>
                                    <img src="./Images/Product1.jpg" className="OrderPage_ImageStyle"></img>
                                    <span>Производитель:</span>
                                    <NavLink to="/">DentKist</NavLink>
                                </Col>
                                <Col>
                                    <h1 className="OrderPage_H1Style">2995 ₽</h1>
                                    <span className="OrderPage_IdSpanStyle">Код: 02641</span>
                                    <div className="OrderPage_InsideRow">
                                        <div className="OrderPage_ClickerBlockStyle">
                                            <Button onClick={this.doDecrease.bind(this)} className="OrderPage_ClickerBlockButtonStyle">-</Button>
                                            <span className="OrderPage_ClickerBlockSpanStyle">{this.state.count}</span>
                                            <Button onClick={this.doIncrease.bind(this)} className="OrderPage_ClickerBlockButtonStyle">+</Button>
                                        </div>
                                        <span className="OrderPage_ClickerBlockSpanStyle2">В наличии: много</span>
                                    </div>
                                    <Button className="OrderPage_ButtonStyle"><div className="OrderPage_ButtonDivStyle"><img src="./Images/trolley.png"></img><span className="OrderPage_SpanStyle">В корзину</span></div></Button>
                                    <Button className="OrderPage_ComparenSaveButtonStyle"><div className="OrderPage_ButtonDivStyle"><img src="./Images/CompareIcon.png"></img><span className="OrderPage_ComparenSaveSpanStyle">Сравнить</span></div></Button>
                                    <Button className="OrderPage_ComparenSaveButtonStyle"><div className="OrderPage_ButtonDivStyle"><img src="./Images/SaveIcon.png"></img><span className="OrderPage_ComparenSaveSpanStyle">Отложить</span></div></Button>
                                    <div className="OrderPage_InsideRow">
                                        <div>
                                            <button className="OrderPage_StarStyle"></button>
                                            <button className="OrderPage_StarStyle"></button>
                                            <button className="OrderPage_StarStyle"></button>
                                            <button className="OrderPage_StarStyle"></button>
                                            <button className="OrderPage_StarStyle"></button>
                                        </div>
                                        <Button>Отправить отзыв</Button>
                                    </div>

                                </Col>


                            </Row>
                            <Row>
                                <Tabs defaultActiveKey="home" transition={false} id="noanim-tab-example">
                                    <Tab eventKey="home" title="Характеристики и описание">
                                        <p>Компания "Олимп-Дентал" предлагает широкий спектр расходных материалов, инструментов,дезинфакторов, стоматологического оборудования, мебели и стоматологических установок ведущих производителей.</p>
                                    </Tab>
                                    <Tab eventKey="profile" title="Отзывы">
                                        <p>Компания "Олимп-Дентал" предлагает широкий спектр расходных материалов, инструментов,дезинфакторов, стоматологического оборудования, мебели и стоматологических установок ведущих производителей.</p>

                                    </Tab>
                                    <Tab eventKey="contact" title="Похожие товары">
                                        <p>Компания "Олимп-Дентал" предлагает широкий спектр расходных материалов, инструментов,дезинфакторов, стоматологического оборудования, мебели и стоматологических установок ведущих производителей.</p>
                                    </Tab>
                                </Tabs>
                            </Row>

                        </Container>






                    </Container>

                </div>
            </div >
        )
    }

}
export default OrderPage