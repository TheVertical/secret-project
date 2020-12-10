import React from 'react'
import { Row, Col, Container } from 'bootstrap-4-react'
// import Bootstrap, { Carousel, BImg } from 'bootstrap-4-react';
import { Button} from "react-bootstrap"
import './MainPage.css'
import ".././hoc/LayoutElements/Main.css"
import { NavLink } from 'react-router-dom'
import ProductCardArray from '../hoComplexComponents/ProductCardArray'
import MiniProductCard from "../ComplexComponents/MiniProductCard"
import Slider from "react-slick";
import "slick-carousel/slick/slick.css";
import "slick-carousel/slick/slick-theme.css";

class MainPage extends React.Component {

  constructor() {
    super();
    this.state = {}
  }






  render() {

    const settings1 = {
      dots: true,
      infinite: true,
      autoplay: true,
      autoplaySpeed: 2000,
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
      autoplaySpeed: 3000,
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

    return (
      <div className="mainStyle MainPage_Global">


        <Slider {...settings1}>

          <img src="./Images/BannerProduct1.jpg" ></img>


          <img src="./Images/BannerProduct3.jpg" ></img>



        </Slider>



        <Container className="MainPage_GlobalBottom">
          <Row>
            <h1 className="MainPage_h1Style">Специальные предложения!</h1>
          </Row>
          <Row>
            <Slider {...settings2}>
              <MiniProductCard ImageUrl="./Images/Product.jpg" Title="Super Tabletki" Price="666"></MiniProductCard>
              <MiniProductCard ImageUrl="./Images/Product.jpg" Title="Super Tabletki" Price="666"></MiniProductCard>
              <MiniProductCard ImageUrl="./Images/Product.jpg" Title="Super Tabletki" Price="666"></MiniProductCard>
              <MiniProductCard ImageUrl="./Images/Product.jpg" Title="Super Tabletki" Price="666"></MiniProductCard>
              <MiniProductCard ImageUrl="./Images/Product.jpg" Title="Super Tabletki" Price="666"></MiniProductCard>
              <MiniProductCard ImageUrl="./Images/Product.jpg" Title="Super Tabletki" Price="666"></MiniProductCard>
            </Slider>
          </Row>
          <Row>
            <h1 className="MainPage_h1Style">Хиты продаж:</h1>
          </Row>
           <Row>
           <ProductCardArray></ProductCardArray>
           </Row>
            <Row className="MainPage_LinkButtonStyle">
              <NavLink to="/second">
              <Button>перейти к каталогу</Button>
              </NavLink>
            </Row>
            <Container className="MainPage_BottomPartStyle">
              <Row>
                <Col>
                <h1>2011</h1>
                <span>Год основания компании</span>
                </Col>
                <Col>
                <h1>3000</h1>
                <span>Год основания компании</span>
                </Col> 
                <Col>
                 <h1>72%</h1>          
                 <span>Клиентов совершают повторные покупки в нашем магазине</span>
                </Col>
                <Col>
                 <h1>Курсы</h1>
                 <span>Мы организовываем профессиональные курсы для стоматологов</span>
                </Col>
                <Col>
                <h1>25000</h1>
                <span>Довольных клиентов</span>
                </Col>
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