import React from 'react'
// import img_src from '../Images/Product.jpg'
import './Catalog_Page.css'
import ProductCardArray from "./../hoComplexComponents/ProductCardArray"
// import ProductCardArray from './../hoCont/ProductCardArray'
// import image from "./../Images/Product.jpg"

class Catalog_Page extends React.Component {



  constructor() {
    super();
    this.state={}
    }
  

  
  render(){
    return(
      <div className="Catalog_Page_Global">   
           <ProductCardArray></ProductCardArray>
      </div>
    )
  }

}
export default Catalog_Page