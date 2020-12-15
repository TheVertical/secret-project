import React from 'react'
import Card from 'react-bootstrap/Card'
import Button from 'react-bootstrap/Button'
import Badge from 'react-bootstrap/Badge'
import {connect} from "react-redux"
import './ProductCard.css'
import rootStore from "../redux/rootStore"

// import rootStore from "../redux/rootReducer"


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
            VisualElements: [],
            Style: "ProductCard_BlockStyle",
            ImageStyle: "ProductCard_ImageBlockStyle",
        }
    }
    //Функции React

    //Собственные функции класса
      SetInlineStyle(){
      if(this.props.isInline){
        this.setState({
          Style:"ProductCard_InlineStyle",
          ImageStyle:"ProductCard_ImageInlineStyle"
      }
      );
      }
      else{
        this.setState({
          Style:"ProductCard_BlockStyle",
          ImageStyle:"ProductCard_ImageBlockStyle"
      }
      );
      }
   }
    
   
  componentWillReceiveProps(props){
    if(props.isInline){
      this.setState({
        Style:"ProductCard_InlineStyle",
        ImageStyle:"ProductCard_ImageInlineStyle"
    }
    );
    }
    else{
      this.setState({
        Style:"ProductCard_BlockStyle",
        ImageStyle:"ProductCard_ImageBlockStyle"
    }
    );
    }
  }
   
    render(props){
     
      console.log(this.state.Style)
      return(
      <Card  className={this.state.Style}>
      <Badge pill variant="primary">
        Есть в наличии
      </Badge>{' '}
      <Card.Img variant="top" src={this.state.ImageUrl} className={this.state.ImageStyle}/>
      <Card.Body>
      <Card.Text>
         {this.state.Title} 
      </Card.Text>
      </Card.Body>
      <Card.Body className="ProductCard_BottomPart">
      <Card.Title>
         {this.state.Price+"₽"} 
      </Card.Title>
        <Button variant="primary" onClick={()=>{this.props.onGetMiniProductCard(this.state.Price,this.state.Title,this.state.ImageUrl,this.state.Id)}}>Купить</Button>
      </Card.Body>
      
    </Card>
     
     )
      //рендер
    }

}
function mapStatetoProps(state){
  return{
    isInline:state.isInline,
    width:state.width,
    ImageStyle:state.ImageStyle,
    Style:state.Style
  }
}

function mapDispatchToProps(dispatch){
  return{
    onGetMiniProductCard:(Price,Title,ImageUrl,Id)=>dispatch({type:"GetMiniProductCard",Price:Price,Title:Title,ImageUrl:ImageUrl,Id:Id})
  }
}

export default connect(mapStatetoProps,mapDispatchToProps)(MiniProductCard)