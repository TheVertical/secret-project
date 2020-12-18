import React from 'react'
import { Row, Col } from 'bootstrap-4-react'
// import Bootstrap, { Carousel, BImg } from 'bootstrap-4-react';
import { Button, Container } from "react-bootstrap"
import './MainPage.css'
import ".././hoc/LayoutElements/Main.css"
import { NavLink } from 'react-router-dom'
import ProductCardArray from '../hoComplexComponents/ProductCardArray'
import MiniProductCard from "../ComplexComponents/MiniProductCard"
import Slider from "react-slick";
import "slick-carousel/slick/slick.css";
import "slick-carousel/slick/slick-theme.css";
import LoadingPage from './LoadingPage'


class MainPage extends React.Component {
  constructor() {
    super();
    this.state = {
      Downloaded: {},
      IsLoading: true
    }
  }

  componentWillMount() {
    this.downloadedSpecPromotion();
  }

  async downloadedSpecPromotion() {
    let url = 'https://secrethost.azurewebsites.net/catalog/product/discounted?promotion=Спец&count=10'
    let response = await fetch(url);
    let json = await response.json();
    console.log(json);
    this.setState({ Downloaded: json, IsLoading: false });
  }
   
 
   RenderAllMiniCards(settings2){
    if(this.state.IsLoading){
      return(
      // <div className="MainPage_MiniProductCardRowStyle">
      <LoadingPage loading={this.state.IsLoading}></LoadingPage>
      // </div>
      )
    }
    else{
      let minicards = this.state.IsLoading ? [{}] : this.state.Downloaded;
      return(<Slider {...settings2}>
              {minicards.map(minicard => {
                return(
                
                <div className="MainPage_MarginForMiniProductCard" style={{display:"contents"}}>
                   <MiniProductCard
                   style={{display:"contents"}}
                  key={minicard.Id}
                  Title={minicard.Title}
                  OriginalPrice={minicard.OriginalPrice}
                  DiscountedPrice={minicard.DiscountedPrice}
                  //TODO Пока мок
                  ImageUrl="./Images/Product.jpg"
                  IsDiscouted={minicard.IsDiscouted}
                  IsNew={minicard.IsNew}
                  IsPopular={minicard.IsPopular}
                  IsInStock={minicard.IsInStock}
                />
                </div>
                
               );
              })}
      </Slider>)
    }
  }

  render() {

    const settings1 = {
      dots: true,
      infinite: true,
      autoplay: true,
      autoplaySpeed: 9000,
      slidesToShow: 1,
      slidesToScroll: 1,
      className: "MainPage_FirstSlider",
      respondTo: "min"
      // centerMode:true,
      // centerPadding:"10%"
    };
    const settings2 = {
      infinite: true,
      slidesToShow: 4,
      slidesToScroll: 1,
      className: "MainPage_SecondSlider",
      respondTo: "slider",
      dots: true,
      autoplay: true,
      autoplaySpeed: 100000,
      responsive: [
        {
          breakpoint: 1200,
          settings: {
            slidesToShow: 3,
            slidesToScroll: 3,
            infinite: true,
            dots: true
          }
        },
        {
          breakpoint: 800,
          settings: {
            slidesToShow: 2,
            slidesToScroll: 2,
            initialSlide: 2
          }
        },
        {
          breakpoint: 600,
          settings: {
            slidesToShow: 1,
            slidesToScroll: 1
          }
        }
      ]
    };
    // let minicards = this.state.IsLoading ? [{}] : this.state.Downloaded;
 
    return (
      <div className="mainStyle MainPage_Global">
        <Slider {...settings1}>
          <img src="./Images/BannerProduct1.jpg" ></img>
          <img src="./Images/BannerProduct3.jpg" ></img>
        </Slider>
        <Container className="MainPage_GlobalBottom">
          <Row>
            <Col>
            <h1 className="MainPage_h1Style">Специальные предложения!</h1>
            </Col>
          </Row>

          <Row className="MainPage_MiniProductCardRowStyle">
          
          {this.RenderAllMiniCards(settings2)}
          
          
          </Row>
          {/* <Row>
            <h1 className="MainPage_h1Style">Хиты продаж:</h1>
          </Row> */}
          {/* <Row>
            <ProductCardArray></ProductCardArray>
          </Row> */}
          <Row className="MainPage_LinkButtonStyle">
            <NavLink to="/Catalog">
              <Button className="MainPage_ToCatalogButtonStyle">Перейти к каталогу</Button>
            </NavLink>
          </Row>
          <Container className="MainPage_BottomPartStyle">
             <Row>
              <div className="MainPage_InfoBlockStyle">
                <h1>2011</h1>
                <span>Год основания компании</span>
              </div>
              <div className="MainPage_InfoBlockStyle">
                <h1>3000</h1>
                <span>Год основания компании</span>
              </div>
              <div className="MainPage_InfoBlockStyle">
                <h1>72%</h1>
                <span>Клиентов совершают повторные покупки в нашем магазине</span>
              </div>
              <div className="MainPage_InfoBlockStyle">
                <h1>Курсы</h1>
                <span>Мы организовываем профессиональные курсы для стоматологов</span>
              </div>
              <div className="MainPage_InfoBlockStyle">
                <h1>25000</h1>
                <span>Довольных клиентов</span>
              </div>
            </Row> 
             <Row>
              <Col>
                <img src="./Images/dentist.jpg"></img>
              </Col>
              <Col className="MainPage_BottomPartStyleTextBlock">
                <p>
                  Мы действительно работаем для вас!
                </p>
                <p>
                  И это не просто слова!
                </p>
                <p>Компания "Олимп-Дентал" предлагает широкий спектр расходных материалов, инструментов,дезинфакторов, стоматологического оборудования, мебели и стоматологических установок ведущих производителей.</p>
                <p>Многолетний опыт нашей работы, высокая квалификация и доброжелательность продавцов-консультантов помогут Вам определиться с выбором и получить ответы на интересующие Вас вопросы.</p>
                <NavLink to="/second">
                  <Button>узнать больше...</Button>
                </NavLink>
              </Col>
            </Row> 
          </Container>
        </Container>
      </div>
    )
  }
}
export default MainPage