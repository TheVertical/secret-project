import React from "react"
import MiniProductCard from "./../ComplexComponents/MiniProductCard"
import "./ProductCardArray.css"
import { Row, Col } from 'bootstrap-4-react'
import { MakeServerQuery } from '../Services/ServerQuery'
import LoadingPage from '../pages/LoadingPage';

class ProductCardArray extends React.Component {
  constructor(props) {
    super(props);
    // Здесь будут состояния
    this.state = {
      Direction: {},
      array: [],
      IsLoading: true,
      DownloadedNomenclatures:[],
      Dowloaded:{}
    }
  }
   componentDidMount()
   {
     this.downloadNomenclatures()
   }
   async downloadNomenclatures() {
    let responce = await MakeServerQuery('GET', "/catalog/product?categoryId="+this.props.Id);
    if (responce && responce.success) {
      this.setState({ DownloadedNomenclatures: responce.data});
    }
    this.SetProductCardArray()
    this.setState({IsLoading:false})
     }
    //Метод-установщик полученнных данных в карточку
    SetProductCardArray(){
      this.state.DownloadedNomenclatures.map((item)=>{
      this.state.array.push(<Col className="ProductCardArray_Col"><MiniProductCard 
      Id={item.Id} 
      ImageUrl={'./Images/Product1.jpg'} 
      Title={item.Title} 
      OriginalPrice={item.OriginalPrice}
      Description={item.Description}
      IsDiscouted={item.IsDiscouted}
      IsInStock={item.IsInStock}
      IsNew={item.IsNew}
      IsPopular={item.IsPopular}
      ></MiniProductCard></Col>)
    })
    }
   
  render() {
    if (this.state.IsLoading) {
      return (<div className="Layout_FullContentStyle"><LoadingPage loading={this.state.IsLoading}></LoadingPage></div>)
     }
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







