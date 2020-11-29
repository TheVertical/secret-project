import React from 'react'
import img_src from '../Images/Product.jpg'
import './Catalog_Gigiena_I_Profilaktika.css'
import ProductCard from "./../containers/ProductCard"
import ProductCardArray from './../hoCont/ProductCardArray'

class Catalog_Gigiena_I_Profilaktika extends React.Component{



constructor(){
  super();
  this.state={
    // img_src:'../Images/Product.jpg',
    // link:"#",
    // price:"3600",
    // title:"Opallis KIT - набор: 6 шприцев(5*4 г EA2/EA3/EA3.5/DA2/DA3+1 шприц*2г) + бонд (FGM)"
    array : [],
    loading: true
  }
}

componentWillMount(){
    this.populateWeatherData();
}
async populateWeatherData() {
    let url = 'https://secrethost.azurewebsites.net/Catalog'
    const response = await fetch(url);
    const data = await response.json();
    console.log(data);
    this.setState({array:data,loading: false});
  }

renderProductCardArray(elements){
    console.log(elements);
    return(
        <div>
        {elements.map(product =>
            // <ProductCard src = {product.ImageUrl} title = {product.Title} price = {product.Price}></ProductCard>
            <div>{product.Title}</div>
            )}
            </div>
    )
}
render(){
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
    //   : console.log(this.state.array)
        :  Catalog_Gigiena_I_Profilaktika.renderProductCardArray(this.state.array);

      console.log(this.state.loading)
  return(
        <div>{contents}</div>
      )
}



}
export default Catalog_Gigiena_I_Profilaktika