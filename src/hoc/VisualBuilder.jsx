import React, { Children } from 'react';
import { Container, Row, Col } from 'bootstrap-4-react'
import Header from './LayoutElements/Header';
import VisualElement from '../basedComponents/VisualElement';

//Атомарные компоненты
import Block from '../basedComponents/Block'
// import ContactBlock from '../../src/AtomicComponents/ContactBlock'
// import LinksMenu from '../../src/AtomicComponents/LinksMenu'
class VisualBuilder {
  static renderVisual(backbone) {
    return (
      <div className={backbone.Style}>
        {  VisualElement.renderVisualElement(backbone)}
      </div>
    );
  }

}
export default VisualBuilder
