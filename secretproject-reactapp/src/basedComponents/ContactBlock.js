//Библиотечные зависимости
import React from 'react'
import Col from 'react-bootstrap/Col'
import Modal from 'react-bootstrap/Modal'
import ModalHeader from 'react-bootstrap/ModalHeader'
import ModalTitle from 'react-bootstrap/ModalTitle'
import ModalBody from 'react-bootstrap/ModalBody'
import ModalFooter from 'react-bootstrap/ModalFooter'
import Button from 'react-bootstrap/Button'
import Form from 'react-bootstrap/Form'

//Собственные зависимости
import VisualElement from './VisualFactory'
import Picture from "../basedComponents/ImageBlock"
import "./ContactBlock.css"

class ContactBlock extends React.Component{
    constructor(props){
        super();
        this.state = {
            Id: props.Id,
            Phone: props.Phone,
            OpeningHours: props.OpeningHours,
            IsHeaderStyle: props.IsHeaderStyle,
            modalShow: false
        }
    }
    MyVerticallyCenteredModal(props) {
        return (
            <Modal
                {...props}
                size="lg"
                aria-labelledby="contained-modal-title-vcenter"
                centered
            >
                <Modal.Header closeButton>
                    <Modal.Title id="contained-modal-title-vcenter">
                        Пожалуйста укажите ваши данные!
                  </Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Form.Row>
                        <Form.Group as={Col} controlId="formGridEmail">
                            <Form.Label>Ваш Email:</Form.Label>
                            <Form.Control type="email" placeholder="example@gmail.com" />
                        </Form.Group>
                   </Form.Row>
                   <Form.Row>
                        <Form.Group as={Col} controlId="formGridEmail">
                            <Form.Label>Ваш телефон:</Form.Label>
                            <Form.Control type="phone" placeholder="+7(999)999-99-99" />
                        </Form.Group>
                    </Form.Row>
                </Modal.Body>
                <Modal.Footer>
                    <Button onClick={props.onHide}>Close</Button>
                </Modal.Footer>
            </Modal>
        );
    }

    render(){
        if(this.state.IsHeaderStyle == true)
            return(
                <div className="blockStylle">
                    <div className="blockStylle">
                        <a href={"tel:"+this.state.Phone} className="bigAStyle">{this.state.Phone}</a>
                        <p className="pppStyle">{this.state.OpeningHours}</p>
                    </div>
                    <a href="#" className="smallAStyle" onClick={() => this.MyVerticallyCenteredModal(true)}>Заказать обратный звонок</a>
                </div>
            );
        else
            return(
                <div className="blockStylle">
                    <Picture src={'./Images/LogoDown.png'}></Picture>
                        <a href={"tel:"+this.state.Phone} className="bigAAStyle">{this.state.Phone}</a>
                        <p className="pppStyle">{this.state.OpeningHours}</p>
                </div>
            );
    }
}
export default ContactBlock;