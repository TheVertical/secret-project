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
      <Col className="ProductCardArray_Col"> <MiniProductCard ImageUrl="./Images/Product.jpg" Title="Super Tabletki" Price="666"></MiniProductCard></Col> ,
      <Col className="ProductCardArray_Col"> <MiniProductCard ImageUrl="./Images/Product.jpg" Title="Super Tabletki" Price="666"></MiniProductCard></Col>,
      <Col className="ProductCardArray_Col"> <MiniProductCard ImageUrl="./Images/Product.jpg" Title="Super Tabletki" Price="666"></MiniProductCard></Col>,
      <Col className="ProductCardArray_Col"> <MiniProductCard ImageUrl="./Images/Product.jpg" Title="Super Tabletki" Price="666"></MiniProductCard></Col>,
      <Col className="ProductCardArray_Col"> <MiniProductCard ImageUrl="./Images/Product.jpg" Title="Super Tabletki" Price="666"></MiniProductCard></Col>,
      <Col className="ProductCardArray_Col"> <MiniProductCard ImageUrl="./Images/Product.jpg" Title="Super Tabletki" Price="666"></MiniProductCard></Col>,
      <Col className="ProductCardArray_Col"> <MiniProductCard ImageUrl="./Images/Product.jpg" Title="Super Tabletki" Price="666"></MiniProductCard></Col>,
      <Col className="ProductCardArray_Col"> <MiniProductCard ImageUrl="./Images/Product.jpg" Title="Super Tabletki" Price="666"></MiniProductCard></Col>,
      <Col className="ProductCardArray_Col"> <MiniProductCard ImageUrl="./Images/Product.jpg" Title="Super Tabletki" Price="666"></MiniProductCard></Col>,
      <Col className="ProductCardArray_Col"> <MiniProductCard ImageUrl="./Images/Product.jpg" Title="Super Tabletki" Price="666"></MiniProductCard></Col>,
      <Col className="ProductCardArray_Col"> <MiniProductCard ImageUrl="./Images/Product.jpg" Title="Super Tabletki" Price="666"></MiniProductCard></Col>,
      <Col className="ProductCardArray_Col"> <MiniProductCard ImageUrl="./Images/Product.jpg" Title="Super Tabletki" Price="666"></MiniProductCard></Col>
      //   <MiniProductCard ImageUrl="./Images/Product.jpg" Title="Super Tabletki" Price="666"></MiniProductCard>,
      //   <MiniProductCard ImageUrl="./Images/Product.jpg" Title="Super Tabletki" Price="666"></MiniProductCard>,
      //   <MiniProductCard ImageUrl="./Images/Product.jpg" Title="Super Tabletki" Price="666"></MiniProductCard>,
      //   <MiniProductCard ImageUrl="./Images/Product.jpg" Title="Super Tabletki" Price="666"></MiniProductCard>,
      //   <MiniProductCard ImageUrl="./Images/Product.jpg" Title="Super Tabletki" Price="666"></MiniProductCard>,
      //   <MiniProductCard ImageUrl="./Images/Product.jpg" Title="Super Tabletki" Price="666"></MiniProductCard>, 
      //   <MiniProductCard ImageUrl="./Images/Product.jpg" Title="Super Tabletki" Price="666"></MiniProductCard>,
      //   <MiniProductCard ImageUrl="./Images/Product.jpg" Title="Super Tabletki" Price="666"></MiniProductCard>,
      //   <MiniProductCard ImageUrl="./Images/Product.jpg" Title="Super Tabletki" Price="666"></MiniProductCard>,
      //   <MiniProductCard ImageUrl="./Images/Product.jpg" Title="Super Tabletki" Price="666"></MiniProductCard>,
      //   <MiniProductCard ImageUrl="./Images/Product.jpg" Title="Super Tabletki" Price="666"></MiniProductCard>,
      //   <MiniProductCard ImageUrl="./Images/Product.jpg" Title="Super Tabletki" Price="666"></MiniProductCard>
      ],
    }
  }

  // componentDidMount() {
  //   this.populateWeatherData();
  // }
  
  // async populateWeatherData() {
  //   let url = 'https://secrethost.azurewebsites.net/Catalog'
  //   const response = await fetch(url);
  //   let json = await response.json();

  //   this.setState({ array: json, loading: false });
  // }

  // static renderProductCardArray(elements) {
  //   return (
  //     ProductCardArray.re(elements)
  //   )
  // }

  // static re(elements){
  //   return(
  //     <div className="ProductCardArray_Global">
  //       {elements.map(product =>
          
  //         <ProductCard src={product.ImageUrl} title={product.Title} price={product.Price}></ProductCard>
  //       )}
  //     </div>
  //   );
  // }

   

  render() {
    // let contents = this.state.loading
    //   ? <p><em>Loading...</em></p>
    //   : ProductCardArray.renderProductCardArray(this.state.array);

    // console.log(contents)
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







