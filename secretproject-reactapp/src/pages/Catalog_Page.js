// import img_src from '../Images/Product.jpg'
import './Catalog_Page.css'
import ProductCardArray from "./../hoComplexComponents/ProductCardArray"
import React from 'react'
import { Row, Col } from 'bootstrap-4-react'
import { Button, Container } from "react-bootstrap"
import './ProductPage.css'
import ".././hoc/LayoutElements/Main.css"
import { NavLink, Route, useParams, withRouter } from 'react-router-dom'
import { connect } from "react-redux"
import Breadcrumb from 'react-bootstrap/Breadcrumb'
import Accordion from 'react-bootstrap/Accordion'
import Card from 'react-bootstrap/Card'
import DropdownButton from 'react-bootstrap/DropdownButton'
import DropdownItem from 'react-bootstrap/esm/DropdownItem'
import ButtonGroup from 'react-bootstrap/ButtonGroup'
import Pagination from 'react-bootstrap/Pagination'
import Form from 'react-bootstrap/Form'
import CheckBoxArray from "./../hoComplexComponents/CheckBoxArray"
//Вспомогательные функции
import { MakeServerQuery } from '../Services/ServerQuery'
import LoadingPage from '../pages/LoadingPage';
import MiniProductCard from "./../ComplexComponents/MiniProductCard"


class Catalog_Page extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      location: props.location,
      Id: Number(props.match.params.id),
      NomenclatureGroup: undefined,
      NomenclatureResult: undefined,
      sortStyle: "Убыванию цены",
      pagActive: 1,
      pagItems: [],
      itemsCount: 100,
      IsLoading: false,
      Query: this.props.location.transmittedData,
      callBackCard: undefined
    }
    this.onRouteChanged = this.OnRouteChanged.bind(this);

  }
  OnRouteChanged(location) {
    if (location.state && location.state.Id != undefined) {
      let id = location.state.Id;
      this.getNomenclatureGroup(id);
      this.getNomenclatures(id);
    }
  }
  componentDidMount() {
    this.unlisten = this.props.history.listen((location, action) => {
      this.onRouteChanged(location);
    });
    if (this.state.Id != undefined) {
      let id = this.state.Id;
      this.getNomenclatureGroup(id);
      this.getNomenclatures(id);
    }
  }
  componentWillUnmount(){
    this.unlisten();
  }
  async getNomenclatureGroup(id) {
    let responce = await MakeServerQuery('GET', "/catalog/categories/" + id);
    if (responce && responce.success) {
      this.setState({ NomenclatureGroup: responce.data });
    }
    else {
      this.setState({ NomenclatureGroup: undefined });
    }
  }
  async getNomenclatures(id) {
    let filter = {
      categoryId: id,
      count: 15
    };
    let query = this.buildQuery(filter);
    let responce = await MakeServerQuery('GET', query);
    if (responce && responce.success) {
      this.setState({ NomenclatureResult: responce.data, itemsCount: responce.data.TotalFound });
    }
  }
  GetNewPageInPagination(key) {
    if (key !== this.state.pagActive && key > 0 && key < (this.state.itemsCount / 15)) {
      this.setState({ pagActive: key })
    }
  }
  RenderPagination() {
    for (let number = 1; number <= (this.state.itemsCount / 15); number++) {
      this.state.pagItems.push(
        <Pagination.Item key={number} activeLabel={() => this.state.pagActive === number} onClick={this.GetNewPageInPagination.bind(this, number)}>
          {number}
        </Pagination.Item>,
      );
    }

    return (this.state.pagItems)
  }
  buildQuery(filter) {
    let query = "/catalog/product?";
    query += "needTotalCount=true" + "&";
    if (filter.manufacturerId != undefined && isInteger(filter.manufacturerId))
      query += "manufacturerId=" + filter.manufacturerId + "&";
    if (filter.categoryId != undefined && isInteger(filter.categoryId))
      query += "categoryId=" + filter.categoryId + "&";
    if (filter.count != undefined && isInteger(filter.count))
      query += "count=" + filter.count + "&";
    if (filter.from != undefined && isInteger(filter.from))
      query += "from=" + filter.from + "&";
    if (filter.minValue && isInteger(filter.minValue))
      query += "minValue=" + filter.minValue + "&";
    if (filter.maxValue && isInteger(filter.maxValue))
      query += "maxValue=" + filter.maxValue + "&";
    if (query.endsWith("&"))
      query = query.slice(0, query.length - 1);
    return query;
  }

  UpdateCardArray(NomenclatureCollection) {
    let ar = undefined;
    if (NomenclatureCollection && NomenclatureCollection.length > 0)
      ar = NomenclatureCollection.map((item) =>
        <Col key={item.Id} className="ProductCardArray_Col">
          <MiniProductCard
            key={item.Id}
            Id={item.Id}
            ImageUrl={item.ImageUrl}
            Title={item.Title}
            OriginalPrice={item.OriginalPrice}
            Description={item.Description}
            IsDiscouted={item.IsDiscouted}
            IsInStock={item.IsInStock}
            IsNew={item.IsNew}
            IsPopular={item.IsPopular} />
        </Col>
      );
    return ar;
  }
  render() {
    let nomenclatureGroup = this.state.NomenclatureGroup == undefined ? <LoadingPage></LoadingPage> : this.state.NomenclatureGroup;
    let nomenclatureResult = this.state.NomenclatureResult == undefined ? <LoadingPage></LoadingPage> : this.state.NomenclatureResult;
    if (this.state.NomenclatureGroup == undefined || this.state.NomenclatureResult == undefined)
      return (<LoadingPage loading={this.state.IsLoading}></LoadingPage>);
    else
      return (
        <div className="mainStyle">
          <Container>
            <Row>
              <Breadcrumb>
                <Breadcrumb.Item href="/">Главная</Breadcrumb.Item>
                <Breadcrumb.Item active>Каталог</Breadcrumb.Item>
              </Breadcrumb>
            </Row>
            <Row>
              <h1 className="Catalog_Page_H1">{(nomenclatureGroup.Name)}</h1>
            </Row>
            <hr />
            <Row className="Catalog_Page_TitleRow">
              <span>Найдено товаров: {nomenclatureResult.TotalFound}</span>
              <div className="Catalog_Page_TitleRowDiv">
                <span>Сортировать по: </span>
                <DropdownButton as={ButtonGroup} title={this.state.sortStyle} className="Catalog_Page_SortButtonStyle" >
                  <DropdownItem onClick={() => { this.setState({ sortStyle: "Убыванию цены" }) }}>Убыванию цены</DropdownItem>
                  <DropdownItem onClick={() => { this.setState({ sortStyle: "Возрастанию цены" }) }}>Возрастанию цены</DropdownItem>
                  <DropdownItem onClick={() => { this.setState({ sortStyle: "По новинкам" }) }}>По новинкам</DropdownItem>
                  <DropdownItem onClick={() => { this.setState({ sortStyle: "По рейтингу" }) }}>По рейтингу</DropdownItem>
                </DropdownButton>
                <div className="Catalog_Page_SVG_SpisokStyle"></div>
                <div></div>
                <button onClick={this.props.onSetInline}>Inline</button>
                <button onClick={this.props.onSetBlock}>Block</button>
              </div>
            </Row>
            <Row>
              <Col col="3">
                <Accordion className="Catalog_Page_AccordionStyle">
                  <Card>
                    <Card.Header>
                      <Accordion.Toggle as={Card.Header} variant="link" eventKey="0" style={{ padding: "12px 12px" }}>
                        <Form>
                          <span className="Catalog_Page_SidebarSpanStyle">Цена</span>
                          <Row className="Catalog_Page_SidebarInputRowStyle">
                            <div>
                              <Form.Control placeholder="от 0Р:" className="Catalog_Page_InputStyle" />
                            </div>
                            <div>
                              <Form.Control placeholder="до 179000Р" className="Catalog_Page_InputStyle" />
                            </div>
                          </Row>
                        </Form>
                      </Accordion.Toggle>
                    </Card.Header>
                  </Card>
                  <Card>
                    <Card.Header>
                      <Accordion.Toggle as={Card.Header} variant="link" eventKey="1">
                        <Row className="Catalog_Page_SidebarInputRowStyle">
                          <span className="Catalog_Page_SidebarSpanStyle">Бренды</span>
                          <Button eventKey="1" style={{ backgroundColor: "white" }}><img src="./Images/ListIcon.png" eventKey="1"></img></Button>
                        </Row>
                      </Accordion.Toggle>
                    </Card.Header>
                    <Accordion.Collapse eventKey="1">
                      <Card.Body>
                        <CheckBoxArray></CheckBoxArray>
                      </Card.Body>
                    </Accordion.Collapse>
                  </Card>
                  <Card>
                    <Card.Header>
                      <Accordion.Toggle as={Card.Header} variant="link" eventKey="2">
                        <Row className="Catalog_Page_SidebarInputRowStyle">
                          <span className="Catalog_Page_SidebarSpanStyle">В наличии</span>
                          <Button eventKey="1" style={{ backgroundColor: "white" }}><img src="./Images/ListIcon.png" eventKey="2"></img></Button>
                        </Row>
                      </Accordion.Toggle>
                    </Card.Header>
                    <Accordion.Collapse eventKey="2">
                      <Card.Body>
                        <CheckBoxArray></CheckBoxArray>
                      </Card.Body>
                    </Accordion.Collapse>
                  </Card>
                  <Card style={{ borderTop: "0" }}>
                    <Card.Header>
                      <Button className="Catalog_Page_SideBarBottomButton">
                        <span>Применить фильтры</span>
                      </Button>
                    </Card.Header>
                  </Card>
                </Accordion>
              </Col>

              <Col className="Catalog_Page_Content">
                <Row>
                  {this.UpdateCardArray(this.state.NomenclatureResult.Nomenclatures)}
                </Row>
                < Pagination >
                  <Pagination.Prev onClick={() => {
                    let number = this.state.pagActive
                    this.GetNewPageInPagination(--number)
                  }} />
                  {this.RenderPagination()}
                  <Pagination.Next onClick={() => {
                    let number = this.state.pagActive
                    this.GetNewPageInPagination(++number)
                  }} />
                </Pagination>
              </Col>
            </Row>
          </Container>
        </div >
      )
  }

}

function isInteger(num) {
  return (num ^ 0) === num;
}

function mapDispatchToProps(dispatch) {
  return {
    onSetInline: () => dispatch({ type: "InlineTrue" }),
    onSetBlock: () => dispatch({ type: "InlineFalse" })
  }
}
export default withRouter(connect(null, mapDispatchToProps)(Catalog_Page))