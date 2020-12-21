import React from "react"
import MiniProductCard from "./../ComplexComponents/MiniProductCard"
import "./ProductCardArray.css"
import { Row, Col } from 'bootstrap-4-react'
class ProductCardArray extends React.Component {
  constructor() {
    super();
    // Здесь будут состояния
    this.state = {
      Direction: {},
      array: [ 
      <Col className="ProductCardArray_Col"><MiniProductCard ImageUrl="./Images/Product.jpg" Title="Super Tabletki 1" Price="666"></MiniProductCard></Col> ,
      <Col className="ProductCardArray_Col"><MiniProductCard ImageUrl="./Images/Product1.jpg" Title="Super Tabletki 2" Price="666"></MiniProductCard></Col>,
      <Col className="ProductCardArray_Col"><MiniProductCard ImageUrl="./Images/Product2.jpg" Title="Super Tabletki 3" Price="666"></MiniProductCard></Col>,
      <Col className="ProductCardArray_Col"><MiniProductCard ImageUrl="./Images/Product3.jpg" Title="Super Tabletki 4" Price="666"></MiniProductCard></Col>,
      <Col className="ProductCardArray_Col"><MiniProductCard ImageUrl="./Images/Product.jpg" Title="Super Tabletki 5" Price="666"></MiniProductCard></Col>,
      <Col className="ProductCardArray_Col"><MiniProductCard ImageUrl="./Images/Product1.jpg" Title="Super Tabletki 6" Price="666"></MiniProductCard></Col>,
      <Col className="ProductCardArray_Col"><MiniProductCard ImageUrl="./Images/Product2.jpg" Title="Super Tabletki 7" Price="666"></MiniProductCard></Col>,
      <Col className="ProductCardArray_Col"><MiniProductCard ImageUrl="./Images/Product3.jpg" Title="Super Tabletki 8" Price="666"></MiniProductCard></Col>,
      <Col className="ProductCardArray_Col"><MiniProductCard ImageUrl="./Images/Product.jpg" Title="Super Tabletki 9" Price="666"></MiniProductCard></Col>,
      <Col className="ProductCardArray_Col"><MiniProductCard ImageUrl="./Images/Product1.jpg" Title="Super Tabletki 10" Price="666"></MiniProductCard></Col>,
      <Col className="ProductCardArray_Col"><MiniProductCard ImageUrl="./Images/Product2.jpg" Title="Super Tabletki 11" Price="666"></MiniProductCard></Col>,
      <Col className="ProductCardArray_Col"><MiniProductCard ImageUrl="./Images/Product3.jpg" Title="Super Tabletki 12" Price="666"></MiniProductCard></Col>
      ],
      IsLoading: true,
      Dowloaded:{}
    }
  }
   componentDidMount()
   {
     this.DownloadMiniProductCard();
   }
   async DownloadMiniProductCard(){
     // http://localhost:50258/catalog/product?manufacturerId=1&categoryId=1
     // http://localhost:50258/catalog/product/discounted?promotion=Спец&count=10
     let url = 'https://secrethost.azurewebsites.net/catalog/product/discounted?promotion=Спец&count=10';
     let response = await fetch(url); 
     let json = await response.json();
     this.setState({Dowloaded:json})
  }
  render() {
    return( 
    <div>
     <Row>
      {this.state.array}
     </Row>
    </div>
  
     )
  }



}
//Здесь будет главная функция экспорта 
export default ProductCardArray







