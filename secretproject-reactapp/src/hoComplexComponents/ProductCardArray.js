import React from "react"
import ProductCard from "./../ComplexComponents/ProductCard"
import "./ProductCardArray.css"
// import ProductCardArray from './../hoCont/ProductCardArray'
// import image from "./../Images/Product.jpg"





class ProductCardArray extends React.Component {


  constructor() {
    super();
    // Здесь будут состояния
    this.state = {
      array: [],
      loading: true
    }
  }

  componentDidMount() {
    this.populateWeatherData();
  }
  
  async populateWeatherData() {
    let url = 'https://secrethost.azurewebsites.net/Catalog'
    const response = await fetch(url);
    let json = await response.json();

    this.setState({ array: json, loading: false });
  }

  static renderProductCardArray(elements) {
    return (
      ProductCardArray.re(elements)
    )
  }

  static re(elements){
    return(
      <div className="ProductCardArray_Global">
        {elements.map(product =>
          
          <ProductCard src={product.ImageUrl} title={product.Title} price={product.Price}></ProductCard>
        )}
      </div>
    );
  }
  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : ProductCardArray.renderProductCardArray(this.state.array);

    console.log(contents)
    return (
      <div>
        {contents}
      </div>
    )
  }



}
//Здесь будет главная функция экспорта 
export default ProductCardArray







