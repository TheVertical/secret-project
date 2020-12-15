import React from "react"
import CartElement from "./../ComplexComponents/CartElement"
import "./ProductCardArray.css"
// import ProductCardArray from './../hoCont/ProductCardArray'
// import image from "./../Images/Product.jpg"
import { Row, Col } from 'bootstrap-4-react'
import { connect } from "react-redux"
import rootStore from "../redux/rootStore"





class CartProductArray extends React.Component {


  constructor(props) {
    super(props);
    // Здесь будут состояния
    this.state = {
      array: [],


    }
  }


  componentWillMount(props){
     let floosh=[...this.state.array]
     floosh.push(<Col className="ProductCardArray_Col"> <CartElement ImageUrl={this.props.ImageUrl} Title={this.props.Title} Price={this.props.Price} Id={this.props.Id} ></CartElement></Col>)
     this.setState({array:floosh})
    // console.log(props.Price)
  
    }


  render() {
    // this.state.array.push(<Col className="ProductCardArray_Col"> <CartElement ImageUrl={this.props.ImageUrl} Title={this.props.Title} Price={this.props.Price} Id={this.props.Id} ></CartElement></Col>)
      //  let floosh=[...this.state.array]
      //  floosh.push(<Col className="ProductCardArray_Col"> <CartElement ImageUrl={this.props.ImageUrl} Title={this.props.Title} Price={this.props.Price} Id={this.props.Id} ></CartElement></Col>)
      //  this.setState({floosh})
    return (
      <div>

        <Row>
          {this.state.array}
        </Row>


      </div>
    )



  }



}
function mapStatetoProps(state) {
  return {
    Price: state.Price,
    Title: state.Title,
    ImageUrl: state.ImageUrl,
    Id: state.Id
  }
}
//Здесь будет главная функция экспорта 
export default connect(mapStatetoProps)(CartProductArray)
