import React from 'react'
import Card from 'react-bootstrap/Card'
import Button from 'react-bootstrap/Button'
import Badge from 'react-bootstrap/Badge'
// import {connect} from "react-redux"
import './CartElement.css'
// import rootStore from "../redux/rootStore"
// import rootStore from "../redux/rootReducer"


//Собственные зависимости

//Расширяет или не расширяет React.Component?
class CartElement extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      Id: props.Id,
      Title: props.Title,
      OriginalPrice: props.OriginalPrice,
      ImageUrl: props.ImageUrl,
      Type: props.Type,
      Amount: props.Amount
    }
  }
  //Функции React

  //Собственные функции класса
  doIncrease() {
    this.setState((state) => {
      return { Amount: state.Amount + 1 }
    });
  }
  doDecrease() {
    this.setState((state) => {
      if (state.Amount > 0)
        return { Amount: state.Amount - 1 }
    });
  }


  render(props) {

    return (
      <div className="CartElement_Global">
        <img src={this.state.ImageUrl} className="Cart_Element_ImageStyle">
        </img>
        <div className="Cart_Element_CenterBlock">
          <h1 className="Cart_Element_H1Style">{this.state.Title}</h1>
          <div className="Cart_Element_InsideCenterBlock">
            <div className="Cart_Element_ClickerBlockStyle">
              <Button onClick={this.doDecrease.bind(this)} className="Cart_Element_ClickerBlockButtonStyle">-</Button>
              <span className="Cart_Element_ClickerBlockSpanStyle">{this.state.Amount}</span>
              <Button onClick={this.doIncrease.bind(this)} className="Cart_Element_ClickerBlockButtonStyle">+</Button>
            </div>
            <div className="Cart_Element_InsideCenterInlineBlock">
              <h1 className="Cart_Element_H1Style">{this.state.OriginalPrice} ₽</h1>
              <span className="Cart_Element_IdSpanStyle">Код:{this.state.Id}</span>
            </div>
          </div>
        </div>
        <Button className="Cart_Element_ButtonStyle">x</Button>
      </div>
    )
  }

}
// function mapStatetoProps(state){
//   return{
//     isInline:state.isInline,
//     width:state.width,
//     ImageStyle:state.ImageStyle,
//     Style:state.Style
//   }
// }

// export default connect(mapStatetoProps)(MiniProductCard)
export default CartElement