import React from 'react'
import Card from 'react-bootstrap/Card'
import Button from 'react-bootstrap/Button'
import Badge from 'react-bootstrap/Badge'
// import img_src from '../Images/Product.jpg'
import './ProductCard.css'






export default (props)=>{
  return(
  <Card style={{ width: '16rem' }}>
  <Badge pill variant="primary">
    Есть в наличии
  </Badge>{' '}
  <Card.Img variant="top" src={props.src} />
  <Card.Body>
  <Card.Text>
     {props.title}
  </Card.Text>
  </Card.Body>
  <Card.Body className="ProductCard_BottomPart">
  <Card.Title>{props.price+"₽"}</Card.Title>
    <Button variant="primary">Купить</Button>
  </Card.Body>
</Card>
)

}