import React from 'react'
import Card from 'react-bootstrap/Card'
import Button from 'react-bootstrap/Button'
import Badge from 'react-bootstrap/Badge'
import { connect } from "react-redux"
import './ProductCard.css'
import rootStore from "../redux/rootStore"

// import rootStore from "../redux/rootReducer"


//Собственные зависимости

//Расширяет или не расширяет React.Component?
class MiniProductCard extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      Id: props.Id,
      Title: props.Title,
      Description: props.Description,
      OriginalPrice: props.OriginalPrice,
      DiscountedPrice: props.DiscountedPrice,
      ImageUrl: props.ImageUrl,
      IsDiscouted: props.IsDiscouted,
      IsNew: props.IsNew,
      IsPopular: props.IsPopular,
      IsInStock: props.IsInStock,
      Type: props.Type,
      VisualElements: [],
      Style: "",
      ImageStyle: "",
      width: '16rem'
    }
  }
  SetInlineStyle() {
    if (this.props.isInline) {
      this.setState({
        Style: "ProductCard_InlineStyle",
        width: "100%",
        ImageStyle: "ProductCard_ImageStyle"
      }
      );
    }
    else {
      this.setState({
        Style: "",
        ImageStyle: "",
        width: '16rem'
      }
      );
    }
  }

   ReturnSubString(str){
    if(str!=undefined && str.length>=50)
    {return str.substr(0,47)+"..."} 
    return str;
   }


  render() {
    // this.SetInlineStyle()
    let store = rootStore()
    store.subscribe(() => { this.SetInlineStyle() })
    console.log(this.state.Style)
    return (
      <Card style={{ width: this.state.width }} className={this.state.Style}>
        {this.SetInlineStyle.bind(this)}
        <Badge pill variant="primary">
          Есть в наличии
      </Badge>{' '}
        <Card.Img variant="top" src={this.state.ImageUrl} className={this.state.ImageStyle} />
        <Card.Body>
          <Card.Text>
            {this.ReturnSubString(this.state.Title)}
          </Card.Text>
        </Card.Body>
        <Card.Body className="ProductCard_BottomPart">
          <Card.Title>
            {this.state.OriginalPrice + "₽"}
          </Card.Title>
          <Button variant="primary">Купить</Button>
        </Card.Body>

      </Card>

    )
    //рендер
  }

}
function mapStatetoProps(state) {
  return {
    isInline: state.isInline
  }
}

export default connect(mapStatetoProps)(MiniProductCard)