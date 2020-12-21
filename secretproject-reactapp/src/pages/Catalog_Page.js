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
import Dropdown from 'react-bootstrap/Dropdown'
import DropdownItem from 'react-bootstrap/esm/DropdownItem'
import ButtonGroup from 'react-bootstrap/ButtonGroup'
import Pagination from 'react-bootstrap/Pagination'
import PageItem from 'react-bootstrap/PageItem'
import MiniProductCard from "../ComplexComponents/MiniProductCard"
import Form from 'react-bootstrap/Form'
import CheckBoxArray from "./../hoComplexComponents/CheckBoxArray"

class Catalog_Page extends React.Component {
  constructor() {
    super();
    this.state = {
      sortStyle: "Убыванию цены",
      pagActive:1,
      pagItems:[],
      itemsCount:100
    }
    // let link = useParams();
  }
  componentDidMount() {
    this.dowmloadNomenclatures();
  }

  async dowmloadNomenclatures() {
    let url = 'https://secrethost.azurewebsites.net/'
    // + this.state.link;
    // let response = await fetch(url);
    // let json = await response.json();
    // console.log(json);
    this.setState({ Downloaded: [], IsLoading: false });
  }


  GetNewPageInPagination(key){
    if (key!==this.state.pagActive&&key>0&&key<(this.state.itemsCount/15)){
      this.setState({pagActive:key})
      console.log()
            //Тут будет запрос на загрузку новой страницы
    }
  }
  RenderPagination(){
    for (let number = 1; number <= (this.state.itemsCount/15); number++) {
      this.state.pagItems.push(
        <Pagination.Item key={number} activeLabel={()=>this.state.pagActive===number}  onClick={this.GetNewPageInPagination.bind(this,number)}>
          {number}
          {console.log(this.state.pagActive)}
        </Pagination.Item>,
      );
    }

    return(this.state.pagItems)
  }
  render() {

   
    return (
      <div className="mainStyle">
        <Container>
          <Row >
            <Breadcrumb>
              <Breadcrumb.Item href="/">Главная</Breadcrumb.Item>
              <Breadcrumb.Item active>Каталог</Breadcrumb.Item>
            </Breadcrumb>
          </Row>
          <Row>
            <h1 className="Catalog_Page_H1">Гигиена и профилактика</h1>
          </Row>
          <hr />
          <Row className="Catalog_Page_TitleRow">
            <span>Найдено товаров: 50</span>
            <div className="Catalog_Page_TitleRowDiv">
              <span>Сортировать по: </span>
              <DropdownButton as={ButtonGroup} title={this.state.sortStyle} className="Catalog_Page_SortButtonStyle" >
                <DropdownItem eventKey="1" onClick={() => { this.setState({ sortStyle: "Убыванию цены" }) }}>Убыванию цены</DropdownItem>
                <DropdownItem eventKey="2" onClick={() => { this.setState({ sortStyle: "Возрастанию цены" }) }}>Возрастанию цены</DropdownItem>
                <DropdownItem eventKey="3" onClick={() => { this.setState({ sortStyle: "По новинкам" }) }}>По новинкам</DropdownItem>
                <DropdownItem eventKey="4" onClick={() => { this.setState({ sortStyle: "По рейтингу" }) }}>По рейтингу</DropdownItem>
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
                    <Accordion.Toggle as={Card.Header} variant="link" eventKey="0" style={{padding:"12px 12px"}}>
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
                    <Button eventKey="1" style={{backgroundColor:"white"}}><img src="./Images/ListIcon.png" eventKey="1"></img></Button>
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
                    <Button eventKey="1" style={{backgroundColor:"white"}}><img src="./Images/ListIcon.png" eventKey="2"></img></Button>
                    </Row>
      </Accordion.Toggle>
                  </Card.Header>
                  <Accordion.Collapse eventKey="2">
                    <Card.Body>
                      <CheckBoxArray></CheckBoxArray>
                    </Card.Body>
                  </Accordion.Collapse>
                </Card>
                <Card style={{borderTop:"0"}}>
                  <Card.Header>
                    <Button className="Catalog_Page_SideBarBottomButton">
                      <span>Применить фильтры</span>
                    </Button>
                    </Card.Header>
                </Card>
              </Accordion>
            </Col>

            <Col className="Catalog_Page_Content">
              <ProductCardArray></ProductCardArray>
              <Pagination>
              <Pagination.Prev onClick={()=>{
                let number=this.state.pagActive
                this.GetNewPageInPagination(--number)
                }} />
                {this.RenderPagination()}
              <Pagination.Next onClick={()=>{
                let number=this.state.pagActive
                this.GetNewPageInPagination(++number)
                }}/>
              </Pagination>
            </Col>




          </Row>
        </Container>
      </div>
    )
  }

}

function mapDispatchToProps(dispatch) {
  return {
    onSetInline: () => dispatch({ type: "InlineTrue" }),
    onSetBlock: () => dispatch({ type: "InlineFalse" })
  }
}
export default withRouter(connect(null, mapDispatchToProps)(Catalog_Page))