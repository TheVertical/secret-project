import React, { Component } from 'react';
import { Modal, Button } from 'bootstrap-4-react';
import Form from 'react-bootstrap/Form'
import "./Modal.css"

export default class MyVerticallyCenteredModal extends Component {
  render() {
    return (
      <div>
        {/* Button trigger Modal */}
        {/* <Button primary data-toggle="modal" data-target="#exampleModal">Launch modal</Button> */}

        {/* Modal */}
        <Modal id="exampleModal" fade>
          <Modal.Dialog centered>
            <Modal.Content>
              <Modal.Header>
                <Modal.Title>Закажите звонок!</Modal.Title>
                <Modal.Close>
                  <span aria-hidden="true">&times;</span>
                </Modal.Close>
              </Modal.Header>
              <Modal.Body>
                <Form>
                  <Form.Row>
                  <Form.Label>Имя*</Form.Label>
                  <Form.Control placeholder="Введите ваше имя" className="OrderRegistration_InputStyle" />
                  </Form.Row>
                  <Form.Row>
                  <Form.Label>Телефон*</Form.Label>
                  <Form.Control placeholder="+7 (999)999-99-99" className="OrderRegistration_InputStyle" />
                  </Form.Row>
                </Form>
              </Modal.Body>
              <Modal.Footer>
                <Button primary>Отправить данные</Button>
              </Modal.Footer>
            </Modal.Content>
          </Modal.Dialog>
        </Modal>
      </div>
    )
  }
}