import React from "react"
import MiniProductCard from "./../ComplexComponents/MiniProductCard"
import "./ProductCardArray.css"
import { Row, Col } from 'bootstrap-4-react'
import { withRouter } from 'react-router-dom'

class ProductCardArray extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      Direction: {},
      NomenclatureCollection: props.NomenclatureCollection,
      array: [],
    }

    this.updateCardArray = this.UpdateCardArray.bind(this);
  }
  UpdateCardArray(NomenclatureCollection) {
    const ar = this.state.NomenclatureCollection.map((item) => 
      <Col key={item.Id} className="ProductCardArray_Col">
        <MiniProductCard
          key={item.Id}
          Id={item.Id}
          ImageUrl={item.ImageUrl}
          Title={item.Title}
          OriginalPrice={item.OriginalPrice}
          Description={item.Description}
          IsDiscouted={item.IsDiscouted}
          IsInStock={item.IsInStock}
          IsNew={item.IsNew}
          IsPopular={item.IsPopular} />
      </Col>
    );
  return ar;
  }
  render() {
    return (
      <div>
        <Row>
          {this.UpdateCardArray()}
        </Row>
      </div>

    )
  }



}
//Здесь будет главная функция экспорта 
export default withRouter(ProductCardArray)







