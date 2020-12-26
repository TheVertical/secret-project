import React from "react"
import MiniProductCard from "./../ComplexComponents/MiniProductCard"
import "./ProductCardArray.css"
import { Row, Col } from 'bootstrap-4-react'
import { MakeServerQuery } from '../Services/ServerQuery'
import LoadingPage from '../pages/LoadingPage';
import { withRouter } from 'react-router-dom'


class ProductCardArray extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      Direction: {},
      NomenclatureCollection: props.NomenclatureCollection,
      array: [],
    }
  }
  //Метод-установщик полученнных данных в карточку
  SetProductCardArray() {
    if (this.state.NomenclatureCollection != undefined)
      this.state.NomenclatureCollection.map((item) => {
        this.state.array.push(
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
              IsPopular={item.IsPopular}/>
          </Col>)
      })
  }

  render() {
    this.SetProductCardArray();
    return (
      <div>
        <Row>
          {this.state.array}
        </Row>
      </div>

    )
  }



}
//Здесь будет главная функция экспорта 
export default withRouter(ProductCardArray)







