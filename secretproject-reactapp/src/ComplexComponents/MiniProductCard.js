import React from 'react'
import Card from 'react-bootstrap/Card'
import Button from 'react-bootstrap/Button'
import Badge from 'react-bootstrap/Badge'
// import img_src from '../Images/Product.jpg'
import './ProductCard.css'




//Собственные зависимости

//Расширяет или не расширяет React.Component?
class MiniProductCard extends React.Component{
    constructor(props)
    {
        super(props);
        this.state={
            Id : props.Id,
            Title: props.Title,
            Price: props.Price,
            ImageUrl: props.ImageUrl,
            Type: props.Type,
            VisualElements: []
        }
    }
    //Функции React

    //Собственные функции класса

    render(props){
      return(
      <Card style={{ width: '16rem' }}>
      <Badge pill variant="primary">
        Есть в наличии
      </Badge>{' '}
      <Card.Img variant="top" src={this.state.ImageUrl} />
      <Card.Body>
      <Card.Text>
         {this.state.Title} 
      </Card.Text>
      </Card.Body>
      <Card.Body className="ProductCard_BottomPart">
      <Card.Title>
         {this.state.Price+"₽"} 
      </Card.Title>
        <Button variant="primary">Купить</Button>
      </Card.Body>
    </Card>
      )
      //рендер
    }

}

export default MiniProductCard