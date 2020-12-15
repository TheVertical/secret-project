import React from "react"
import MiniProductCard from "./../ComplexComponents/MiniProductCard"
import "./ProductCardArray.css"
// import ProductCardArray from './../hoCont/ProductCardArray'
// import image from "./../Images/Product.jpg"
import { Row, Col } from 'bootstrap-4-react'





class ProductCardArray extends React.Component {


  constructor() {
    super();
    // Здесь будут состояния
    this.state = {
      array: [ 
      <Col className="ProductCardArray_Col"> <MiniProductCard ImageUrl="./Images/Product.jpg" Title="Super Tabletki1" Price="100"></MiniProductCard></Col> ,
      <Col className="ProductCardArray_Col"> <MiniProductCard ImageUrl="./Images/Product.jpg" Title="Super Tabletki2" Price="200"></MiniProductCard></Col>,
      <Col className="ProductCardArray_Col"> <MiniProductCard ImageUrl="./Images/Product.jpg" Title="Super Tabletki3" Price="300"></MiniProductCard></Col>,
      <Col className="ProductCardArray_Col"> <MiniProductCard ImageUrl="./Images/Product.jpg" Title="Super Tabletki4" Price="400"></MiniProductCard></Col>,
      <Col className="ProductCardArray_Col"> <MiniProductCard ImageUrl="./Images/Product.jpg" Title="Super Tabletki5" Price="500"></MiniProductCard></Col>,
      <Col className="ProductCardArray_Col"> <MiniProductCard ImageUrl="./Images/Product.jpg" Title="Super Tabletki6" Price="600"></MiniProductCard></Col>,
      <Col className="ProductCardArray_Col"> <MiniProductCard ImageUrl="./Images/Product.jpg" Title="Super Tabletki7" Price="700"></MiniProductCard></Col>,
      <Col className="ProductCardArray_Col"> <MiniProductCard ImageUrl="./Images/Product.jpg" Title="Super Tabletki8" Price="800"></MiniProductCard></Col>,
      <Col className="ProductCardArray_Col"> <MiniProductCard ImageUrl="./Images/Product.jpg" Title="Super Tabletki9" Price="900"></MiniProductCard></Col>,
      <Col className="ProductCardArray_Col"> <MiniProductCard ImageUrl="./Images/Product.jpg" Title="Super Tabletki11" Price="350"></MiniProductCard></Col>,
      <Col className="ProductCardArray_Col"> <MiniProductCard ImageUrl="./Images/Product.jpg" Title="Super Tabletki22" Price="450"></MiniProductCard></Col>,
      <Col className="ProductCardArray_Col"> <MiniProductCard ImageUrl="./Images/Product.jpg" Title="Super Tabletki33" Price="550"></MiniProductCard></Col>
    
      ],
      
   
    }
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







