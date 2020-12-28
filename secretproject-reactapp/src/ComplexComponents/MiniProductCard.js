import React from 'react'
import Card from 'react-bootstrap/Card'
import Button from 'react-bootstrap/Button'
import Badge from 'react-bootstrap/Badge'
import { connect } from "react-redux"
import './ProductCard.css'
import rootStore from "../redux/rootStore"
import { withRouter } from 'react-router-dom'
import { MakeSimpleServerQuery } from '../Services/ServerQuery'

// import rootStore from "../redux/rootReducer"


//Собственные зависимости

//Расширяет или не расширяет React.Component?
class MiniProductCard extends React.Component {
  constructor(props) {
    super(props);
    if (props.Id == undefined) {
      console.error("Id of minicard is:", props.Id);
    }
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
      width: '16rem',

      history: props.history

    }
    this.onClick_MiniCard = this.OnClick_MiniCard.bind(this);
    this.setInlineStyle = this.SetInlineStyle.bind(this);
    this.returnSubString = this.ReturnSubString.bind(this);

    this.addNomenclatureToCart = this.AddNomenclatureToCart.bind(this);
  }
  async AddNomenclatureToCart() {
    let query = '/cart/add?nomenclatureId=' + this.state.Id + '&' + 'count=1';
    let responce = await MakeSimpleServerQuery('POST', query);
    if (responce != undefined && responce.success) {
      console.debug('Nomenclature with id ' + this.state.Id + ' was success added!');
    }
    else
      alert('Error. Something was happend.\n Nomenclature with id ' + this.state.Id + ' was not added!');
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

  ReturnSubString(str) {
    if (str != undefined && str.length >= 50) { return str.substr(0, 47) + "..." }
    return str;
  }
  render() {
    let store = rootStore()
    store.subscribe(() => { this.SetInlineStyle() })
    return (
      <Card style={{ width: this.state.width, margin: "20px 0" }} className={this.state.Style}>
        {/* {this.SetInlineStyle()} */}
        <Badge pill variant="primary">
          Есть в наличии
      </Badge>{' '}
        <Card.Img onClick={this.onClick_MiniCard} variant="top" src={this.state.ImageUrl} className={this.state.ImageStyle} />
        <Card.Body>
          <Card.Text onClick={this.onClick_MiniCard}>
            {this.ReturnSubString(this.state.Title)}
          </Card.Text>
        </Card.Body>
        <Card.Body className="ProductCard_BottomPart">
          <Card.Title>
            {this.state.OriginalPrice + "₽"}
          </Card.Title>
          <Button variant="primary" onClick={this.addNomenclatureToCart} className="ProductCard_ButtonStyle">Купить</Button>
        </Card.Body>

      </Card>

    )
    //рендер
  }

  OnClick_MiniCard(event) {
    if (this.state.Id != undefined)
      this.state.history.push('/catalog/product/' + this.state.Id);
    else
      this.state.history.push('/404');
  }

}
function mapStatetoProps(state) {
  return {
    isInline: state.isInline
  }
}

export default withRouter(MiniProductCard)