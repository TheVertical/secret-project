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
import { MakeServerQuery } from '../Services/ServerQuery'
import LoadingPage from '../pages/LoadingPage';
import { MakeSimpleServerQuery } from '../Services/ServerQuery'



class ProductPage extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            Id: props.match.params.id,
            count: 1,
            Nomenclature: undefined,
            IsLoading: true,
        }
        this.addNomenclatureToCart = this.AddNomenclatureToCart.bind(this);

    }

    componentDidMount() {
        if (this.state.Id != undefined)
            this.LoadNomenclature(this.state.Id);
        else
            this.state.history.push('/404');
    }
    async AddNomenclatureToCart() {
        let query = '/cart/add?nomenclatureId=' + this.state.Id + '&' + 'count='+ this.state.count;
        let responce = await MakeSimpleServerQuery('POST', query);
        if (responce != undefined && responce.success) {
            console.debug('Nomenclature with id ' + this.state.Id + ' was success added!');
        }
        else
            alert('Error. Something was happend.\n Nomenclature with id ' + this.state.Id + ' was not added!');
    }
    async LoadNomenclature(id) {
        let responce = await MakeServerQuery('GET', "/catalog/product/" + id);
        if (responce && responce.success) {
            this.setState({ Nomenclature: responce.data, IsLoading: false });
        }
    }

    doIncrease() {
        this.setState((state) => {
            return { count: state.count + 1 }
        });
    }
    doDecrease() {
        this.setState((state) => {
            if (state.count > 1)
                return { count: state.count - 1 }
        });
    }
    render() {
        if (this.state.IsLoading)
            return <LoadingPage />;
        else {
            return (
                <div className="mainStyle">
                    <div>
                        <Container>
                            <Row>
                                <Breadcrumb>
                                    <Breadcrumb.Item as={NavLink} to="/">Home</Breadcrumb.Item>
                                    <Breadcrumb.Item as={NavLink} to="https://getbootstrap.com/docs/4.0/components/breadcrumb/">
                                        Каталог
                                 </Breadcrumb.Item>
                                    <Breadcrumb.Item active>Data</Breadcrumb.Item>
                                </Breadcrumb>
                            </Row>
                            <Row>
                                <h1 className="ProductPage_TitleH1Style">{this.state.Nomenclature.Title}</h1>
                            </Row>
                            <Container className="ProductPage_Global">
                                <Row className="ProductPage_OrderBlockStyle">
                                    <Col>
                                        <img src={this.state.Nomenclature.ImageUrl} className="ProductPage_ImageStyle"></img>
                                        <span>Производитель:<NavLink to={{ pathname: "/catalog", props: 'catalog/product?manufacturerId=2' }}>
                                            {this.state.Nomenclature.Manufacturer.Name ?? "error"}
                                        </NavLink></span>
                                    </Col>
                                    <Col xs lg="4">
                                        <h1 className="ProductPage_H1Style">{this.state.Nomenclature.OriginalPrice + ' ₽'}</h1>
                                        <span className="ProductPage_IdSpanStyle">Код: 02641</span>
                                        <div className="ProductPage_InsideRow">
                                            <div className="ProductPage_ClickerBlockStyle">
                                                <Button variant="link" onClick={this.doDecrease.bind(this)} className="ProductPage_ClickerBlockButtonStyle">-</Button>
                                                <span className="ProductPage_ClickerBlockSpanStyle">{this.state.count}</span>
                                                <Button variant="link" onClick={this.doIncrease.bind(this)} className="ProductPage_ClickerBlockButtonStyle">+</Button>
                                            </div>
                                            <span className="ProductPage_ClickerBlockSpanStyle2">В наличии: {this.state.Nomenclature.IsInStock == true ? 'Есть' : 'Отсутствует'}</span>
                                        </div>
                                        <Button onClick={this.addNomenclatureToCart} className="ProductPage_ButtonStyle" active="true">
                                            <div className="ProductPage_ButtonDivBasketStyle">
                                                <img src="./Images/trolley.png"></img>
                                                <span className="ProductPage_SpanStyle">В корзину</span>
                                            </div>
                                        </Button>
                                        <Button variant="link" className="ProductPage_ComparenSaveButtonStyle">
                                            <div className="ProductPage_ButtonDivComareNSaveStyle">
                                                <img src="./Images/CompareIcon.png"></img>
                                                <span className="ProductPage_ComparenSaveSpanStyle">Сравнить</span>
                                            </div>
                                        </Button>
                                        <Button variant="link" className="ProductPage_ComparenSaveButtonStyle">
                                            <div className="ProductPage_ButtonDivComareNSaveStyle">
                                                <img src="./Images/SaveIcon.png"></img>
                                                <span className="ProductPage_ComparenSaveSpanStyle">Отложить</span>
                                            </div>
                                        </Button>
                                        <div className="ProductPage_InsideRow">
                                        <div class="rating-area">
	<input type="radio" id="star-5" name="rating" value="5"/>
	<label for="star-5" title="Оценка «5»"></label>	
	<input type="radio" id="star-4" name="rating" value="4"/>
	<label for="star-4" title="Оценка «4»"></label>    
	<input type="radio" id="star-3" name="rating" value="3"/>
	<label for="star-3" title="Оценка «3»"></label>  
	<input type="radio" id="star-2" name="rating" value="2"/>
	<label for="star-2" title="Оценка «2»"></label>    
	<input type="radio" id="star-1" name="rating" value="1"/>
	<label for="star-1" title="Оценка «1»"></label>
</div>
                                            <Button className="ProductPage_ButtonSendReviewStyle">Отправить отзыв</Button>
                                        </div>

                                    </Col>
                                </Row>
                                <Row>
                                    <Tabs defaultActiveKey="home" transition={false} id="noanim-tab-example">
                                        <Tab eventKey="home" title="Характеристики и описание">
                                            {this.state.Nomenclature.Description}
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

}
let withRouterProductPage = withRouter(ProductPage);
export default withRouterProductPage;