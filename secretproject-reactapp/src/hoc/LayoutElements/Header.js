/* eslint react/prop-types: 0 */
import React, { Children } from 'react';
import { Container, Row, Col } from 'bootstrap-4-react';
// import { Picture, LinkBlock} from "../../basedComponents";
import Picture from "../../basedComponents/Picture"
import LinkBlock from "../../basedComponents/LinkBlock"
import ContactSection from "../../basedComponents/ContactSection"
import "./Header.css";
import logo from './logo.png';




class Header extends React.Component{

constructor(){
    super()
    this.state={
        isColumn:false,
        Links:{
            "Доставка и оплата":"#",
            "Возврат":"#",
            "Пункт самовывоза":"#",
            "Возврат":"#",
            "Новости":"#",
            "Акции и скидки":"#",
            "Отзывы":"#"
        }
    }
}

// const getNewState=()=>{
 
// }

render(){
    return (

        <div className="globalStyle">
        <Container>
                <Row align-items="center" >
                  <Col col="lg">
                  <Picture src={logo}></Picture>
                  </Col>
                  <Col col="6">
                      <LinkBlock Links={this.state.Links}></LinkBlock>
                      </Col>
                  <Col col="lg">
                      <ContactSection></ContactSection>
                      </Col>
                </Row>
              </Container>
        </div>
            )
    

}

}
export default Header
 


