import React from 'react'
import Card from 'react-bootstrap/Card'
import Button from 'react-bootstrap/Button'
import Badge from 'react-bootstrap/Badge'
import img_src from '../Images/Product.jpg'
import './ProductCard.css'

// class ProductCard extends React.Component{

// constructor(props){
//   super(props)
//   this.state={
//     img_src:'../Images/logo.png',
//     link:"#",
//     price:"3600",
//     title:"Opallis KIT - набор: 6 шприцев(5*4 г EA2/EA3/EA3.5/DA2/DA3+1 шприц*2г) + бонд (FGM)"
//   }
// }


// render(props){
//   return(
//   <Card style={{ width: '16rem' }}>
//   <Badge pill variant="primary">
//     Есть в наличии
//   </Badge>{' '}
//   <Card.Img variant="top" src={props.src} />
//   <Card.Body>
//   <Card.Text>
//      {props.title}
//   </Card.Text>
//   </Card.Body>
//   <Card.Body className="ProductCard_BottomPart">
//   <Card.Title>{props.price+"₽"}</Card.Title>
//     <Button variant="primary">Купить</Button>
//   </Card.Body>
// </Card>
//   )
// }



// }
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