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
import { withRouter } from 'react-router-dom'


class ProductPage extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            Id: props.match.params.id,
            count: 0,
            DownloadedNomenclature: undefined,
            IsLoading: true,
        }
    }

    componentDidMount() {
        if (this.state.Id != undefined)
            this.LoadNomenclature(this.state.Id);
        else
            this.state.history.push('/404');
    }

    async LoadNomenclature(id) {
        let url = 'https://secrethost.azurewebsites.net/catalog/product/' + id;
        let response = await fetch(url);
        if (!response.ok) { alert(response) }
        let json = await response.json();
        this.setState({ DownloadedNomenclature: json, IsLoading: false });
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
        if (this.state.IsLoading)
            return ('...Loading');
        else
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
                                <h1 className="ProductPage_TitleH1Style">{this.state.DownloadedNomenclature.Title}</h1>
                            </Row>
                            <Container className="ProductPage_Global">
                                <Row className="ProductPage_OrderBlockStyle">
                                    <Col>
                                        <img src="./Images/Product1.jpg" className="ProductPage_ImageStyle"></img>
                                        <span>Производитель:</span>
                                        <NavLink to="/">{this.state.DownloadedNomenclature.Manufactrer}</NavLink>
                                    </Col>
                                    <Col>
                                        <h1 className="ProductPage_H1Style">{this.state.DownloadedNomenclature.OriginalPrice + ' ₽'}</h1>
                                        <span className="ProductPage_IdSpanStyle">Код: 02641</span>
                                        <div className="ProductPage_InsideRow">
                                            <div className="ProductPage_ClickerBlockStyle">
                                                <Button onClick={this.doDecrease.bind(this)} className="ProductPage_ClickerBlockButtonStyle">-</Button>
                                                <span className="ProductPage_ClickerBlockSpanStyle">{this.state.count}</span>
                                                <Button onClick={this.doIncrease.bind(this)} className="ProductPage_ClickerBlockButtonStyle">+</Button>
                                            </div>
                                            <span className="ProductPage_ClickerBlockSpanStyle2">В наличии: {this.state.DownloadedNomenclature.IsInStock == true ? 'Есть' : 'Отсутствует'}</span>
                                        </div>
                                        <Button className="ProductPage_ButtonStyle" active="true"><div className="ProductPage_ButtonDivStyle"><img src="./Images/trolley.png"></img><span className="ProductPage_SpanStyle">В корзину</span></div></Button>
                                        <Button className="ProductPage_ComparenSaveButtonStyle"><div className="ProductPage_ButtonDivStyle"><img src="./Images/CompareIcon.png"></img><span className="ProductPage_ComparenSaveSpanStyle">Сравнить</span></div></Button>
                                        <Button className="ProductPage_ComparenSaveButtonStyle"><div className="ProductPage_ButtonDivStyle"><img src="./Images/SaveIcon.png"></img><span className="ProductPage_ComparenSaveSpanStyle">Отложить</span></div></Button>
                                        <div className="ProductPage_InsideRow">
                                            <div>
                                                <button className="ProductPage_StarStyle"></button>
                                                <button className="ProductPage_StarStyle"></button>
                                                <button className="ProductPage_StarStyle"></button>
                                                <button className="ProductPage_StarStyle"></button>
                                                <button className="ProductPage_StarStyle"></button>
                                            </div>
                                            <Button>Отправить отзыв</Button>
                                        </div>

                                    </Col>
                                </Row>
                                <Row>
                                    <Tabs defaultActiveKey="home" transition={false} id="noanim-tab-example">
                                        <Tab eventKey="home" title="Характеристики и описание">
                                            {this.state.DownloadedNomenclature.Description}
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
let withRouterProductPage = withRouter(ProductPage);
export default withRouterProductPage;