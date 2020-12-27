import React from 'react'
import { Row, Col, Container } from 'bootstrap-4-react'
import { Button } from "react-bootstrap"
import './OrderRegistration.css'
import ".././hoc/LayoutElements/Main.css"
import ProductCardArray from "./../hoComplexComponents/ProductCardArray"
import CartProductArray from "./../hoComplexComponents/CartProductArray"
import { NavLink } from 'react-router-dom'
import Breadcrumb from 'react-bootstrap/Breadcrumb'
import Accordion from 'react-bootstrap/Accordion'
import Card from 'react-bootstrap/Card'
import Form from 'react-bootstrap/Form'
import { Formik } from 'formik';
import * as yup from 'yup';
import InputGroup from 'react-bootstrap/InputGroup'
class OrderRegistration extends React.Component {

  constructor() {
    super();
    this.state = {}
  }

  render() {
    const schema = yup.object({
      firstName: yup.string().required(),
      lastName: yup.string().required(),
      username: yup.string().required(),
      city: yup.string().required(),
      state: yup.string().required(),
      zip: yup.string().required(),
      terms: yup.bool().required(),
    });
    return (
      <div className="mainStyle">
        <Container>
          <Row >
            <Breadcrumb>
              <Breadcrumb.Item href="/">Главная</Breadcrumb.Item>
              <Breadcrumb.Item href="/cart">
                Корзина
                                 </Breadcrumb.Item>
              <Breadcrumb.Item active>Оформление заказа</Breadcrumb.Item>
            </Breadcrumb>
          </Row>
          <Row>
            <h1 className="Catalog_Page_H1">Оформление заказа</h1>
          </Row>
          <hr />

          <Row>
            <Col col="8">
              <div className="OrderRegistration_ContainerStyle">
                <div>
                  <h1>1. Контактные данные:</h1>
                  <Form>
                    <Form.Row>
                      <Col>








                        {/* 
                        <Form.Label>Имя*</Form.Label>
                        <Form.Control placeholder="Введите ваше имя" className="OrderRegistration_InputStyle" />
                      </Col>
                      <Col>
                        <Form.Label>Фамилия*</Form.Label>
                        <Form.Control placeholder="Введите вашу фамилию" className="OrderRegistration_InputStyle" />
                      </Col>
                    </Form.Row>
                    <Form.Row>
                      <Col>
                        <Form.Label>Телефон*</Form.Label>
                        <Form.Control placeholder="+7 (999)999-99-99" className="OrderRegistration_InputStyle" />
                      </Col>
                      <Col>
                        <Form.Label>Запасной телефон*</Form.Label>
                        <Form.Control placeholder="+7 (999)999-99-99" className="OrderRegistration_InputStyle" /> */}


                        <Formik
                          validationSchema={schema}
                          onSubmit={console.log}
                          initialValues={{
                            firstName: '',
                            lastName: '',
                          }}
                        >
                          {({
                            handleSubmit,
                            handleChange,
                            handleBlur,
                            values,
                            touched,
                            isValid,
                            errors,
                          }) => (
                            <Form noValidate onSubmit={handleSubmit} >
                              <Form.Row>
                                <Form.Group as={Col} md="4" controlId="validationFormik01">
                                  <Form.Label>Имя*</Form.Label>
                                  <Form.Control
                                    type="text"
                                    name="firstName"
                                    placeholder="Введите ваше имя"
                                    value={values.firstName}
                                    onChange={handleChange}
                                    isValid={touched.firstName && !errors.firstName}
                                    isInvalid={!!errors.firstName}     
                                  />
                                  <Form.Control.Feedback>Запомнили!</Form.Control.Feedback>
                                  <Form.Control.Feedback type="invalid">
                                  {"Поле необходимо заполнить"}
                                  </Form.Control.Feedback>
                                </Form.Group>

                                <Form.Group as={Col} md="4" controlId="validationFormik02">
                                  <Form.Label>Фамилия*</Form.Label>
                                  <Form.Control
                                    type="text"
                                    placeholder="Введите вашу фамилию"
                                    name="lastName"
                                    value={values.lastName}
                                    onChange={handleChange}
                                    isValid={touched.lastName && !errors.lastName}
                                    isInvalid={!!errors.lastName}     
                                        />

                                  <Form.Control.Feedback>Запомнили!</Form.Control.Feedback>
                                  <Form.Control.Feedback type="invalid">
                                  {"Поле необходимо заполнить"}
                                   </Form.Control.Feedback>
                                </Form.Group>
                            
                              </Form.Row>
                              <Form.Row>
                                <Form.Group as={Col} md="6" controlId="validationFormik03">
                                  <Form.Label>Телефон*</Form.Label>
                                  <Form.Control
                                    type="text"
                                    placeholder="+7 (999) 999-999-99"
                                    name="city"
                                    value={values.city}
                                    onChange={handleChange}
                                    isValid={touched.city && !errors.city}
                                    isInvalid={!!errors.city}
                                  />
                                  <Form.Control.Feedback type="invalid">
                                  {"Поле необходимо заполнить"}
                                   </Form.Control.Feedback>
                                  
                                </Form.Group>
                                <Form.Group as={Col} md="4" controlId="validationFormik04">
                                  <Form.Label>Запасной телефон*</Form.Label>
                                  <Form.Control
                                    type="text"
                                    placeholder="+7 (999) 999-999-99"
                                    name="state"
                                    value={values.state}
                                    onChange={handleChange}
                                    isValid={touched.state && !errors.state}
                                    isInvalid={!!errors.state}
                                  />
                                  <Form.Control.Feedback type="invalid">
                                    {"Поле необходимо заполнить"}
                                  </Form.Control.Feedback>
                                </Form.Group>
                        
                              </Form.Row>
                              <Form.Group>
                                <Form.Check
                                  required
                                  name="terms"
                                  label="Согласие на обработку персональных данных"
                                  onChange={handleChange}
                                  // isInvalid={!!errors.terms}
                                  // feedback={errors.terms}
                                  id="validationFormik0"
                                />
                              </Form.Group>
                              {/* <Button type="submit">Submit form</Button> */}
                            </Form>
                          )}
                        </Formik>






                      </Col>
                    </Form.Row>
                  </Form>
                </div>
                <div>
                  <h1>2. Способ получения:</h1>
                  <div className="OrderRegistration_ButtonRow">
                    <Button className="OrderRegistration_ButtonStyle">Самовывоз</Button>
                    <Button className="OrderRegistration_ButtonStyle">Доставка</Button>
                  </div>
                </div>
                <div>
                  <h1>3. Способ оплаты:</h1>
                  <span>Выберите способ оплаты:</span>
                  <div className="OrderRegistration_ButtonRow">
                    <Button className="OrderRegistration_ButtonStyle">При получении</Button>
                    <Button className="OrderRegistration_ButtonStyle">Наличными</Button>
                    <Button className="OrderRegistration_ButtonStyle">Картой</Button>
                  </div>
                  <Form.Check type='checkbox'
                    id={`default`}
                    label={`Прислать СМС с номером заказа на телефон получателя `}
                  />
                </div>
                <div>
                  <span>3 Товара</span>
                  <h1>Итого: 2330 ₽</h1>

                          

                  <Button type="submit" className="OrderRegistration_ButtonStyle">Оформить заказ</Button>

                  <p className="OrderRegistration_pStyle">Компания "Олимп-Дентал" предлагает широкий спектр расходных материалов, инструментов,дезинфакторов, стоматологического оборудования, мебели и стоматологических установок ведущих производителей.</p>

                </div>
              </div>

            </Col>

            <Col className="OrderRegistration_SideBarStyle">
              <div className="Cart_ContainerStyle">
                <h1>Итого</h1>
                <hr></hr>
                <div className="Cart_ContainerInsideStyle">
                  <span>Стоимость</span>
                  <span>2000 ₽</span>
                </div>
                <div className="Cart_ContainerInsideStyle">
                  <span>Скидка</span>
                  <span>100 ₽</span>
                </div>
                <div className="Cart_ContainerInsideStyle">
                  <span>Кол-во товаров</span>
                  <span>3</span>
                </div>
                <hr></hr>
                <div className="Cart_ContainerInsideStyle">
                  <span>Всего к оплате:</span>
                  <h1>3600 ₽</h1>

                </div>
              </div>
            </Col>

          </Row>
        </Container>
      </div>
    )
  }

}
export default OrderRegistration