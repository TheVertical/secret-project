import React, { Children } from 'react';
import { Container, Row, Col } from 'bootstrap-4-react'
import Header from './LayoutElements/Header';
import VisualFactory from '../basedComponents/VisualFactory';
import "./LayoutElements/Main.css"

//Атомарные компоненты
import Block from '../basedComponents/Block'
// import ContactBlock from '../../src/AtomicComponents/ContactBlock'
// import LinksMenu from '../../src/AtomicComponents/LinksMenu'

class VisualBuilder {
  static renderVisual(Element) {
    let content = VisualFactory.renderVisualElement(Element);
    return (
      <div>
        <Container>{content}</Container>
      </div>

    );
  }


}
export default VisualBuilder
