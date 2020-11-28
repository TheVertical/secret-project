import React from "react"
import "./ContactSectionHeader.css"
import ContactSection from "../basedComponents/ContactSection"
import Col from 'react-bootstrap/Col'
import Modal from 'react-bootstrap/Modal'
import ModalHeader from 'react-bootstrap/ModalHeader'
import ModalTitle from 'react-bootstrap/ModalTitle'
import ModalBody from 'react-bootstrap/ModalBody'
import ModalFooter from 'react-bootstrap/ModalFooter'
import Button from 'react-bootstrap/Button'
import Form from 'react-bootstrap/Form'
// Здесь будут состояния



//Здесь будут функции(внешние)


//Здесь будет главная функция экспорта 
const ContactSectionHeader = (props) => {
    const [modalShow, setModalShow] = React.useState(false);
    function MyVerticallyCenteredModal(props) {
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


    return (

        <div className="blockStylle">
            
            <ContactSection></ContactSection>
            <a href="#" className="smallAStyle" onClick={() => setModalShow(true)}>Заказать обратный звонок</a>
            <MyVerticallyCenteredModal
                show={modalShow}
                onHide={() => setModalShow(false)}
            />
        </div>



    )

}





export default ContactSectionHeader