import React, { Children } from 'react';
import './Footer.css';
import { Container, Row, Col } from 'bootstrap-4-react'
import Picture from "../../basedComponents/ImageBlock"
import LinkBlock from "../../basedComponents/LinksMenu"
import Form from 'react-bootstrap/Form'
import LinkList from '../../ComplexComponents/LinkList'
import ContactSectionFoot from '../../ComplexComponents/ContactSectionFoot'
import VisualElement from '../../basedComponents/VisualElement'

// import bottomLogo from "../../Images/bottomSecureLogo.png"
// import Container from 'react-bootstrap/Container'
// import Row from 'react-bootstrap/Row'
// import Col from 'react-bootstrap/Col'

class Footer extends React.Component {

    constructor(props) {
        super(props)
        this.state = {
            Id: props.Id,
            Row: props.Row,
            NeededColumns: props.NeededColumns,
            VisualElements: props.VisualElements

        }
    }

    render(props) {
        return (




              <div id = "block">
                   {this.state.VisualElements.map(obj =><Col col={obj.NeededColumns}> {VisualElement.renderVisualElement(obj)}</Col>)}
              </div>





            // <div className="globalStyleFooter">
            //     <Container>
            //         <Row className="AlignCenter">
            //             <Col col="lg-auto">
            //                 <h1>Оставайтесь на связи!</h1>
            //             </Col>
                    
            //             <Col>
            //                 <Form>
            //                     <Form.Group controlId="exampleForm.ControlInput1" className="styleForInput">
            //                         <Form.Control type="email" placeholder="name@example.com" />
            //                     </Form.Group>
            //                 </Form>
            //             </Col>
            //             <Col>
                     
            //             </Col>
            //         </Row>
            //         <hr></hr>
            //         <Row>
            //           <Col col="lg">
            //           <LinkList Links={this.state.Links} Title="Моя учетная запись"></LinkList>
            //           </Col>
            //           <Col col="lg">
            //           <LinkList Links={this.state.Links} Title="Магазин"></LinkList>
            //           </Col>
            //           <Col col="lg">
            //           <LinkList  Links={this.state.Links} Title="Cервис"></LinkList>
            //           </Col>
            //           <Col col="lg">
            //           <ContactSectionFoot></ContactSectionFoot>
            //           </Col>
            //         </Row>
            //         <Row className="styyyyleForMargin">
            //           <Col col="lg-auto">
            //           <Picture src={'./Images/bottomSecureLogo.png'}></Picture>
            //           </Col>
            //           <Col col="lg-auto">
                    
            //           </Col>
            //           <Col col="lg-auto">
                    
            //           </Col>
            //         </Row>
            //     </Container>
            // </div>
        );
    }


}

export default Footer