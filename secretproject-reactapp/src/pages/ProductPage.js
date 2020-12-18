import React from 'react'
import { Row, Col } from 'bootstrap-4-react'
import { Button, Container } from "react-bootstrap"
import './ProductPage.css'
import ".././hoc/LayoutElements/Main.css"
import ProductCardArray from "../hoComplexComponents/ProductCardArray"
import { NavLink } from 'react-router-dom'
// import ProductCardArray from './../hoCont/ProductCardArray'
import Breadcrumb from 'react-bootstrap/Breadcrumb'
import Tabs from 'react-bootstrap/Tabs'
import Tab from 'react-bootstrap/Tab'

class ProductPage extends React.Component {

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
                                <Breadcrumb.Item href="/">Главная</Breadcrumb.Item>
                                <Breadcrumb.Item href="/catalog">
                                    Каталог
                                 </Breadcrumb.Item>
                                <Breadcrumb.Item active>Data</Breadcrumb.Item>
                            </Breadcrumb>
                        </Row>
                        <Row>
                            <h1 className="ProductPage_TitleH1Style">Наименование супер-крутого товара в дозировке 2*50мл</h1>
                        </Row>

                        <Container className="ProductPage_Global">
                            <Row className="ProductPage_OrderBlockStyle">

                                <Col>
                                    <img src="./Images/Product1.jpg" className="ProductPage_ImageStyle"></img>
                                    <span style={{color:"gray"}}>Производитель:</span>
                                    <NavLink to="/" style={{color:"black"}}>DentKist</NavLink>
                                </Col>
                                <Col xs lg="4">
                                    <h1 className="ProductPage_H1Style">2995 ₽</h1>
                                    <span className="ProductPage_IdSpanStyle">Код: 02641</span>
                                    <div className="ProductPage_InsideRow">
                                        <div className="ProductPage_ClickerBlockStyle">
                                            <Button onClick={this.doDecrease.bind(this)} className="ProductPage_ClickerBlockButtonStyle">-</Button>
                                            <span className="ProductPage_ClickerBlockSpanStyle">{this.state.count}</span>
                                            <Button onClick={this.doIncrease.bind(this)} className="ProductPage_ClickerBlockButtonStyle">+</Button>
                                        </div>
                                        <span className="ProductPage_ClickerBlockSpanStyle2">В наличии: много</span>
                                    </div>
                                    <Button className="ProductPage_ButtonStyle" active="true"><div className="ProductPage_ButtonDivBasketStyle"><img src="./Images/trolley.png"></img><span className="ProductPage_SpanStyle">В корзину</span></div></Button>
                                    <Button className="ProductPage_ComparenSaveButtonStyle"><div className="ProductPage_ButtonDivComareNSaveStyle"><img src="./Images/CompareIcon.png"></img><span className="ProductPage_ComparenSaveSpanStyle">Сравнить</span></div></Button>
                                    <Button className="ProductPage_ComparenSaveButtonStyle"><div className="ProductPage_ButtonDivComareNSaveStyle"><img src="./Images/SaveIcon.png"></img><span className="ProductPage_ComparenSaveSpanStyle">Отложить</span></div></Button>
                                    <div className="ProductPage_InsideRow">
                                        <div>
                                            <button className="ProductPage_StarStyle"></button>
                                            <button className="ProductPage_StarStyle"></button>
                                            <button className="ProductPage_StarStyle"></button>
                                            <button className="ProductPage_StarStyle"></button>
                                            <button className="ProductPage_StarStyle"></button>
                                        </div>
                                        <Button className="ProductPage_ButtonSendReviewStyle">Отправить отзыв</Button>
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
export default ProductPage